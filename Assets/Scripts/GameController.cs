using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject retryButton;
    public GameOverScreen GameOverScreen;
    public TitleScreen TitleScreen;
    public Text scoreText;
    public float timer;
    public int points;
    public AudioSource Menu1a;
    public AudioSource Menu1b;
    public AudioSource Menu1c;
    public AudioSource Menu1d;
    public AudioSource jump1a;
    public AudioSource highScore1a;
    public AudioSource gameStart1a;
    public AudioSource gameOver1a;
    public AudioSource menuMusic;
    public AudioSource gameMusic;
    private ObstacleSpawner obstacleSpawner;
    private float menurandChance;

    // Start is called before the first frame update
    void Start()
    {
        // Proof that scene has restarted each time the button is clicked
        print("This scene has been loaded!");
        retryButton = GameObject.FindWithTag("RetryButton");
        menuMusic.GetComponent<AudioSource>().Play();
        ToggleRetryButton();
        Time.timeScale = 0;
        menurandChance = Random.value;
    //    a_Menu1a = GetComponent<AudioSource>(); 
    //    a_Menu1b = GetComponent<AudioSource>(); 
    //    a_Menu1c = GetComponent<AudioSource>(); 
    //    a_Menu1d = GetComponent<AudioSource>(); 
    //    a_jump1a = GetComponent<AudioSource>(); 
    //    a_highScore1a = GetComponent<AudioSource>(); 
    //    a_gameStart1a = GetComponent<AudioSource>(); 
    //    a_gameOver1a = GetComponent<AudioSource>(); 
    //    a_gameMusic = GetComponent<AudioSource>(); 
    //    a_menuMusic = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1)
        {
            timer += Time.deltaTime;
            points = Mathf.RoundToInt(timer);
            scoreText.text = points.ToString();
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        TitleScreen.Setup();
        Time.timeScale = 1;
    }

    public void ToggleRetryButton()
    {
    }

    public void GameOver()
    {
        GameOverScreen.Setup(points);
        scoreText.gameObject.SetActive(false);
        gameMusic.GetComponent<AudioSource>().Stop();
        gameOver1a.GetComponent<AudioSource>().Play();
    }

    public void StartGame()
    {
        menuMusic.GetComponent<AudioSource>().Stop();
        gameStart1a.GetComponent<AudioSource>().Play();
        new WaitForSeconds(5);
        
        TitleScreen.Setup();
        Time.timeScale = 1;
        gameMusic.GetComponent<AudioSource>().Play();
    }
}
