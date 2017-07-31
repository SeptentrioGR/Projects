using UnityEngine;

public enum Layer
{
    Interactable = 8,
    Monster = 9,
    NotInteractable = 10,
    World = 11,
    RaycastEndStop = -1
}
namespace ZombieRun
{
    public class Utilities
    {
        public static void hitSomethingInFrontOfMe(RaycastHit hit)
        {
            switch (hit.collider.name)
            {
                case "Radio_Interactable":
                    GameObject.Destroy(hit.collider.gameObject);
                    InventoryManager.instance.AddItem("Radio");
                    NarationManager.Instance.FoundItem();
                    NarationManager.Instance.StartNaration();
                    break;
                case "Helicopter":
                    GameManager.Instance.GameOver();
                    break;
                case "Monster":
 
                    break;
            }
        }
    }
}