using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BorderColorChanger : MonoBehaviour
{
    private GameManager gameManager;
    public Color bought;
    public Color canAfford;
    public Color canAlmostAfford;
    public Color canNotAfford;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            for (int j = 1; j < transform.GetChild(i).childCount; j++)
            {
                if (transform.GetChild(i).GetChild(j).transform.GetComponent<Policy>().isPurchased)
                {
                    transform.GetChild(i).GetChild(j).GetChild(1).GetChild(0).transform.GetComponent<Image>().color = bought;
                }
                else
                {
                    if(transform.GetChild(i).GetChild(j).transform.GetComponent<Policy>().price < gameManager.money)
                    {
                        transform.GetChild(i).GetChild(j).GetChild(1).GetChild(0).transform.GetComponent<Image>().color = canAfford;
                    }
                    else if(transform.GetChild(i).GetChild(j).transform.GetComponent<Policy>().price < gameManager.money * 2)
                    {
                        transform.GetChild(i).GetChild(j).GetChild(1).GetChild(0).transform.GetComponent<Image>().color = canAlmostAfford;
                    }
                    else
                    {
                        transform.GetChild(i).GetChild(j).GetChild(1).GetChild(0).transform.GetComponent<Image>().color = canNotAfford;
                    }
                }
            }
        }
    }
}
