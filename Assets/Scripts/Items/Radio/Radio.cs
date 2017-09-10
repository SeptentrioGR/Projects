using System;
using UnityEngine;
namespace ZombieRun
{
    public class Radio : MonoBehaviour
    {
        private bool used;
        public GameObject LandingPrefab;

        void Update()
        {
            bool CanUseRadio = Input.GetKeyDown(KeyCode.E) && RadioClearArea.Instance.AreaIsClear && !used;
            if (CanUseRadio)
            {
                Use();
            }
        }
 
        public void Use()
        {
            Action();
        }

        public void Action()
        {
            Character Player = PlayerManager.Instance.GetPlayer();
            used = true;
            GameObject go = Instantiate(LandingPrefab,
                Player.transform.position, Player.transform.rotation) as GameObject;
            go.name = LandingPrefab.name;  
            gameObject.SetActive(false);
            Helicopter.Instance.CallHelipter();
        }

        
    }
}
