using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZombieRun {
    public abstract class Interactable : MonoBehaviour
    {
        public Sprite m_Sprite;
        public float radius = 5f;

        public abstract void CloseTo();

        public abstract void OnInteraction();

        public void ChangeCursorToInteraction()
        {
            CameraManager.Instance.SetIcon(m_Sprite);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
