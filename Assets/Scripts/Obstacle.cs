using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject obstacle;
    public Transform target;
    public Camera cam;
    public Player player;
    public GameController gameController;
    private float originalYCoord;
    private float randomNumber;
    private GameObject mainCam;
    private ObstacleSpawner obstacleSpawner;

    void Start()
    {   
        cam = Camera.main;
        mainCam = GameObject.FindWithTag("MainCamera");
        obstacleSpawner = GameObject.FindWithTag("ObstacleSpawner").GetComponent<ObstacleSpawner>();
    //    originalYCoord = obstacle.transform.position.y;
    }


    // Update is called once per frame
    void Update()
    {
        // Moves obstacle to the left
        transform.Translate(Vector2.left * obstacleSpawner.speed * Time.deltaTime);

        // Makes a vector that returns the position of the target
        Vector3 viewPos = cam.WorldToViewportPoint(target.position);

        if (target != null)
        {
            if (viewPos.x >= 1.1F) //Outside cam on right side
            {
            }

            else if (-0.1F <= viewPos.x && viewPos.x <= 1.1F) //On cam
            {
            }

            else if (viewPos.x <= -0.1F) //Outside cam on left side
            {
            //    randomNumber = Random.Range(-0.25f,0.25f);

                // Gets destroyed
                Object.Destroy(this.gameObject);
            }
        }

        else
        {
            return;
        }    
    }
}
