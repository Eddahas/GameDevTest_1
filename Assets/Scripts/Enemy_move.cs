using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_move : MonoBehaviour
{
    [SerializeField]
    private GameObject[] waypoints;
    private int currentWayPointInd = 0;

    [SerializeField]
    private float speed, rotateSpeed;

    private Transform target;

    private void Update()
    {
        target = waypoints[currentWayPointInd].transform;
        if(target != null)
        {
            if (Vector3.Distance(target.position, transform.position) < 0.1f)
            {              
                currentWayPointInd++;
                if (currentWayPointInd >= waypoints.Length)
                {
                    currentWayPointInd = 0;
                    System.Array.Reverse(waypoints);
                }

            }

        }
        Vector3 direction = target.position-transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);

        transform.Translate(Vector3.forward*Time.deltaTime*speed);

    }
}
