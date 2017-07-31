using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace ZombieRun
{

    public enum Actions
    {
        Idle, Walking, Running, Attacking, Hit, Dead
    }

    [RequireComponent(typeof(NavMeshAgent))]
    public class MonsterAI : MonoBehaviour
    {

        private NavMeshAgent agent;
        public float speed = 16.0f;
        public float minDistanceToAttack = 4;
        public float minDistanceToFollow;
        [SerializeField]
        public Actions curAction;
        public float distance;

        public float TimeTillEatPlayer;
        private Monster mMonster;
        private IsVisibleOrNot mVisibleByCameraScript;
        private bool mVisibleByCamera;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            curAction = Actions.Walking;
            agent.stoppingDistance = minDistanceToFollow;
            mMonster = GetComponent<Monster>();
            mVisibleByCameraScript = GetComponentInChildren<IsVisibleOrNot>();
        }

        void Update()
        {

            mVisibleByCamera = mVisibleByCameraScript.IsVisibleByPlayer;

            distance = Vector3.Distance(PlayerManager.Instance.GetPlayer().transform.position, transform.position);
            if (distance <= minDistanceToAttack)
            {
                curAction = Actions.Attacking;
            }else if (distance > minDistanceToFollow)
            {
                mMonster.TurnAndLookTarget();
                curAction = Actions.Walking;
            }

            if (mVisibleByCamera)
            {
                curAction = Actions.Idle;
            }
         

                switch (curAction)
            {
                case Actions.Idle:
                    Idle();
                    break;
                case Actions.Walking:
                    Chase();
                    break;
                case Actions.Running:
                    break;
                case Actions.Attacking:
                    Attack();
                    break;
                case Actions.Hit:
                    break;
                case Actions.Dead:
                    break;
                default:
                    break;
            }
        }

        void Idle()
        {
            agent.SetDestination(transform.position);
        }

        void Chase()
        {
            mMonster.SetAttackPlayer(false);
            agent.SetDestination(PlayerManager.Instance.GetPlayer().transform.position);
        }

        void Attack()
        {
            agent.SetDestination(transform.position);
            TimeTillEatPlayer += .1f * Time.deltaTime;
            mMonster.SetAttackPlayer(true);
        }
    }
}
