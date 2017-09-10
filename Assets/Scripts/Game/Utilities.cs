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
    public class Utilities : MonoBehaviour
    {
        public bool Debugging = false;

        public void Update()
        {
            if (Debugging)
            {
                if (Input.GetKeyDown(KeyCode.L))
                {
                    Destroy(ItemManager.Instance.GetRadio());
                    InventoryManager.instance.AddItem("Radio");
                    NarationManager.Instance.FoundItem();
                    NarationManager.Instance.StartNaration();

                }

                if (Input.GetKeyDown(KeyCode.PageUp))
                {
                    CountDown.Instance.speed += 5;
                }
                else if (Input.GetKeyDown(KeyCode.PageDown))
                {
                    CountDown.Instance.speed -= 5;
                }
            }
        }
    }
}