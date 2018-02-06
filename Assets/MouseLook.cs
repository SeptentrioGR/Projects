using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {



    public string m_MouseXString = "Mouse X";
    public string m_MouseYString = "Mouse Y";


    public float m_SmoothY;
    public float m_SmoothX;

    public bool m_Walking;
 
	

	void Update () {
            
        float velX = Input.GetAxis(m_MouseXString) * m_SmoothX * Time.deltaTime;
        float velY = -Input.GetAxis(m_MouseYString)  * m_SmoothY * Time.deltaTime;

        transform.eulerAngles += new Vector3(0, velX, 0);
        Camera.main.transform.eulerAngles += new Vector3(velY, 0, 0);


        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    
    }
}

