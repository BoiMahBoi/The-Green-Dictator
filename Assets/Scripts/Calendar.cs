using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    private string[] months = {"December", "November", "October", "September", "August", "July", "June", "May", "April", "March", "February", "January"};

    public TextMeshProUGUI MonthText;
    public TextMeshProUGUI YearText;

    public int MonthCount = 0;
    public int YearCount = 2020;

    private void Start()
    {
        //NewMonth(MonthCount);
    }

    public void NewMonth(int monthNumber)
    {
        MonthCount = monthNumber;
        MonthText.text = months[monthNumber];

        if (monthNumber == 11)
        {
            newYear();
        }
    }

    public void newYear()
    {
        YearCount++;
        YearText.text = YearCount.ToString();
    }
}
