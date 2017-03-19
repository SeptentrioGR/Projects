using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    private bool walking;
    public Rigidbody mRigidBody;
    private Animator mAnimator;
    public AudioClip[] sounds;
    public float damage;
    public float nextAttack;
    public float attackRate;
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
        if (mAnimator.GetBool("Attack"))
        {

        }

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
            Debug.Log("Found Player");
            PlayerScript ps = other.gameObject.GetComponent<PlayerScript>();
            if (Time.time > nextAttack)
            {
                nextAttack = Time.time + attackRate;
                //ps.SendMessage("Damage", damage);
            }
        }
    }




}
