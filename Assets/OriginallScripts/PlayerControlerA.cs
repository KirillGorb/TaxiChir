using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControlerA : MonoBehaviour
{
    public GameObject[] SpawnPoints;

    public bool[] SpawnPointsOff;

    public Text textCount;

    public int Count = 0;
    public int CountMaint = 0;

    public GameObject PlayerUpOut;
    public GameObject EvectChild;
    public GameObject audioCut;
    public GameObject PanelGameOver;

    bool isStart = false;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    private void Update()
    {

        if (isStart == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isStart = true;
                Time.timeScale = 1f;
            }
        }
        if (transform.position.y <= -7f)
        {
            SceneManager.LoadScene(0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Child"))
        {
            Count = PlayerPrefs.GetInt("ManuCount");
            Count++;
            CountMaint++;

            Instantiate(EvectChild, other.transform.position, Quaternion.identity);

            Destroy(other.gameObject);

            for (int i = 0; i < SpawnPoints.Length; i++)
            {
                if (SpawnPointsOff[i] == false)
                {
                    SpawnPointsOff[i] = true;
                    Instantiate(PlayerUpOut, SpawnPoints[i].transform);
                    Instantiate(audioCut, transform.position, Quaternion.identity);

                    textCount.text = "" + Count.ToString();

                    break;
                }
            }

            PlayerPrefs.SetInt("ManuCount", Count);
        }
        if (other.CompareTag("NonChild"))
        {
            for (int i = 0; i < SpawnPoints.Length; i++)
            {
                if (SpawnPointsOff[i] == true)
                {
                    SpawnPointsOff[i] = false;

                    Count = PlayerPrefs.GetInt("ManuCount");
                    Count--;
                    CountMaint--;

                    PlayerPrefs.SetInt("ManuCount", Count);

                    if (SpawnPoints[i].transform.childCount > 0)
                    {
                        foreach (Transform child in SpawnPoints[i].transform)
                        {
                            Destroy(child.gameObject);

                            textCount.text = "" + Count.ToString();

                            break;

                        }
                    }
                    break;
                }
            }
            if (CountMaint <= 0)
            {
                GetComponent<PlayerMove>().speed = 0f;
                GetComponent<PlayerMove>().SpeedRot = 0f;
                PanelGameOver.SetActive(true);
            }
        }
    }
}
