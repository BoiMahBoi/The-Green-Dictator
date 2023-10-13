using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DependencyManager : MonoBehaviour
{
    [SerializeField]
    public Policy[] policy;

    void Start()
    {
        policy = FindObjectsOfType<Policy>();
    }

    public void CheckAllDependencies()
    {
        foreach (Policy policy in policy)
        {
            policy.CheckDependencies();
        }
    }
}
