using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
	private GameObject target;
	public bool AttackPlayer = false;
	private bool walking;
	public Rigidbody mRigidBody;
	private Animator mAnimator;
	public AudioClip[] sounds;
	public float damage;
	public float nextAttack;
	public float attackRate;
	public float RawrFrequence;
	public float timer;
	void Awake()
	{
		mRigidBody = GetComponent<Rigidbody>();
		mAnimator = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		AttackPlayer = mAnimator.GetBool("Attack");
		if (AttackPlayer)
		{
			//Debug.Log("Found Player");
			if (Time.time > nextAttack)
			{
				nextAttack = Time.time + attackRate;
				GetComponent<Enemy_AI>().target.SendMessage("Damage", damage);
			}
		}
		Rawr();
	}

	void Damage()
	{

	}

	void OnMouseOver()
	{

	}

	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.GetComponent<PlayerScript>())
		{
			AttackPlayer = true;
		}
	}

	void OnTriggerExit(Collider other)
	{

		if (other.gameObject.GetComponent<PlayerScript>())
		{
			AttackPlayer = false;
		}
	}

	void Rawr()
	{
		timer -= Time.deltaTime;
		if (timer < 0)
		{
			timer = RawrFrequence;
			GetComponent<AudioSource>().clip = sounds[Random.Range(0,sounds.Length)];
			GetComponent<AudioSource>().Play();
		}
	}



}
