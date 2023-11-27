using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipManager : MonoBehaviour
{
    public GameObject tooltip;

    public void ShowTooltip()
    {
        tooltip.SetActive(true);
    }

    public void HideTooltip()
    {
        tooltip?.SetActive(false);
    }
}
