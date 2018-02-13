using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public string m_VerticalString = "Vertical";
    public string m_HorizontalString = "Horizontal";

    public float m_Speed;

    public bool m_Running;

    public float m_WalkingSpeed;
    public float m_RunningSpeed;


    void Update () {

        float vertical = Input.GetAxis(m_VerticalString);
        float horizontal = Input.GetAxis(m_HorizontalString);

        Vector2 m_Input = new Vector2(horizontal, vertical);

        Vector3 direction = transform.forward * m_Input.y;


        if (m_Running)
        {
            m_Speed = m_RunningSpeed;
        }
        else
        {
            m_Speed = m_WalkingSpeed;
        }


        var newPosition = transform.position;

        newPosition += transform.forward * vertical * m_Speed * Time.deltaTime;
        newPosition += transform.right * horizontal * m_Speed * Time.deltaTime;

        transform.position = newPosition;


        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_Running = true;
        }
        else 
        {
            m_Running = false;
        }
   
    }

}
