using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public int score, lives;
    public TextMeshProUGUI scoreText, livesText;

    private void Start()
    {
        scoreText.text = $"Score:{score.ToString("D4")}";
        livesText.text = $"lives:{lives}";
    }
    void Awake()
    {
        lives = 3;
        score = 0;
        CreateInstance();
    }
    void CreateInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddScore()
    {
        score++;
        scoreText.text = $"Score:{score}";
    }

    public void DecareseLives()
    {
        lives--;
        livesText.text = $"Score:{lives}";
    }
}
