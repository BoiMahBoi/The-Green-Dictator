using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Policy : MonoBehaviour
{
    [Serializable]
    public class Dependency
    {
        public string name;
        public GameObject dependency;
        public bool activated;
        public float moneyDep;
        public float happyDep;
        public float polutionDep;
    }

    private GameManager gameManager;
    private DependencyManager dependencyManager;

    [Header("Basic Settings")]
    public float price;
    public float moneyMod;
    public float happyMod;
    public float polutionMod;

    public bool isPurchased = false;

    [Header("OnHover Settings")]
    public float executeTime;
    public GameObject infoWindow;
    public GameObject infoBox;
    private float hoverTime = 0f;
    private bool startTimeCount;

    [SerializeField] public Dependency[] Dependencies;

    [ExecuteInEditMode]
    public void Start()
    {
        infoBox = GameObject.Find("informationalText");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        dependencyManager = GameObject.Find("DependencyManager").GetComponent<DependencyManager>();
        dependencyManager.FindNewPolicies(); //Dumb workaround to find inactive policies when they activate
        

        foreach (Dependency dependency in Dependencies) //Foreach loop naming the elements in the inspector for better readability and organization
        {
            dependency.name = dependency.dependency.name;
        }
    }


    private void OnMouseDown()
    {
        if (!isPurchased && gameManager.money >= price)
        {
            isPurchased = true;
            gameManager.money = gameManager.money - price;
            gameManager.moneyModifier = gameManager.moneyModifier + moneyMod;
            gameManager.happinessModifier = gameManager.happinessModifier + happyMod;
            gameManager.polutionModifier = gameManager.polutionModifier + polutionMod;
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            gameObject.GetComponentInChildren<Image>().color = Color.green;

            dependencyManager.CheckAllDependencies();
        }
    }


    public void CheckDependencies()
    {
        foreach (Dependency dependency in Dependencies)
        {
            if (dependency.dependency.GetComponent<Policy>().isPurchased && !dependency.activated)
            {
                dependency.activated = true;
                moneyMod += dependency.moneyDep;
                happyMod += dependency.happyDep;
                polutionMod += dependency.polutionDep;

                if (isPurchased)
                {
                    gameManager.moneyModifier += dependency.moneyDep;
                    gameManager.happinessModifier += dependency.happyDep;
                    gameManager.polutionModifier += dependency.polutionDep;
                }
            }
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
        infoBox.GetComponentInChildren<TextMeshPro>().enabled = false;
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
                infoBox.GetComponentInChildren<TextMeshPro>().enabled = true;
            }
        }
    }
}
