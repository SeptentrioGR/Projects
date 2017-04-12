using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Water;

public class PlayerScript : MonoBehaviour
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
	public GameObject Radio;
	private Animator mAnimation;
	private FirstPersonController controller;
	private CharacterController c_controller;
	private int HoldingItem = 0;
	private bool UpdateHoldingItems;

	public Vector3 StartingTransform;
	public Quaternion StartingRotation;

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
		mAnimation = GetComponent<Animator>();
		controller = GetComponent<FirstPersonController>();
		c_controller = GetComponent<CharacterController>();
		controller.enabled = true;
		c_controller.enabled = true;
		mAnimation.enabled = false;
		light.Initialize(100);
		Radio = GameObject.Find("RadioPrefab");
		StartingTransform = transform.position;
		StartingRotation = Quaternion.identity;
	}

	// Update is called once per frame
	void Update()
	{
		if (GameManager.Instance.gameState == GameStates.Game)
		{
			HealthSystem();
			StaminaSystem();
			light.Update();
		//controller.UpdateStaminaValue(mStamina);

		
			if (Input.GetKeyDown(KeyCode.F))
			{
				HoldingItem = 1;
				UpdateHoldingItems = true;
			}

			if (Input.GetKeyDown(KeyCode.Alpha1) && UIManager.mInstance.Icons[UIManager.IconElements.Radio].enabled)
			{
				HoldingItem = 2;
				if (light.LightIsPowered())
				{
					light.Power();
				}
				UpdateHoldingItems = true;
			}

			if (HoldingItem != 2)
			{
				Radio.SetActive(false);
			}
			if (GameManager.Instance.CheckIfPaused())
			{
				controller.enabled = false;

			}



			if (UpdateHoldingItems)
			{
				UpdateHoldingItems = false;
				switch (HoldingItem)
				{
					case 0:
						break;
					case 1:
						light.Power();
						break;
					case 2:
						Radio.SetActive(true);
						break;
				}
			}

		}
		
	}

	void Death()
	{
		if (light.LightIsPowered())
		{
			light.Power();
		}
		if (!mAnimation.enabled)
		{
			StartCoroutine("ResetGame");
			mAnimation.enabled = true;
			controller.enabled = false;
			c_controller.enabled = false;
		}
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
		} else if (Input.GetAxis("Vertical") > 0.5f || Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("Vertical") < -0.5f || Input.GetAxis("Horizontal") < -0.5f)
		{
			mStamina -= decreaseWhileWalk;
		} else
		{
			mStamina += 5f;
		}

		mStamina = Mathf.Clamp(mStamina, 0, 100);


	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Hellicopter")
		{
			ResetGame();
		}
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

	IEnumerator ResetGame()
	{
		Debug.Log("Reseting game.... ");
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}

