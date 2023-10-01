using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float happiness;
    public float polution;
    public float money;
    public float time;

    public float happinessModifier = 0;
    public float polutionModifier = 0;
    public float moneyModifier = 0;

    private void FixedUpdate()
    {
        CalcHappiness();
        CalcMoney();
        CalcPolution();
    }

    private void CalcHappiness()
    {
        happiness = happiness + (happinessModifier * 0.1f);
    }
    private void CalcPolution()
    {
        polution = polution + (polutionModifier * 0.1f);
    }
    private void CalcMoney()
    {
        money = money + (moneyModifier * 0.1f);
    }
}
