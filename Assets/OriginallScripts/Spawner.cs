using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject snow;

    public float timeSpawn;

    public int countSnowTheTimeRendering;

    public Vector3 snowGranMax;
    public Vector3 snowGranMin;

    private void Start()
    {
        StartCoroutine(spawnerSnow());
    }

    IEnumerator spawnerSnow()
    {
        while (true)
        {
            for (int i = 0; i <= countSnowTheTimeRendering; i++) 
            {
                Instantiate(snow, new Vector3(Random.Range(snowGranMax.x, snowGranMin.x), snowGranMax.y, Random.Range(snowGranMax.z, snowGranMin.z)), Quaternion.identity);
            }

            yield return new WaitForSeconds(timeSpawn);
        }
    }
}
