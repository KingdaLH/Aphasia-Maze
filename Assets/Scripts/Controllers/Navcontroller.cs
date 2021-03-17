using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;

public class Navcontroller : MonoBehaviour
{
    //general variables
    //[SerializeField] private Camera cam;
    [SerializeField] private float lookRadius = 10f;
    private Transform target;
    public NavMeshAgent agent;
    
    //variables for the waypoint system
    private string state = "patrol";
    public GameObject[] waypoints;
    private int currentWP = 0;
    private float rotSpeed = 0.2f;
    private float speed = 1.5f;
    private float accuracyWP = 5.0f;
    private float direction;

    //start method
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }


    // Update is called once per frame
    void Update()
    {
        /*raycast for enemy movement
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //move agent
                agent.SetDestination(hit.point);
            }
        }*/

        //Makes the enemy chase the player
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
        }

        if (distance <= agent.stoppingDistance)
        {
            //attack the target
            //face the target
            FaceTarget();
        }
        
        //code for the waypoint system
        //Vector3 direction = transform.position - this;
        if (state == "patrol" && waypoints.Length > 0)
        {
            if (Vector3.Distance(waypoints[currentWP].transform.position, transform.position) <accuracyWP)
            {
                currentWP++;
                if (currentWP >= waypoints.Length)
                {
                    currentWP = 0;
                }
            }
            //rotate towards waypoint
            //direction = waypoints[currentWP].transform.position - transform.position;
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    // GIZMOSHey
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}

 