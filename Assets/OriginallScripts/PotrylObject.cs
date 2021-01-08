using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotrylObject : MonoBehaviour
{
    public GameObject[] pointGo;

    public float speed;
    int i;

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, pointGo[i].transform.position, speed);

        if (transform.position == pointGo[i].transform.position)
        {
            i++;

            if (i == pointGo.Length)
            {
                i = 0;
            }
        }
    }
}
