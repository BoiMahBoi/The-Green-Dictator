using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private GameManager gameManager;

    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void Purchase(float price, float happyMod, float poluMod, float moneyMod)
    {
        gameManager.money = gameManager.money - price;
        gameManager.happinessModifier = gameManager.happinessModifier + happyMod;
        gameManager.polutionModifier = gameManager.polutionModifier + poluMod;
        gameManager.moneyModifier = gameManager.moneyModifier + moneyMod;
    }
}
