﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public GameObject Player;
    public TextMeshProUGUI timerText;
    public float TotalSeconds;
    private bool GameOn = true;

    private float CurrentTime;
    private bool GameEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = TotalSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOn)
        {
            if (CurrentTime > 0)
            {
                CurrentTime -= 1 * Time.deltaTime;
                timerText.text = CurrentTime.ToString("f0");
            }
            else
            {
                if(GameEnded != true)
                {
                    gameObject.SendMessage("GameOver");
                    GameEnded = true;
                }
            }
        }
    }

    public void EndGame()
    {
        GameOn = false;
    }

}
