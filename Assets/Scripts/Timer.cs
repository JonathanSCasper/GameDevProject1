using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static float TotalTime = 0;

    public GameObject Player;
    public TextMeshProUGUI timerText;
    public float TotalSeconds;
    public LeaderBoard leaderBoard;
    private bool GameOn = true;

    private float CurrentTime;

    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = TotalSeconds;
        if (gameObject.scene.name == "Level1")
            TotalTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOn)
        {
            if (CurrentTime > 0)
            {
                CurrentTime -= 1 * Time.deltaTime;
                TotalTime += 1 * Time.deltaTime;
                timerText.text = CurrentTime.ToString("f0");
            }
            else
            {
                gameObject.SendMessage("GameOver");
            }
        }
    }

    public void EndGame()
    {
        GameOn = false;
        if (gameObject.scene.name == "Level4")
        {
            leaderBoard.AddScore(TotalTime);
        }
    }

}
