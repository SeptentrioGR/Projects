using UnityEngine;
using UnityEngine.AI;
namespace ZombieRun
{
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
        public Character target;

        //This will be the zombie's speed. Adjust as necessary.
        public float speed = 16.0f;
        public float minDistance = 2;
        public float maxDistanceTillAttack;

        private bool walking;
        private bool attacking;
        public float distance;
        private Vector3 Destination;
        public bool IsVisibleByPlayer;


        public string[] Animations =
        {
        "Walk","Attack","Death","Revive"
    };

        public Character Target
        {
            get
            {
                return target;
            }
        }

        public void setTarget(Character target)
        {
            this.target = target;
        }

        void Start()
        {
            mAnimator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();
            agent.stoppingDistance = minDistance;
            //agent.speed = speed;
            //mAnimator.SetBool(getAnimation(0), walking);
            //mAnimator.SetBool(getAnimation(1), attacking);
        }



        public void UpdateEnemyState()
        {
            if (target && !IsVisibleByPlayer)
            {
                TurnAndLookTarget();
                distance = Vector3.Distance(target.transform.position, transform.position);
                if (distance <= minDistance + .5f)
                {
                    curAction = Actions.Attacking;
                }
                else
                {
                    curAction = Actions.Walking;
                }
            }
            else
            {
                curAction = Actions.Idle;
            }
        }

        private void Update()
        {
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
            walking = false;
            attacking = false;
            Stop(true);
        }

        public void Walk()
        {
            walking = true;
            attacking = false;
            Stop(false);

            if (agent.destination != Destination)
            {
                agent.SetDestination(target.transform.position);
            }
        }

        public void Attack()
        {
            //Debug.Log("Is Attacking");
            walking = false;
            attacking = true;
            Stop(true);
        }

        public void Stop(bool value)
        {
            if (agent.isStopped != value)
            {
                agent.isStopped = value;
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
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _lookRotation, RotationSpeed);
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


    }
}
