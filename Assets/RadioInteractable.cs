using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZombieRun{
    public class RadioInteractable : Interactable
    {
        public override void OnInteraction()
        {
            GameObject.Destroy(this.gameObject);
            InventoryManager.instance.AddItem("Radio");
            NarationManager.Instance.FoundItem();
            NarationManager.Instance.StartNaration();
        }

        public override void CloseTo()
        {

        }
    }
}
