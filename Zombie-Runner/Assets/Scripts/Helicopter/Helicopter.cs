using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

	public Animator mAnimator;
	public Vector3 Destination;
	public bool Called;
	public float speed;
	public Vector3 offset;
	public float distance;

	void Start () {
		mAnimator = transform.GetChild(0).GetComponent<Animator>();
		mAnimator.enabled = false;
	}
	

	void Update () {
		distance = (transform.position - (Destination + offset)).magnitude;
		if (Called)
		{
			CountDown.Instance.Initialize();
			if (CountDown.Instance.TimeIsUp())
			{
				GoToArea();
			}
		}

		if(distance < 0.5f)
		{
			if (!mAnimator.enabled)
			{
				mAnimator.enabled = true;
			}
		}
	}

	public void CalLHelp()
	{		
		Called = true;
	}

	public void GoToArea()
	{
		Destination = GameObject.Find("LandingArea").gameObject.transform.position;
		Vector3 lookDirection = Destination + offset;
		transform.eulerAngles = new Vector3(0, 0, 0);
		transform.position = Vector3.Lerp(transform.position, lookDirection, speed * Time.deltaTime);
	}
}
