using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{

    public GameObject PanelGameOver;
    public GameObject EvectChild;
    public GameObject EvectSnow;
    public GameObject snowSlip;
    public GameObject PlayerUpOut;
    public GameObject textStartGame;

    public GameObject audioSnow;
    public GameObject audioCut;

    public GameObject[] SpawnPoints;
    
    public bool[] SpawnPointsOff;

    public VariableJoystick Jostick;

    public float startTimeSpawn;

    public float speed;
    public float rotateSpeed;

    public int Count = 0;
    public int CountMaint = 0;

    public Text textCount;

    bool isFill;
    bool isStart = true;

    float timeSpawn;
    
    Rigidbody rd;

    private void Start()
    {

        rd = GetComponent<Rigidbody>();

        Time.timeScale = 0f;
        timeSpawn = startTimeSpawn;
        timeSpeedRun = startTimeSpeedRun;
    }
    private void Update()
    {
        if (isStart == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1f;

                textStartGame.SetActive(false);

                isStart = false;
            }
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        rd.angularVelocity = new Vector3(rd.angularVelocity.x, Jostick.Horizontal * rotateSpeed, rd.angularVelocity.z);

        if (transform.position.y < -2.83f)
        {
            Count = PlayerPrefs.GetInt("ManuCount") - CountMaint;

            RectScens(GameObject.FindGameObjectWithTag("Finish").GetComponent<Butten>().scenNameNew);

            PlayerPrefs.SetInt("ManuCount", Count);
        }

        textCount.text = "Many: " + PlayerPrefs.GetInt("ManuCount");

        if (isFill) 
        {
            if (timeSpawn <= 0)
            {
                snowSlip.SetActive(false);

                timeSpawn = startTimeSpawn;

                isFill = false;
            }
            else
            {
                timeSpawn -= Time.deltaTime;
            }
        }
    }
    public float speedRun;

    public float startTimeSpeedRun;
    float timeSpeedRun;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpeedRun"))
        {
            if (timeSpeedRun > 0)
            {
                timeSpeedRun -= 0.2f;
                speed += speedRun;
            }
            else if(timeSpeedRun <= 0)
            {
                timeSpeedRun = startTimeSpeedRun;
                speed -= speedRun;
            }
        }
        if (other.CompareTag("Shouse"))
        {
            snowSlip.SetActive(true);
            isFill = true;

            Instantiate(audioSnow, transform.position, Quaternion.identity);
            Instantiate(EvectSnow, other.transform.position, Quaternion.identity);

            Destroy(other.gameObject, 0.2f);
        }
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

                    break;
                }
            }

            PlayerPrefs.SetInt("ManuCount", Count);
        }
        if (other.CompareTag("Finish"))
        {
            PlayerPrefs.SetInt("ScenOctack", other.gameObject.GetComponent<Butten>().scenName);

            RectScens(other.gameObject.GetComponent<Butten>().scenName);
        }
        if (other.CompareTag("Kill"))
        {
            Count = PlayerPrefs.GetInt("ManuCount") - CountMaint;

            Time.timeScale = 0f;
            PanelGameOver.SetActive(true);

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

                            break;

                        }
                    }
                    break;
                }
            }

            if (CountMaint <= 0)
            {
                Time.timeScale = 0f;
                PanelGameOver.SetActive(true);
            }
        }
    }

    void RectScens(int numberScen)
    {
        SceneManager.LoadScene(numberScen);
    }
}