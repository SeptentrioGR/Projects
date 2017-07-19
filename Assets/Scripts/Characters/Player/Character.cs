using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Water;
using System;
using System.Collections.Generic;

public enum ItemElement
{
	Flashlght,Radio
}

public class Character : MonoBehaviour
{
	public float mHealth = 100;
	public float mStamina = 100;
	public float mSanity = 100;

	[Header("Stamina Thresholds")]
	public float decreaseWhileWalk;
	public float decreaseWhileRun;
	public new Flashlight light;
	public InventoryManager Inventory;
	public bool UnderWater;
	private bool HasRadio;
	private Animator mAnimation;
	private FirstPersonController controller;
	private CharacterController c_controller;
	private int HoldingItem = 0;
	private bool UpdateHoldingItems;

	public Vector3 StartingTransform;
	public Quaternion StartingRotation;
	public Item[] Items;
	private Dictionary<string, GameObject> UsableItems = new Dictionary<string, GameObject>();
    private int itemInUse;
	public Transform Hand;
	
	public void IAquireRadio()
	{
		HasRadio = true;
	}

	public FirstPersonController getPlayerController()
	{
		return controller;
	}

	public void Reset()
	{
		HoldingItem = 0;
		UpdateHoldingItems = true;
		transform.rotation = StartingRotation;
	}

	void Start()
	{
		controller = GetComponent<FirstPersonController>();
		c_controller = GetComponent<CharacterController>();
		controller.enabled = true;
		c_controller.enabled = true;
		light.Initialize(100);
		StartingTransform = transform.position;
		StartingRotation = Quaternion.identity;

		InstansiateItems();
	}

	public void UpdateUsbleItems()
	{
		foreach (GameObject item in UsableItems.Values)
		{
			item.SetActive(false);
		}
	}



	private void InstansiateItems()
	{
		foreach (Item ui in Items)
		{
			var itemPrefab = ui.getItemPrefab();
			var item = Instantiate(itemPrefab, Hand);
			item.transform.localPosition = ui.getItemGrip().localPosition;
			item.transform.localRotation = ui.getItemGrip().localRotation;
			UsableItems.Add(ui.name, item);
		}
		UpdateUsbleItems();
	}

	// Update is called once per frame
	void Update()
	{
		HealthSystem();
		StaminaSystem();
		light.Update();

		if (itemInUse == 0)
		{
			UpdateUsbleItems();
		}
		if (itemInUse == 1)
		{
			ShowItemToUse(Items[0].name);
		}
		if (itemInUse == 2)
		{
			ShowItemToUse(Items[1].name);
		}

		if (Input.GetKeyDown(KeyCode.F))
		{
			if (light.LightIsPowered())
			{
				light.Power();
				itemInUse = 0;
			}
			else
			{
				itemInUse = 1;
			}
			UpdateHoldingItems = true;
		}

		if (Input.GetKeyDown(KeyCode.Alpha1) && HasRadio)
		{
			itemInUse = 2;
			if (light.LightIsPowered())
			{
				light.Power();
			}
			UpdateHoldingItems = true;
		}


		if (UpdateHoldingItems)
		{
			UpdateHoldingItems = false;
			switch (itemInUse)
			{
				case 0:
					break;
				case 1:
					light.Power();
					UpdateUsbleItems();
					break;
				case 2:
					UpdateUsbleItems();
					break;
			}
		}

    }

	private void ShowItemToUse(string name)
	{
		GameObject go;
		UsableItems.TryGetValue(name, out go);
		go.SetActive(true);
	}

	void Death()
	{
		if (light.LightIsPowered())
		{
			light.Power();
		}

			StartCoroutine("ResetGame");
	}

	void HealthSystem()
	{
		if (UnderWater)
		{
			mHealth -= 1f;
		}
		if (mHealth <= 0.0f)
		{
			Death();
		}
		mHealth = Mathf.Clamp(mHealth, 0, 100);
	}

	void StaminaSystem()
	{
		if (Input.GetKey(KeyCode.LeftShift))
		{
			mStamina -= decreaseWhileRun;
		}else
		{
			mStamina += 1f;
		}

		if(mStamina <= 0)
		{
			controller.DisableRun(false);
		}
		else
		{
			controller.DisableRun(true);
		}

		mStamina = Mathf.Clamp(mStamina, 0, 100);


	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<Water>())
		{
			UnderWater = !UnderWater;
		}	
	}

	public void Damage(float value)
	{
		mHealth -= value;
	}



}

