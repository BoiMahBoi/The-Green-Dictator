using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappyBarScript : MonoBehaviour
{
    public Slider slider; //Reference to slider controlling visual Happy

    public void SetHappyBar(float Happy) //Setting bar to Happy
    {
        slider.maxValue = Happy;
        slider.value = Happy;
    }

    public void UpdateHappyBar(float HappyValue) //Updating the Happy Bar to current value
    {
        slider.value = HappyValue;
    }
}
