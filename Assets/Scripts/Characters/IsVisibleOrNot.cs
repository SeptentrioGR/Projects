using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZombieRun
{
    public class IsVisibleOrNot : MonoBehaviour
    {
        public bool IsVisibleByPlayer;
        public bool HasBeenSeenByPlayer = false;

        void OnBecameInvisible()
        {
            IsVisibleByPlayer = false;
        }

        void OnBecameVisible()
        {
            IsVisibleByPlayer = true;
        }

        private void Update()
        {
            if (PlayerManager.Instance == null)
            {
                Debug.LogWarning("PlayerManager not Found");
                return;
            }
            Character player = PlayerManager.Instance.GetPlayer();

            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (!HasBeenSeenByPlayer && GetComponent<MeshRenderer>().enabled && IsVisibleByPlayer && Game.Instance.TimeSincePlayedSpookySound <=0)
            {
                HasBeenSeenByPlayer = true;
                MusicManager.Instance.PlaySound(0);
                Game.Instance.TimeSincePlayedSpookySound = 10.0f;
            }
        }
    }
}
