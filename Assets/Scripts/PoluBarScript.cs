using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class PoluBarScript : MonoBehaviour
{
    public Slider slider; //Reference to slider controlling visual Polu
    public Image fill;

    public void SetPoluBar(float Polu) //Setting bar to Polu
    {
        slider.maxValue = Polu;
        slider.value = Polu;
    }

    public void UpdatePoluBar(float PoluValue) //Updating the Polu Bar to current Value
    {
        slider.value = PoluValue;
        fill.color = Color.Lerp(Color.green, Color.red, PoluValue / 100);
    }
}
