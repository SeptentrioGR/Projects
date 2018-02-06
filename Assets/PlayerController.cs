using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public string m_VerticalString = "Vertical";
    public string m_HorizontalString = "Horizontal";

    public float m_Speed;
    public float m_JumpSpeed;

    public bool m_IsGrounded;
    public bool m_Jumped;
    public float m_Gravity;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float vertical = Input.GetAxis(m_VerticalString);
        float horizontal = Input.GetAxis(m_HorizontalString);


        transform.position += transform.forward * m_Speed * vertical * Time.deltaTime;

        transform.position += transform.right * m_Speed * horizontal * Time.deltaTime;



    }



    private void OnCollisionEnter(Collision collision)
    {
        m_IsGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        m_IsGrounded = false;
    }
}
