using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public enum GameState
{
    InMenu,
    InProgress,
    Finished
}

public class GManager : MonoBehaviour
{ 
    public TextMeshProUGUI scoreText, victoryText;

    public GameState State;

    private GameObject player;
    private AudioManager audioManager;

    private int score;
    private int amountOfCoins;
    
    void Start()
    {
        State = GameState.InMenu;
        player = GameObject.FindGameObjectWithTag("Player");
        audioManager = FindObjectOfType<AudioManager>();
        victoryText.gameObject.SetActive(false);
        amountOfCoins = GameObject.FindGameObjectsWithTag("Point").Length;
    }

    void Update()
    {
        scoreText.text = "Score: " + score;
        
        if (Input.anyKeyDown && State == GameState.InMenu)
        {
            State = GameState.InProgress;
        }
    }

    public void IncreaseScore()
    {
        score++;
        audioManager.PlayCoinCollected();

        if (score == amountOfCoins)
        {
            Win();
        }
    }

    public void Lose()
    {
        State = GameState.Finished;
        audioManager.PlayDeathSound();
        Destroy(player);
        StartCoroutine(RestartScene());
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Win()
    {
        State = GameState.Finished;
        audioManager.PlayVictorySound();
        victoryText.gameObject.SetActive(true);
        StartCoroutine(RestartScene());
    }
}
