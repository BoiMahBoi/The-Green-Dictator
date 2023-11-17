using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BorderColorChanger : MonoBehaviour
{
    private GameManager gameManager;
    private Color bought = new Color(200, 200, 200, 255);
    private Color canAfford = new Color(0, 255, 0, 255);
    private Color canAlmostAfford = new Color(255, 255, 0, 255);
    private Color canNotAfford = new Color(255, 0, 0, 255); 

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
