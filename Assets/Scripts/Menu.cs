using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject StartButton;
    public GameObject OptionsButton;
    public GameObject BackButton;
    public GameObject Title;
    public GameObject OptionsText;

    // Start is called before the first frame update
    void Start()
    {
        BackButton.SetActive(false);
        OptionsText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void DisplayOptions()
    {
        StartButton.SetActive(false);
        OptionsButton.SetActive(false);
        Title.SetActive(false);

        OptionsText.SetActive(true);
        BackButton.SetActive(true);
    }

    public void GoBack()
    {
        StartButton.SetActive(true);
        OptionsButton.SetActive(true);
        Title.SetActive(true);

        OptionsText.SetActive(false);
        BackButton.SetActive(false);
    }
}
