using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class Enemy_AI : MonoBehaviour
{
	public enum Actions
	{
		Idle, Walking, Running, Attacking, Hit, Dead
	}

	public Actions curAction;
	private float RotationSpeed = 25f;
	private Quaternion _lookRotation;
	private Vector3 _direction;
	private Animator mAnimator;
	private NavMeshAgent agent;
	public GameObject target;
	//This will be the zombie's speed. Adjust as necessary.
	private float speed = 6.0f;
	public float minDistance = 2;
	public float maxDistanceTillAttack;

	private bool walking;
	private bool attacking;
	public float distance;
	private Vector3 Destination;
	public string[] Animations =
	{
		"Walk","Attack","Death","Revive"
	};


	public void setTarget(GameObject target)
	{
		this.target = target;
	}

	void Start()
	{
		curAction = Actions.Idle;
		mAnimator = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
		agent.stoppingDistance = minDistance;
		setTarget(GameObject.Find("Player"));


	}



	void Update()
	{
		agent.speed = speed;
		mAnimator.SetBool(getAnimation(0), walking);
		mAnimator.SetBool(getAnimation(1), attacking);
		if (target && target.GetComponent<PlayerScript>().light.LightIsPowered() || CountDown.Instance.StartCounting)
		{
			distance = Vector3.Distance(target.transform.position, transform.position);
			if (distance <= minDistance + .5f)
			{
				curAction = Actions.Attacking;
			} else
			{
				curAction = Actions.Walking;
				Destination = target.transform.position;
			}

		} else
		{
			curAction = Actions.Idle;
		}

		switch (curAction)
		{
			case Actions.Idle:
				Idle();
				break;
			case Actions.Walking:
				Walk();
				break;
			case Actions.Running:
				break;
			case Actions.Attacking:
				Attack();
				break;
			case Actions.Hit:
				break;
			case Actions.Dead:
				break;
			default:
				break;
		}
	}

	public void setDestination(Vector3 position)
	{
		agent.SetDestination(position);
	}

	public void Idle()
	{
		//Debug.Log("Is Idle");
		walking = false;
		attacking = false;
		if (!agent.isStopped)
		{
			agent.isStopped = true;
		}
	}

	public void Walk()
	{
		//Debug.Log("Walk");
		walking = true;
		attacking = false;
		if (agent.isStopped)
		{
			agent.isStopped = false;
		}
		agent.SetDestination(Destination);
	}

	public void Attack()
	{
		//Debug.Log("Is Attacking");
		walking = false;
		attacking = true;
		if (agent.isStopped)
		{
			agent.isStopped = true;
		}

	}
	//====================================================================================================
	void TurnAndLookTarget()
	{
		//transform.RotateAround(transform.position, Vector3.up, ControlsManager.getAxisInput("Mouse X") * mouse_rotation_speed);
		//find the vector pointing from our position to the target
		_direction = (target.transform.position - transform.position).normalized;

		//create the rotation we need to be in to look at the target
		_lookRotation = Quaternion.LookRotation(_direction);
		_lookRotation.x = 0;
		_lookRotation.z = 0;
		//rotate us over time according to speed until we are in the required rotation
		transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
	}

	//====================================================================================================
	//public void LookPlayerDirection()
	//{
	//    //transform.RotateAround(transform.position, Vector3.up, ControlsManager.getAxisInput("Mouse X") * mouse_rotation_speed);
	//    //find the vector pointing from our position to the target
	//    _direction = (wayPoint.transform.position - transform.position).normalized;

	//    //create the rotation we need to be in to look at the target
	//    _lookRotation = Quaternion.LookRotation(_direction);
	//    _lookRotation.x = 0;
	//    _lookRotation.z = 0;
	//    //rotate us over time according to speed until we are in the required rotation
	//    transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
	//}
	//====================================================================================================
	public string getAnimation(int number)
	{
		switch (number)
		{
			case 0:
				return Animations[0];
			case 1:
				return Animations[1];
			case 2:
				return Animations[2];
			case 3:
				return Animations[3];
			case 4:
				return Animations[4];
			default:
				throw new System.Exception("Animation Not Found, 1 - 4 available");
		}
	}
}
