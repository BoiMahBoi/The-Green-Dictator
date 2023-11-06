using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{

    public Slider slider; //Reference to slider controlling visual time left

    public void SetTimeBar(float time) //Setting bar to time
    {
        slider.maxValue = time;
        slider.value = time;
    }

    public void UpdateTimeBar(float timeRemaining) //Updating the Time Bar to current remaining time
    {
        slider.value = timeRemaining;
    }

}
