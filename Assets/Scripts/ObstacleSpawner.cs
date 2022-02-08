using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject BigCactus;
    public GameObject SmallCacti;
    public Transform spawnObstaclePosition;
    private float randomNumber;
    //public float Radius = 1;
    public float timeLeftToNextSpawn;
    public Player player;
    //public Timer timer;
    private GameObject mainCam;
    public float speed = 0.01f;

    
    void increaseSpeed()
    {
        speed = speed + 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindWithTag("MainCamera");
        InvokeRepeating("increaseSpeed", 5, 3);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(timeLeftToNextSpawn);
        if (timeLeftToNextSpawn <= 0)
        {
            SpawnObjectAtRandom();
            timeLeftToNextSpawn = 3;
        } 
        timeLeftToNextSpawn -= Time.deltaTime;
    }

    void SpawnObjectAtRandom()
    {
        //Vector3 randomPos = Random.insideUnitCircle * Radius;
        randomNumber = Random.Range(0,2);
        if (randomNumber%2 == 0)
        {
            Instantiate(BigCactus, new Vector2(spawnObstaclePosition.position.x, spawnObstaclePosition.position.y + Random.Range(0f,0.4f)+0.72f), Quaternion.identity);
        }

        else
        {
            Instantiate(SmallCacti, new Vector2(spawnObstaclePosition.position.x, spawnObstaclePosition.position.y + Random.Range(0.2f,0.5f)+1.0f), Quaternion.identity);
        }
    }
}
