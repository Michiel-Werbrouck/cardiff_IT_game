using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText, victoryText;

    private GameObject player;
    private AudioManager audioManager;

    private int score;
    private int amountOfCoins;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioManager = FindObjectOfType<AudioManager>();
        victoryText.gameObject.SetActive(false);
        amountOfCoins = GameObject.FindGameObjectsWithTag("Point").Length;
        Debug.Log(amountOfCoins);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
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
        audioManager.PlayVictorySound();
        victoryText.gameObject.SetActive(true);
        StartCoroutine(RestartScene());
    }
}
