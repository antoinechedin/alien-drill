using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minecart : MonoBehaviour
{
    public float moveSpeed = 5;
    public float fallSpeed = 0.4f;
    public Vector3 target;

    public List<Plank> listPlank;
    public Rail rail1;
    public Rail rail2;


    private void Update()
    {
        if (transform.position.y < 1.52f) transform.position = new Vector3(transform.position.x, 1.52f, transform.position.z);
        if (transform.position.y > 1.52f) transform.position -= fallSpeed * Vector3.up;

        if (transform.position == target)
        {
            foreach (Plank p in listPlank)
            {
                p.goUnderground = true;
                Destroy(p.gameObject, 2f);
            }
            rail1.goUnderground = true;
            rail2.goUnderground = true;
            Destroy(rail1.gameObject, 2f);
            Destroy(rail2.gameObject, 2f);
            Destroy(gameObject);
        }
        else if (transform.position.y == 1.52f) TravelTo(target);
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
