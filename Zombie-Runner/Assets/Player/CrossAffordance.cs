using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(CameraRaycaster))]
public class CrossAffordance : MonoBehaviour {
	CameraRaycaster camRaycaster;
	private Image mCrossIcon;
	[SerializeField]
	Sprite NoAction;
	[SerializeField]
	Sprite Interactable;
	[SerializeField]
	Sprite NotInteractable;
	[SerializeField]
	Sprite Attackable;
	[SerializeField]
	Sprite Unknown;
	// Use this for initialization
	void Start () {
		camRaycaster = GetComponent<CameraRaycaster>();
		camRaycaster.onLayerChange += OnLayerChange;
		mCrossIcon = GetComponent<Image>();
	}
	

	private void OnLayerChange(Layer newLayer)
	{
		// print("Cursor over new Layer" + newLayer);
		switch (newLayer)
		{
			case Layer.World:
				mCrossIcon.sprite = NoAction;
				break;
			case Layer.Interactable:
				mCrossIcon.sprite = Interactable;
				break;
			case Layer.Monster:
				mCrossIcon.sprite = Attackable;
				break;
			case Layer.NotInteractable:
				mCrossIcon.sprite = NotInteractable;
				break;
			case Layer.RaycastEndStop:
				mCrossIcon.sprite = NoAction;
				break;
			default:
				mCrossIcon.sprite = NoAction;
				return;
		}
	}
}
