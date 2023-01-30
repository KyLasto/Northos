using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;


public class MovementsPlayer : MonoBehaviour
{
    [SerializeField] private Camera m_MainCamera = null;

    private RaycastHit m_Hit;
    private Ray m_LastRay;
    private NavMeshAgent m_Agent;

    private void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_LastRay = m_MainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(m_LastRay, out m_Hit))
            {
                Debug.Log("Moving");
                m_Agent.SetDestination(m_Hit.point);
            }
        }

        else
        {
            StopMovement();
        }
    }
    
    private void StopMovement()
    {
        if (m_Hit.collider != null)
        {
            Vector2 distance = new Vector2(Mathf.Abs(m_Hit.point.x - transform.position.x), Mathf.Abs(m_Hit.point.z - transform.position.z));
            if (distance.magnitude <= 0.1f)
            {
                m_Agent.isStopped = true;
            }
        }
    }
}
