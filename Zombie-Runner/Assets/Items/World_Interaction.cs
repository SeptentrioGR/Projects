using UnityEngine;


public class World_Interaction
{

	public void hitSomethingInFrontOfMe(RaycastHit hit)
	{
		Debug.Log("Hit Something " + hit.collider.gameObject.name);

		switch (hit.collider.name)
		{
			case "Radio":
				UIManager.mInstance.Icons[UIManager.IconElements.Radio].enabled = true;
				GameObject.Destroy(hit.collider.gameObject);
				break;
			case "Helicopter":

				GameManager.Instance.ResetGame();
				break;
		}
	}
}
