using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Water;

    public class PlayerScript : MonoBehaviour
    {
        public float mHealth = 100;
        public float mStamina = 100;
        public float mSanity = 100;

        [Header("Stamina Thresholds")]
        public float decreaseWhileWalk;
        public float decreaseWhileRun;
        public SurvivalSystem s_system;

        public bool UnderWater;

        public Animator mAnimation;

        FirstPersonController controller;
        CharacterController c_controller;

        void Start()
        {
            s_system = new SurvivalSystem(100, 100, 1.5f, 2.5f);
            mAnimation = GetComponent<Animator>();
            controller = GetComponent<FirstPersonController>();
            c_controller = GetComponent<CharacterController>();
            controller.enabled = true;
            c_controller.enabled = true;

            mAnimation.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            HealthSystem();
            StaminaSystem();
            s_system.Update();
        controller.UpdateStaminaValue(mStamina);
        }

        void HealthSystem()
        {
            if (UnderWater)
            {
                mHealth -= 1f;
            }
            if (mHealth <= 0.0f)
            {
                if (!mAnimation.enabled)
                {
                    StartCoroutine("ResetGame");
                    mAnimation.enabled = true;
                    controller.enabled = false;
                    c_controller.enabled = false;
                }
            }
            mHealth = Mathf.Clamp(mHealth, 0, 100);
        }

        void StaminaSystem()
        {


            if (Input.GetKey(KeyCode.LeftShift) )
            {
                mStamina -= decreaseWhileRun;
            }
            else if (Input.GetAxis("Vertical") > 0.5f || Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("Vertical") < -0.5f || Input.GetAxis("Horizontal") <-0.5f)
            {
                mStamina -= decreaseWhileWalk;
        }
        else
        {
            mStamina += 5f;
        }

            mStamina = Mathf.Clamp(mStamina, 0, 100);


        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Water>())
            {
                UnderWater = !UnderWater;
            }
        }

        public void Damage(float value)
        {

            mHealth -= value;
        }

        IEnumerator ResetGame()
        {
            Debug.Log("Reseting game.... ");
            yield return new WaitForSeconds(.5f);
            SceneManager.LoadScene(0);
        }

    }

