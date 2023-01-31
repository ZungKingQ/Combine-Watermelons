using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Text ScoreText;

    public static UIManager Instance;

    private int Score;
    public int Score1
    {
        get => Score; 
        set { Score = value; UpdateScoreText(Score); }
    }
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        ScoreText = transform.Find("ScoreText").GetComponent<Text>();
        Score = 0;
    }

    void Update()
    {
        
    }
    void UpdateScoreText(int Score)
    {
        ScoreText.text = Score.ToString();
    }
}
