using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun
{
    public class ToogleMeshRenderer : ToggleByDistance
    {

        private MeshRenderer mMeshRenderer;
        // Use this for initialization
        void Start()
        {
            mMeshRenderer = GetComponent<MeshRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            CheckForDistance();
            mMeshRenderer.enabled = Toggle;
        }
    }
}
