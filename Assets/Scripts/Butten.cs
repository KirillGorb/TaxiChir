using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Butten : MonoBehaviour
{
    PlayerControler player;

    public int scenName;
    public int scenNameNew;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
    }

    public void PasyOn()
    {
        Time.timeScale = 0;
    }
    public void PasyOff()
    {
        Time.timeScale = 1f;
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
    
    public void RestartsYroven()
    {
        player.Count = PlayerPrefs.GetInt("ManuCount") - player.CountMaint;

        SceneManager.LoadScene(scenNameNew);

        PlayerPrefs.SetInt("ManuCount", player.Count);

    }
}