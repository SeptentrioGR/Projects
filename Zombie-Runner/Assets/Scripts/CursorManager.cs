using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager{

   private static CursorManager m_Instace;
    public static CursorManager Instance
    {
        get
        {
            if (m_Instace == null)
            {
                m_Instace = new CursorManager();
                return m_Instace;
            }
            else
            {
                return m_Instace;
            }
        }
    }
    


    void Start () {
		
	}
	
    public void Initialise()
    {
      
    }

	public void Update () {
        Character Player = PlayerManager.Instance.GetPlayer();

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Player.GetComponent<FirstPersonController>().enabled = true;
        }
        else if (Cursor.lockState == CursorLockMode.None)
        {
            Player.GetComponent<FirstPersonController>().enabled = false;
        }
    }
}
