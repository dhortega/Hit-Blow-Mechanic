using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    int playerScore;
    void Start()
    {
        playerScore = 0;
    }

    public int GetScore()
    {
        return playerScore;
    }

    public void SetScore(int score)
    {
        playerScore = score;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(message: $"<size=16><color=green> {GetScore()} </color></size>");
    }
}
