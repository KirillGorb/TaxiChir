using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dest : MonoBehaviour
{
    public float timeLive;

    void Start()
    {
        Destroy(this.gameObject, timeLive);
    }
}
