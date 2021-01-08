using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveGuste : MonoBehaviour
{
    public LayerMask whatCanGo;

    public Vector3 movers;

    NavMeshAgent myAgent;

    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Ray myRay = Camera.main.ScreenPointToRay(movers);
        RaycastHit hit;

        if (Physics.Raycast(myRay, out hit, whatCanGo))
        {
            myAgent.SetDestination(hit.point);
        }
    }
}
