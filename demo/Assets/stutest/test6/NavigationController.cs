using UnityEngine;
using UnityEngine.AI;

public class NavigationController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Transform target;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Target").transform;
    }

    private void Update()
    {
        navMeshAgent.SetDestination(target.position);
    }
}