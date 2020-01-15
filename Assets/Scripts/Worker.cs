using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed = 5f;
    public float thresholdToTravel = 1f;

    float distanceToTarget;
    bool isTraveling;

    private void Awake()
    {
        distanceToTarget = 0;
        isTraveling = false;
    }

    private void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

        if (isTraveling || distanceToTarget > thresholdToTravel)
        {
            isTraveling = true;
            Vector3 moveVector = (target.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime;

            if (distanceToTarget < moveVector.magnitude)
            {
                transform.position = target.transform.position;
                isTraveling = false;
            }
            else
            {
                transform.position += moveVector;
            transform.LookAt(target.transform.position);
            }
        }
    }
}
