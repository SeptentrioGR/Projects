using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZombieRun
{
    public class IsVisibleOrNot : MonoBehaviour
    {

        private GameObject mTarget;
        public bool IsVisibleByPlayer;
        public bool HasBeenSeenByPlayer = false;

        void OnBecameInvisible()
        {
            IsVisibleByPlayer = false;
        }

        void OnBecameVisible()
        {
            if (!HasBeenSeenByPlayer)
            {
                HasBeenSeenByPlayer = true;
                MusicManager.Instance.PlaySound(0);
            }
            IsVisibleByPlayer = true;
        }

        private void Start()
        {
            mTarget = this.gameObject;
        }

    }
}
