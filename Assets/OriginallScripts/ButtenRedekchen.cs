using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtenRedekchen : MonoBehaviour
{
    FinishControler fin;

    private void Start()
    {
        fin = GameObject.FindGameObjectWithTag("Finish").GetComponent<FinishControler>();
    }

    public void PayseStart()
    {
        Time.timeScale = 0f;
    }
    public void PayseRestart()
    {
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        SceneManager.LoadScene(fin.numberScen);
        Time.timeScale = 1f;
    }
    public void Exites()
    {
        Application.Quit();
    }
    public void Continye()
    {
        GetComponent<PlayerMove>().speed = 9f;
        GetComponent<PlayerMove>().SpeedRot = 0.5f;

        GetComponent<PlayerMove>().transform.position = new Vector3(
        GetComponent<PlayerMove>().transform.position.x,
        GetComponent<PlayerMove>().transform.position.y,
        GetComponent<PlayerMove>().transform.position.z - 34f);
    }
    public void Skip()
    {
        SceneManager.LoadScene(fin.numberScen + 1);
    }
    public void StartPlay()
    {
        SceneManager.LoadScene(1);

        if (PlayerPrefs.HasKey("ScenOctack") == true)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("ScenOctack"));
        }
        if (PlayerPrefs.HasKey("ScenOctack") == false)
        {
            SceneManager.LoadScene(1);
        }
    }
}
