using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ZombieRun.Player
{
    public class CameraManager : MonoBehaviour
    {
        private static CameraManager m_Instance;

        public static CameraManager Instance
        {
            get
            {
                return m_Instance;
            }
        }

        public Image mCrossIcon; 

        public Sprite NoAction;
        public Sprite Interactable;
        public Sprite NotInteractable;
        public Sprite Attackable;
        public Sprite Unknown;
        private float distanceToBackground = 100f;
        RaycastHit m_RaycastHit;

        public LayerMask m_Layers;

        private void Awake()
        {
            m_Instance = this;
        }

        void Start()
        {
            new Utilities();
        }

        void Update()
        {
            CameraManager.Instance.SetIcon(NoAction);
            Ray ray = new Ray(Camera.main.transform.position, transform.forward);
            bool hasHit = Physics.Raycast(ray, out m_RaycastHit, distanceToBackground, m_Layers);

            if (hasHit)
            {
                SimpleCursorChange SimpleCursorChange = m_RaycastHit.collider.GetComponent<SimpleCursorChange>();
                if (SimpleCursorChange && m_RaycastHit.distance< 5f)
                {
                    SimpleCursorChange.ChangeCursorToInteraction();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Utilities.hitSomethingInFrontOfMe(m_RaycastHit);
                    }
                }
            }

           
        }

        public void SetIcon(Sprite m_Sprite)
        {
            mCrossIcon.sprite = m_Sprite;
        }
    }
}
