using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Statistics")]
    public float happiness = 0;
    public float polution = 0;
    public float money = 0;
    public float timeInSeconds = 360f; //The countdown time in seconds, before the game ends (Each second is a month)
    public float score;

    [Header("Modifiers")]
    public float polutionModifier = 0;
    public float happinessModifier = 0;
    public float moneyModifier = 0;
    public float inGameTimeSpeed = 1; //In game seconds per real world second.

    [Header("UI References")]
    public TextMeshProUGUI MoneyUI;
    public TextMeshProUGUI HappyUI;
    public TextMeshProUGUI PolutionUI;
    public TextMeshProUGUI TimeUI;
    public GameObject ClockShort;
    public GameObject ClockLong;

    [Header("Score")]
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighscoreText;
    public GameObject ScoreMenu;

    [Header("Pause Button")]
    public UnityEngine.UI.Button PauseButton;
    public Sprite ResumeIcon;
    public Sprite PauseIcon;

    [Header("Script References")]
    public BarScript barScript;
    public HappyBarScript happyBarScript;
    public PoluBarScript poluBarScript;
    public Calendar calendar;

    private bool gameOver = false;
    [SerializeField] private bool isGame = false; //Boolean for whether the game is actively playing or not

    public void Start()
    {
        ScoreMenu.SetActive(false);
        barScript.SetTimeBar(timeInSeconds); //Setting the Time Bar to the TimeInSeconds variable
        happyBarScript.UpdateHappyBar(happiness); //Setting the Happy Bar to the happiness variable
        StartGame(); //Called in Start() since there is no start button yet
    }

    public void StartGame() //Function that starts game 
    {
        isGame = true;
    }


    public void ToggleGamePause() //Function that pauses and unpauses game
    {
        isGame = !isGame;
        
        if(isGame)
        {
            PauseButton.image.sprite = PauseIcon;
        } else
        {
            PauseButton.image.sprite = ResumeIcon;
        }
    }

    private void Update()
    {
        if (isGame) //If game is playing
        {
            timeInSeconds -= Time.deltaTime * inGameTimeSpeed; //Substract time from timeInSeconds
            barScript.UpdateTimeBar(timeInSeconds); //Update Time Bar

            ClockLong.transform.Rotate(-Vector3.forward * 360 * Time.deltaTime * inGameTimeSpeed);
            ClockShort.transform.Rotate((-Vector3.forward * 360 * Time.deltaTime * inGameTimeSpeed) / 12);


            CalcHappiness();
            CalcMoney();
            CalcPolution();
            CheckGameStatus();

            if ((int)(timeInSeconds % 12) != calendar.MonthCount)
            {
                CalcCalendar();
            }

            if (timeInSeconds <= 0) 
            {
                timeInSeconds = 0;

                if (polution > 0)
                {
                    StartCoroutine(EndGame("You lost! You didn't go carbon neutral in time. Your final score was:" + score.ToString()));
                } else
                {
                    StartCoroutine(EndGame("Congratulations, you won! You went carbon neutral! Your final score was:" + score.ToString()));
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Space)) //Pause and Unpause game when pressing P or Space
        {
            ToggleGamePause();
        }
    }

    private void CalcCalendar()
    {
        calendar.NewMonth((int)(timeInSeconds % 12));
    }

    private void CalcHappiness()
    {
        happiness = happiness + (happinessModifier * Time.deltaTime * inGameTimeSpeed);
        happyBarScript.UpdateHappyBar(happiness);
    }

    private void CalcPolution()
    {
        polution = polution + (polutionModifier * Time.deltaTime * inGameTimeSpeed);
        poluBarScript.UpdatePoluBar(polution);
    }

    private void CalcMoney()
    {
        money = money + (moneyModifier * Time.deltaTime * inGameTimeSpeed);
        MoneyUI.SetText("DKK: " + ((int)(money)).ToString());
    }

    private void CalcScore()
    {
        score = ((1000 + (money/20)) - ((polution) + (timeInSeconds) + (happiness)) / 10);
        if(PlayerPrefs.GetFloat("Highscore") < score)
        {
            PlayerPrefs.SetFloat("Highscore", score);
        }
    }

    private void CheckGameStatus() {
        if((money <= 0 && moneyModifier <= 0) && !gameOver) {
            StartCoroutine(EndGame("You lost! No more money left in the bank. Your final score was: "));
        }

        if ((happiness >= 100 && happinessModifier >= 0) && !gameOver)
        {
            StartCoroutine(EndGame("You lost! The people rebelled against you! Your final score was: "));
        }
    }

    private IEnumerator EndGame(string endMessage)
    {
        CalcScore();
        ToggleGamePause();
        gameOver = true;
        string scoreMessage = endMessage + score.ToString();
        ScoreText.SetText(scoreMessage);
        string highscoreMessage = "Highscore: " + PlayerPrefs.GetFloat("Highscore").ToString();
        HighscoreText.SetText(highscoreMessage);
        ScoreMenu.SetActive(true);
        yield return new WaitForSeconds(1);
    }



    // Methods for the scoreMenu buttons.
    public void TryAgain()
    {
        SceneManager.LoadScene("Game");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }





}
