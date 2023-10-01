using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Category : MonoBehaviour
{

    public GameObject[] policies;

    private bool categoryOpen = false;

    private void OnMouseDown()
    {
        if (!categoryOpen)
        {
            foreach(GameObject i in policies)
            {
                i.SetActive(true);
            }
            categoryOpen = true;
        } else { 
            foreach(GameObject i in policies)
            { 
                i.SetActive(false); 
            }
            categoryOpen = false;
        }
    }
}
