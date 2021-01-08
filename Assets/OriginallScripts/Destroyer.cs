using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float startTimeSpawn;
    float TimeSpawn;

    private void Start()
    {
        TimeSpawn = startTimeSpawn;
    }
    void Update()
    {
        if (TimeSpawn <= 0)
        {
            Destroy(this.gameObject);
            TimeSpawn = startTimeSpawn;
        }
        else
        {
            TimeSpawn -= Time.deltaTime;
        }
    }
}
