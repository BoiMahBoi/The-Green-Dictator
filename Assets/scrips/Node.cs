using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    private GameManager gameManager;

    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void DeactiveButton(GameObject button)
    {
        button.GetComponent<Button>().interactable = false;
    }
    public void PurchasePrice(float price)
    {
        gameManager.money = gameManager.money - price;
    }

    public void PurchaseHappyMod(float happyMod)
    {
        gameManager.happinessModifier = gameManager.happinessModifier + happyMod;
    }

    public void PurchasePoluMod(float poluMod)
    {
        gameManager.polutionModifier = gameManager.polutionModifier + poluMod;
    }

    public void PurchaseMoneyMod(float moneyMod)
    {
        gameManager.moneyModifier = gameManager.moneyModifier + moneyMod;
    }
}
