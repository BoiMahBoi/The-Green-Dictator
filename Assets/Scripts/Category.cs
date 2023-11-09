using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Category : MonoBehaviour
{

    public GameObject[] policies;

    private bool categoryOpen = false;

    private void Start()
    {
        //PositionPolicies();
    }

    private void PositionPolicies()
    {
        for (int i = 0; i < policies.Length; i++)
        {
            if (i == 0)
            {
                UnityEngine.Debug.Log(policies[i].GetComponent<Transform>().position);

                policies[i].GetComponent<Transform>().position = new Vector3(-11, 0, -11);
            } else if (i == 1)
            {
                UnityEngine.Debug.Log(policies[i].GetComponent<Transform>().position);

                policies[i].GetComponent<Transform>().position = new Vector3(11, 0, -11);
            } else if (i == 2)
            {
                UnityEngine.Debug.Log(policies[i].GetComponent<Transform>().position);
                policies[i].GetComponent<Transform>().position = new Vector3(0, 0, 12);

            }
        }
    }

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
