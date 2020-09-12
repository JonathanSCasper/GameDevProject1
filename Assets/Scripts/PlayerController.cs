using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.ComponentModel;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float speed = 15;
    public float jumpForce = 5;
    public int scoreToWin = 8;
    public TextMeshProUGUI countText;
    public GameObject WinTextObject;
    public GameObject LoseTextObject;
    public GameObject NextLevelButton;
    public GameObject RestartButton;
    public GameObject MainMenuButton;
    public ParticleSystem Collect;
    public ParticleSystem PoweredUp;
    public bool isOnGround = true;

    private Rigidbody rb;
    private PlayerActionControls playerActionControls;
    private int count;
    private float movementX;
    private float movementY;
    private bool isGameOn = true;

    private void Awake()
    {
        playerActionControls = new PlayerActionControls();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        WinTextObject.SetActive(false);
        LoseTextObject.SetActive(false);
        NextLevelButton.SetActive(false);
        RestartButton.SetActive(false);
        MainMenuButton.SetActive(false);
        PoweredUp.Pause();

        playerActionControls.Player.Jump.performed += _ => Jump();
        playerActionControls.Player.Restart.performed += _ => MainMenu();
        playerActionControls.Player.JumpLevel1.performed += _ => JumpLevel1();
        playerActionControls.Player.JumpLevel2.performed += _ => JumpLevel2();
        playerActionControls.Player.JumpLevel3.performed += _ => JumpLevel3();
        playerActionControls.Player.JumpLevel4.performed += _ => JumpLevel4();

    }
    private void OnEnable()
        {
            playerActionControls.Enable();
        }
    private void OnDisable()
        {
            playerActionControls.Disable();
        }

    void FixedUpdate()
    {
        if(isOnGround)
        {
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);
            rb.AddForce(movement * speed);
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void Jump()
    {
        if (isOnGround)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isGameOn)
        {
            if (other.gameObject.CompareTag("PickUp"))
            {
                other.gameObject.SetActive(false);
                count++;
                SetCountText();
            }
            //This is so when coming in contact with a block the isOnGround bool doesn't turn true
            if (other.gameObject.CompareTag("Ground"))
            {
                isOnGround = true;
            }

            if(other.gameObject.CompareTag("SpeedBoost"))
            {
                other.gameObject.SetActive(false);
                speed = 30;
                Collect.Play();
                PoweredUp.Play();
                StartCoroutine("StopSpeedBoost");
            }
            if (count >= scoreToWin)
            {
                WinGame();
            }
        }
        
    }

    IEnumerator StopSpeedBoost()
    {
        yield return new WaitForSeconds(5);
        PoweredUp.Stop();
        speed = 15;
    }
    // So the player cannot roll off a block and jump mid-air
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
    }
    private void WinGame()
    {
        WinTextObject.SetActive(true);
        isGameOn = false;
        gameObject.SendMessage("EndGame");

        NextLevelButton.SetActive(true);
        MainMenuButton.SetActive(true);
    }
    public void GameOver()
    {
        LoseTextObject.SetActive(true);
        isGameOn = false;
        RestartButton.SetActive(true);
        MainMenuButton.SetActive(true);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Level2");
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("Level1");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void JumpLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    private void JumpLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    private void JumpLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
    private void JumpLevel4()
    {
        SceneManager.LoadScene("Level4");
    }
}