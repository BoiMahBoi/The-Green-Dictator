using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    private string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};

    public TextMeshProUGUI MonthText;
    public TextMeshProUGUI YearText;

    public void NewMonth(int monthNumber)
    {
        MonthText.text = months[monthNumber];
    }
}
