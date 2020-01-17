using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minecart : MonoBehaviour
{
    public float moveSpeed = 5;
    public Vector3 target;

    private void Update()
    {
        if (transform.position == target) Destroy(gameObject);
        else TravelTo(target);
    }

    private void TravelTo(Vector3 targetPosition)
    {
        Vector3 moveVector = (targetPosition - transform.position).normalized * moveSpeed * Time.deltaTime;
        if (Vector3.Distance(transform.position, targetPosition) < moveVector.magnitude)
        {
            transform.position = targetPosition;
        }
        else
        {
            transform.position += moveVector;
            transform.LookAt(targetPosition);
        }
    }
}
