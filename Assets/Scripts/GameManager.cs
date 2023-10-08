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
    public float timeInSeconds = 10f; //The countdown time in seconds, before the game ends

    [Header("Modifiers")]
    public float polutionModifier = 0;
    public float happinessModifier = 0;
    public float moneyModifier = 0;

    [Header("UI References")]
    public TextMeshProUGUI MoneyUI;
    public TextMeshProUGUI HappyUI;
    public TextMeshProUGUI PolutionUI;
    public TextMeshProUGUI TimeUI;

    [Header("Bar References")]
    public BarScript barScript;

    private bool gameOver = false;
    [SerializeField] private bool isGame = false; //Boolean for whether the game is actively playing or not

    public void Start()
    {
        barScript.SetTimeBar(timeInSeconds); //Setting the Time Bar to the TimeInSeconds variable
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
    
    private void FixedUpdate()
    {
        CalcHappiness();
        CalcMoney();
        CalcPolution();
        CheckGameStatus();       
    }

    private void Update()
    {
        if (isGame) //If game is playing
        {
            timeInSeconds -= Time.deltaTime; //Substract time from timeInSeconds
            barScript.UpdateTimeBar(timeInSeconds); //Update Time Bar

            if (timeInSeconds <= 0) 
            {
                timeInSeconds = 0;
                isGame = false;
                YouWin();
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleGamePause();
        }
    }

    private void CalcHappiness()
    {
        happiness = happiness + (happinessModifier * 0.1f);
        HappyUI.SetText("Happiness: " + happiness.ToString());
    }
    private void CalcPolution()
    {
        polution = polution + (polutionModifier * 0.1f);
        PolutionUI.SetText("Polution: " + polution.ToString());
    }
    private void CalcMoney()
    {
        money = money + (moneyModifier * 0.1f);
        MoneyUI.SetText("Money: " + money.ToString());
    }

    private void CheckGameStatus() {
        if((money < 0 && moneyModifier <= 0) && !gameOver) {
            gameOver = true;
            Debug.Log("You lost! No more money :(");
        }
    }

    private void YouWin()
    {
        Debug.Log("You Won!");
    }

}
