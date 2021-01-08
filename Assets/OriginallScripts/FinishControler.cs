using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishControler : MonoBehaviour
{
    public int numberScen;

    public GameObject PanelFinish;

    public Text txtx;

    PlayerControlerA pl;
    PlayerMove plm;

    private void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControlerA>();
        plm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("ScenOctack", numberScen + 1);

            plm.speed = 0f;
            plm.SpeedRot = 0f;

            PanelFinish.SetActive(true);
            txtx.text = "" + pl.CountMaint.ToString() + "Cookie";
        }
    }
}
