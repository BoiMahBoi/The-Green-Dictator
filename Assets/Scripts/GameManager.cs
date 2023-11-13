using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Statistics")]
    public float happiness = 0;
    public float polution = 0;
    public float money = 0;
    public float timeInSeconds = 360f; //The countdown time in seconds, before the game ends (Each second is a month)

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

    [Header("Script References")]
    public BarScript barScript;
    public HappyBarScript happyBarScript;
    public PoluBarScript poluBarScript;
    public Calendar calendar;

    private bool gameOver = false;
    [SerializeField] private bool isGame = false; //Boolean for whether the game is actively playing or not

    public void Start()
    {
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
    }

    private void Update()
    {
        if (isGame) //If game is playing
        {
            timeInSeconds -= Time.deltaTime * inGameTimeSpeed; //Substract time from timeInSeconds
            barScript.UpdateTimeBar(timeInSeconds); //Update Time Bar

            CalcHappiness();
            CalcMoney();
            CalcPolution();
            CheckGameStatus();

            if (timeInSeconds <= 0) 
            {
                timeInSeconds = 0;

                if (polution > 0)
                {
                    StartCoroutine(EndGame("You lost! You didn't go carbon neutral in time."));
                } else
                {
                    StartCoroutine(EndGame("Congratulations, you won! You went carbon neutral!"));
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.P)) //Pause and Unpause game when pressing P
        {
            ToggleGamePause();
        }
    }

    private void CalcHappiness()
    {
        happiness = happiness + (happinessModifier * Time.deltaTime * inGameTimeSpeed);
        happyBarScript.UpdateHappyBar(happiness);
        //HappyUI.SetText("Happiness: " + happiness.ToString());//
    }

    private void CalcPolution()
    {
        polution = polution + (polutionModifier * Time.deltaTime * inGameTimeSpeed);
        poluBarScript.UpdatePoluBar(polution);
        //PolutionUI.SetText("Polution: " + polution.ToString());//
    }

    private void CalcMoney()
    {
        money = money + (moneyModifier * Time.deltaTime * inGameTimeSpeed);
        MoneyUI.SetText("Money: " + money.ToString());
    }

    private void CheckGameStatus() {
        if((money <= 0 && moneyModifier <= 0) && !gameOver) {
            StartCoroutine(EndGame("You lost! No more money left in the bank."));
        }

        if ((happiness <= 0 && happinessModifier <= 0) && !gameOver)
        {
            StartCoroutine(EndGame("You lost! The people rebelled against you!"));
        }
    }

    private IEnumerator EndGame(string endMessage)
    {
        ToggleGamePause();
        gameOver = true;
        Debug.Log(endMessage);
        yield return new WaitForSeconds(1);
    }
}
