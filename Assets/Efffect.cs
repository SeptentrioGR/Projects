using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZombieRun
{
    public class Efffect : MonoBehaviour
    {
        public ParticleSystem mParticle;
        private Vector3 Scale;
        public Vector3 offset;
        public float Size;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.localScale = new Vector3(Size, Size, Size);
        }

        private void LateUpdate()
        {
            transform.position = PlayerManager.Instance.GetPlayer().transform.position + offset;
        }
    }
}
