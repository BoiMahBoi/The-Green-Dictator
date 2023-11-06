using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoluBarScript : MonoBehaviour
{
    public Slider slider; //Reference to slider controlling visual Polu

    public void SetPoluBar(float Polu) //Setting bar to Polu
    {
        slider.maxValue = Polu;
        slider.value = Polu;
    }

    public void UpdatePoluBar(float PoluValue) //Updating the Polu Bar to current Value
    {
        slider.value = PoluValue;
    }
}
