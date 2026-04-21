using UnityEngine.AI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AI : MonoBehaviour
{
    NavMeshAgent agent;
    public float Deg;

        public float radius;
    [Range(0,360)]
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;


     void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        StartCoroutine(FOVRoutine());

    }
    
    void Update()
    {
        /*Vector3 dir = playerRef.transform.position - transform.position;
       if(Mathf.Abs(Vector3.Angle(transform.forward, dir)) <Deg && canSeePlayer)
       {
        agent.SetDestination(playerRef.transform.position);
       }*/
       if(canSeePlayer){
        agent.SetDestination(playerRef.transform.position);
       }
       else{
        agent.SetDestination(this.gameObject.transform.position);
       }
    }

     private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;

                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }

     private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

}