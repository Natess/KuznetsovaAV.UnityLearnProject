using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyWaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    public bool OnPatrol = true;

    int m_CurrentWaypointIndex;

    void Start ()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update ()
    {
        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance && OnPatrol)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination (waypoints[m_CurrentWaypointIndex].position);
        }
    }

    internal void ContinuePatrol()
    {
        OnPatrol = true;
        navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
    }
}
