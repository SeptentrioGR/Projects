using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class Element : MonoBehaviour {
	public UILineRenderer line;
	public Transform parent;
	public Transform[] Targets;
	// Use this for initialization
	void Start () {
		foreach (Transform pos in Targets)
		{
			UILineRenderer ALine = Instantiate(line, parent) as UILineRenderer;
			Vector2[] positions = new Vector2[2];
			positions[0] = (Vector2)transform.localPosition;
			positions[1] = (Vector2)pos.localPosition;
			ALine.Points = positions;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
