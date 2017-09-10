using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotateByAxis : MonoBehaviour {
    public enum Axis {
        X,Y,Z
    }
    public Axis RotateOnAxis = Axis.X;
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var m_Rotation = new Vector3();
        var axisSpeed = speed * Time.deltaTime;
        switch (RotateOnAxis)
        {
            case Axis.X:
                m_Rotation = new Vector3(axisSpeed, 0, 0);
                break;
            case Axis.Y:
                m_Rotation = new Vector3(0, axisSpeed, 0);
                break;
            case Axis.Z:
                m_Rotation = new Vector3(0,0,axisSpeed);
                break;
        }
        transform.Rotate(m_Rotation);	
	}
}
