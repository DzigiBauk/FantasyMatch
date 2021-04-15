using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InterfaceManager : MonoBehaviour
{
    public Canvas debug;

    public Canvas _gameOver;
    public static Canvas gameOver;

    public static Button pauseButton;
    public Button _pauseButton;

    public Sprite playButton1;
    public Sprite playButton2;

    public Sprite pauseButton1;
    public Sprite pauseButton2;

    public TextMeshProUGUI coinText;

    public TextMeshProUGUI physicalText;
    public TextMeshProUGUI magicText;
    public TextMeshProUGUI holyText;

    public TextMeshProUGUI debugSpeed;
    public TextMeshProUGUI debugSensitivity;

    public TextMeshProUGUI debugPhysical;
    public TextMeshProUGUI debugMagic;
    public TextMeshProUGUI debugHoly;

    bool paused = false;

    void Start()
    {
        gameOver = _gameOver;

        debug.enabled = false;
        gameOver.enabled = false;

        pauseButton = _pauseButton;
    }
    void Update()
    {
        //Update UI
        updateHealth();
        updateDebug();

        coinText.text = Player.coins.ToString();

        //Input for Debug Window
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (debug.enabled == false)
            {
                debug.enabled = true;
            } else
            {
                debug.enabled = false;
            }
        }
    }

    public void updateHealth()
    {
        //Function for updating Health UI
        physicalText.text = Player.physicalHlt.ToString();
        magicText.text = Player.magicHlt.ToString();
        holyText.text = Player.holyHlt.ToString();
    }

    public void updateDebug()
    {
        //Function for updating Debug UI
        debugSpeed.text = Player.speed.ToString();
        debugSensitivity.text = Player.sensitivity.ToString();

        debugPhysical.text = Player.physicalHlt.ToString();
        debugMagic.text = Player.magicHlt.ToString();
        debugHoly.text = Player.holyHlt.ToString();
    }

    public void pauseGame()
    {
        //Pause function
        if (!paused)
        {
            paused = true;
            Time.timeScale = 0;
            SoundManager.run.Stop();

            pauseButton.image.sprite = playButton1;
        } else
        {
            paused = false;
            Time.timeScale = 1;
            SoundManager.playRun();
            pauseButton.image.sprite = pauseButton1;
        }
    }

    public void showDebug()
    {
        if (debug.enabled == false)
        {
            debug.enabled = true;
        }
        else
        {
            debug.enabled = false;
        }
    }

    public void Restart()
    {
        gameController.planes.Clear();
        gameController.objects.Clear();

        InstantiatePL.position = Vector3.zero;

        SceneManager.LoadScene("SampleScene");

        Time.timeScale = 1;   
    }

    

    public static void showGameOver()
    {
        gameOver.enabled = true;
    }

    //Static pause function
    public static void disablePause()
    {
        pauseButton.enabled = false;
    }

    
}
