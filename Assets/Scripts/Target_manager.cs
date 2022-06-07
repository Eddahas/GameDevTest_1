using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_manager : MonoBehaviour
{
    [SerializeField]
    private Player_controller player;

    private GameObject[] enemies;

    int enemyInd = 0;


    public void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void Update()
    {
        clckTrgt();
    }

    private void clckTrgt()
    {
        //If you wan't to choose tagets buy mouse click (used this for debug)
        //if (Input.GetMouseButtonDown(0))
        //{
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    Physics.Raycast(ray, out hit);

        //    if (hit.collider != null && hit.collider.gameObject.tag == "Enemy")
        //    {
        //        player.MyTrgt = hit.transform;
        //        //Debug.Log("Target " + player.MyTrgt.parent.name);
        //    } 

        //    else
        //    {
        //        player.MyTrgt = null;
        //    }
        //}


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (enemyInd == enemies.Length - 1)
            {
                enemyInd = 0;
            }
            else
            {
                enemyInd++;
            }
            player.MyTrgt = enemies[enemyInd].transform;
        }
    }

}
