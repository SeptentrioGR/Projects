using UnityEngine;

namespace ZombieRun.Player
{

	public class World_Interaction
	{

		public void hitSomethingInFrontOfMe(RaycastHit hit)
		{
			Debug.Log("Hit Something " + hit.collider.gameObject.name);

			switch (hit.collider.name)
			{
				case "Radio":
                    
                    GameObject.Destroy(hit.collider.gameObject);
					break;
				case "Helicopter":
					hit.collider.gameObject.SetActive(false);
                    GameManager.Instance.GameOver();
					break;
			}
		}
	}
}
