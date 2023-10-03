using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Statistics")]
    public float happiness = 0;
    public float polution = 0;
    public float money = 0;
    public float time;

    [Header("Modifiers")]
    public float polutionModifier = 0;
    public float happinessModifier = 0;
    public float moneyModifier = 0;

    [Header("UI References")]
    public TextMeshProUGUI MoneyUI;
    public TextMeshProUGUI HappyUI;
    public TextMeshProUGUI PolutionUI;
    public TextMeshProUGUI TimeUI;

    private bool gameOver = false;

    private void FixedUpdate()
    {
        CalcHappiness();
        CalcMoney();
        CalcPolution();
        CheckGameStatus();
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
}
