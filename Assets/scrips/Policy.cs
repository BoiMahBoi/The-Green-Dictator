using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Policy : MonoBehaviour
{
    private GameManager gameManager;

    [Header("Basic Settings")]
    public float price;
    public float moneyMod;
    public float happyMod;
    public float polutionMod;

    private bool isPurchased = false;

    [Header("OnHover Settings")]
    public float executeTime;
    public GameObject infoWindow;
    private float hoverTime = 0f;
    private bool startTimeCount;

    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnMouseDown()
    {
        if (!isPurchased)
        {
            isPurchased = true;
            gameManager.money = gameManager.money - price;
            gameManager.moneyModifier = gameManager.moneyModifier + moneyMod;
            gameManager.happinessModifier = gameManager.happinessModifier + happyMod;
            gameManager.polutionModifier = gameManager.polutionModifier + polutionMod;
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }

    private void OnMouseEnter()
    {
        startTimeCount = true;
    }

    private void OnMouseExit()
    {
        startTimeCount = false;
        hoverTime = 0f;
        infoWindow.SetActive(false);
    }

    private void Update()
    {
        if (startTimeCount)
        {
            hoverTime += Time.deltaTime;

            if (hoverTime > executeTime)
            {
                startTimeCount = false;
                infoWindow.SetActive(true);
            }
        }
    }
}
