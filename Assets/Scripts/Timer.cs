using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text txtTim;

    public GameObject BT;

    public float timeSecond;
    public int countTimers;

    private void Start()
    {
        StartCoroutine(timers());
    }

    IEnumerator timers()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeSecond);
            countTimers++;

            txtTim.text = "" + countTimers.ToString();

            if (countTimers <= 0)
            {
                BT.SetActive(false);
            }
        }
    }
}
