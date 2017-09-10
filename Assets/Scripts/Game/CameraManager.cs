using Kino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZombieRun
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
        AnalogGlitch m_AnalogGlitch;
        public LayerMask m_Layers;

        public bool IncreaseJitterEffeect = false;
        public float m_AmountOfJitter;
        private GameObject m_CurrentTarget;
        public bool DebugRaycast;

        private void Awake()
        {
            m_Instance = this;
        }

        void Start()
        {
            m_AnalogGlitch = GetComponent<AnalogGlitch>();
        }

        void Update()
        {
            if(CameraManager.Instance.mCrossIcon != NoAction)
            {
                CameraManager.Instance.SetIcon(NoAction);
            }
            
            Ray ray = new Ray(Camera.main.transform.position, transform.forward);
            bool hasHit = Physics.Raycast(ray, out m_RaycastHit, distanceToBackground, m_Layers);

            if (Game.Instance.HittingTheEnemy)
            {
                Game.Instance.HittingTheEnemy = false;
            }

            if (hasHit)
            {
                Interactable interactable = m_RaycastHit.collider.GetComponent<Interactable>();
  
                if (interactable)
                {

                    if (DebugRaycast)
                    {
                        Debug.Log(m_RaycastHit.collider.name + " " + m_RaycastHit.distance + " " + interactable.radius);
                    }

                    if (m_RaycastHit.distance < interactable.radius)
                    {
                        interactable.CloseTo();
                        interactable.ChangeCursorToInteraction();

                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            interactable.OnInteraction();
                        }
                    }
                }
            }

            if (IncreaseJitterEffeect)
            {
                m_AmountOfJitter += .1f;
            }else
            {
                m_AmountOfJitter -= .1f;
            }

            Player player = PlayerManager.Instance.GetPlayer().GetComponent<Player>();

            if (m_CurrentTarget != null)
            {
                IncreaseJitterEffeect = true;
                float distance = Vector3.Distance(player.transform.position, m_CurrentTarget.transform.position);
                if (distance > 10)
                {
                    IncreaseJitterEffeect = false;
                }
            }
            else
            {
                GetClosestEnemy();
            }

            m_AmountOfJitter = Mathf.Clamp(m_AmountOfJitter, 0, 1);
            m_AnalogGlitch.scanLineJitter = m_AmountOfJitter;
        }

        public void SetIcon(Sprite m_Sprite)
        {
            mCrossIcon.sprite = m_Sprite;
        }

        public void GetClosestEnemy()
        {
            Player player = PlayerManager.Instance.GetPlayer().GetComponent<Player>();
            foreach (GameObject m in EnemyManager.Instance.m_ListOfEnemies)
            {
                float distance = Vector3.Distance(player.transform.position, m.transform.position);

                if (distance < 10)
                {
                    m_CurrentTarget = m;
                }
            }
        }
    }
}
