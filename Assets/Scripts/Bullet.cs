using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed, rotateSpeed;

    [SerializeField]
    private int dmg;

    public Transform MyTarget { get; private set; }
    public int Dmg { get => dmg; }

    [SerializeField]
    private GameObject explo;

    void Update()
    {
        Vector3 direction = MyTarget.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag== "Enemy") //if we want bullets to be destroyed only due contact with own target add "&& collision.transform == MyTarget"
        {
            Destroy(gameObject);
            speed = 0;

            Debug.Log(dmg + " dmg recived");
            Instantiate(explo, transform.position, Quaternion.identity);

        }
    }

    public void Initialize(Transform target)
    {
        this.MyTarget = target;
    }
}
