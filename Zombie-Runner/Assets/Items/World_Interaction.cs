using UnityEngine;

public class World_Interaction
{
	public void hitSomethingInFrontOfMe(RaycastHit hit)
	{
		Debug.Log("Hit Something " + hit.collider.gameObject.name);
		if (hit.collider.name.Equals("Radio"))
		{
			UIManager.Instance.GetIcon("Radio").gameObject.SetActive(true);
			GameObject.Destroy(hit.collider.gameObject);
		}
	}
}
