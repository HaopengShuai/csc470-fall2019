using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public GameObject player;
    private Vector3 xiangliang;




    private void Update()
    {
        xiangliang = player.transform.position - transform.position;
        if (xiangliang.magnitude <= 25)
        {
            transform.LookAt(player.transform);
            transform.Translate(xiangliang * Time.deltaTime * 0.5f);
        }
    }

}
