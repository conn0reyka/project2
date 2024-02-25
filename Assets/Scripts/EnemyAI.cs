using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent _navMeshAgent;
    public List<Transform> patrolPoints;

    void Start()
    {
        InitComponentLinks();
        PickNewAgentPoint();
    }

    // Update is called once per frame
    void Update()
    {
        patrolUpdate();
    }

    private void PickNewAgentPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }

    private void patrolUpdate()
    {
    if(_navMeshAgent.remainingDistance == 0)
        {
            PickNewAgentPoint();
        }
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

}
