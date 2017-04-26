using UnityEngine;


[CreateAssetMenu(menuName = ("ZombieRun/Item"))]
public class Item : ScriptableObject
{
	[SerializeField] private int Name;
	[SerializeField] GameObject ItemPrefab;
	[SerializeField] AnimationClip UsingAnimation;
	[SerializeField] Transform HoldingHand;


	public GameObject getItemPrefab()
	{
		return ItemPrefab;
	}

	public Transform getItemGrip()
	{
		return HoldingHand;
	}
}
