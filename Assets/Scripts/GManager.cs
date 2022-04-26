using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private int score;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    public void IncreaseScore()
    {
        score++;
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
    }
}
