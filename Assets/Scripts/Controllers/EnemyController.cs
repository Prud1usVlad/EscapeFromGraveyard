using Assets.Scripts.Audio;
using Assets.Scripts.EventSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Controllers
{
    /// <summary>
    /// This script will controll behaviour of the enemies (patroll, chase, attack)
    /// </summary>
    public class EnemyController : MonoBehaviour
    {
        private NavMeshAgent agent;

        // Controller state
        private int currentWaypointIdx = 0;
        private Vector3 playerPos = Vector3.zero;
        private float waitTime;
        private bool playerInRange = false;
        private bool playerCought = false;
        private bool patrolling = true;

        // Controller private settings
        [SerializeField]
        private float defaultWaitTime = 2;
        [SerializeField]
        private LayerMask playerMask;
        [SerializeField]
        private LayerMask obstacleMask;
        [SerializeField]
        private AudioController killSound;
        [SerializeField]
        private GameEvent killPlayerEvent;

        [SerializeField]
        private Transform[] waypoints;

        // Moving parameters 
        public float walkSpeed = 2;
        public float runSpeed = 2;

        // Viewing parameters
        public float viewDistance = 5;
        public float viewAngle = 90;

        public Vector3 CurrentWaypointPos 
            => waypoints[currentWaypointIdx].position;

        public void Start()
        {
            waitTime = defaultWaitTime;

            agent = GetComponent<NavMeshAgent>();
            
            agent.SetDestination(CurrentWaypointPos);
            Move(walkSpeed);
        }

        public void Update()
        {
            EnvironmentView();

            if (!patrolling)
            {
                Chasing();
            }
            else
            {
                Patrolling();
            }
        }

        /// <summary>
        /// Patrolling logic
        /// </summary>
        private void Patrolling()
        {
            agent.SetDestination(CurrentWaypointPos);

            // Reached current waypoint
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                // If clause to use timers
                if (waitTime <= 0)
                {
                    NextWaypoint();
                    Move(walkSpeed);
                    waitTime = defaultWaitTime;
                }
                else
                {
                    Stop();
                    waitTime -= Time.deltaTime;
                }
            }
        }

        /// <summary>
        /// Chasing logic
        /// </summary>
        private void Chasing()
        {
            if (!playerCought)
            {
                Move(runSpeed);
                agent.SetDestination(playerPos);
            }
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (waitTime <= 0 && !playerCought)
                {
                    patrolling = true;
                    Move(walkSpeed);
                    waitTime = defaultWaitTime;
                    agent.SetDestination(CurrentWaypointPos);
                }
                else
                {
                    Stop();
                    waitTime -= Time.deltaTime;
                }
            }
        }

        /// <summary>
        /// Update current waypoint with next in charge
        /// </summary>
        public void NextWaypoint()
        {
            currentWaypointIdx = ++currentWaypointIdx % waypoints.Length;
            agent.SetDestination(CurrentWaypointPos);
        }

        /// <summary>
        /// Telling NavMeshAgent to start moving
        /// </summary>
        /// <param name="speed">Speed of the movement</param>
        private void Move(float speed)
        {
            agent.isStopped = false;
            agent.speed = speed;
        }
        /// <summary>
        /// Telling NavMeshAgent to stop moving
        /// </summary>
        private void Stop()
        {
            agent.isStopped = true;
            agent.speed = 0;
        }

        /// <summary>
        /// Logic of catching player
        /// </summary>
        private void CoughtPlayer()
        {
            playerCought = true;
        }

        /// <summary>
        /// Logic of looking for the player inside the enemy FOV
        /// and taking obstacles in account
        /// </summary>
        private void EnvironmentView()
        {
            // Creatig sphere and detecting
            // all colliders in players layer inside 
            Collider[] colliders = Physics
                .OverlapSphere(transform.position, viewDistance, playerMask);

            foreach (Transform player in colliders.Select(c => c.transform))
            {
                var direction = (player.position - transform.position).normalized;
                var distance = Vector3.Distance(transform.position, player.position);

                // If player inside enemy FOV
                if (Vector3.Angle(transform.forward, direction) < viewAngle / 2)
                {
                    // Player in FOV and not covered by obstacles, proceed to chasing
                    if (!Physics.Raycast(transform.position, direction, distance, obstacleMask))
                    {
                        playerInRange = true;
                        patrolling = false;
                    }
                    // Player lost
                    else
                    {
                        playerInRange = false;
                    }
                }
                // Player lost
                if (distance > viewDistance)
                {
                    playerInRange = false;
                }

                // Updating player pos for chasing
                if (playerInRange)
                {
                    playerPos = player.position;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !playerCought)
            {
                CoughtPlayer();
                killPlayerEvent.Raise();
                killSound.PlayRandom();
                Debug.Log("Player dead");
            }
        }
    }
}
