using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Transform shootPnt;

    public Transform MyTrgt { get; set; }

    int enemyInd = 0;

    void Update()
    {
        
        if (MyTrgt != null)
        {
            Vector3 direction = MyTrgt.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }
    }

    public void Shoot()
    {
        Transform CurrentTaget = MyTrgt;

        if (CurrentTaget != null)
        {
            Bullet b = Instantiate(bullet, shootPnt.transform.position, Quaternion.identity).GetComponent<Bullet>();
            b.Initialize(CurrentTaget);
        }

    }
}
