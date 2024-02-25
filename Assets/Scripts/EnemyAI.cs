using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;

    public PlayerController player;
    public List<Transform> patrolPoints;
    public float viewAngle;

    void Start()
    {
        InitComponentLinks();
        PickNewAgentPoint();
    }

    void Update()
    {
        NoticePLayerUpdate();
        ChaseUpdate();
        patrolUpdate();
    }

    private void PickNewAgentPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }

    private void patrolUpdate()
    {
        if(!_isPlayerNoticed)
        {
            if(_navMeshAgent.remainingDistance == 0)
            {
                PickNewAgentPoint();
            }
        }
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void NoticePLayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if(hit.collider.gameObject == player.gameObject)
                {
                     _isPlayerNoticed = true;
                }
                
            }
        }
    }

    private void ChaseUpdate()
    {
        if(_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }

}

