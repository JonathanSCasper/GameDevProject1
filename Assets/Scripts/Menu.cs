using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject StartButton;
    public GameObject OptionsButton;
    public GameObject LeaderboardButton;
    public GameObject BackButton;
    public GameObject Title;
    public GameObject OptionsText;
    public LeaderBoard leaderBoard;
    public TextMeshProUGUI LeaderboardText;
    public GameObject NameText;
    public TMP_InputField InputName;
    public GameObject PlayButton;

    // Start is called before the first frame update
    void Start()
    {
        BackButton.SetActive(false);
        OptionsText.SetActive(false);
        LeaderboardText.gameObject.SetActive(false);
        NameText.SetActive(false);
        InputName.gameObject.SetActive(false);
        PlayButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        if (InputName.text != "")
        {
            LeaderBoard.currentName = InputName.text;
        }
        else
        {
            LeaderBoard.currentName = "Baller";
        }
        SceneManager.LoadScene("Level1");
    }

    public void DisplayOptions()
    {
        StartButton.SetActive(false);
        OptionsButton.SetActive(false);
        LeaderboardButton.SetActive(false);
        Title.SetActive(false);

        OptionsText.SetActive(true);
        BackButton.SetActive(true);
    }

    public void DisplayLeaderboard()
    {
        StartButton.SetActive(false);
        OptionsButton.SetActive(false);
        LeaderboardButton.SetActive(false);
        Title.SetActive(false);

        LeaderboardText.text = leaderBoard.DisplayScores();

        LeaderboardText.gameObject.SetActive(true);
        BackButton.SetActive(true);
    }

    public void GoBack()
    {
        StartButton.SetActive(true);
        OptionsButton.SetActive(true);
        LeaderboardButton.SetActive(true);
        Title.SetActive(true);

        OptionsText.SetActive(false);
        BackButton.SetActive(false);
        LeaderboardText.gameObject.SetActive(false);
        NameText.SetActive(false);
        InputName.gameObject.SetActive(false);
        PlayButton.SetActive(false);
    }

    public void PressStart()
    {
        StartButton.SetActive(false);
        OptionsButton.SetActive(false);
        LeaderboardButton.SetActive(false);
        Title.SetActive(false);

        BackButton.SetActive(true);
        NameText.SetActive(true);
        InputName.gameObject.SetActive(true);
        PlayButton.SetActive(true);
    }
}
