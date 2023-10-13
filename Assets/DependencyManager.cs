using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DependencyManager : MonoBehaviour
{
    [SerializeField]
    public Policy[] policy;

    public void FindNewPolicies()
    {
        List<Policy> policyList = new List<Policy>(policy);
        Policy[] newPolicies = FindObjectsOfType<Policy>();

        foreach (Policy newPolicy in newPolicies)
        {
            if (!policyList.Contains(newPolicy))
            {
                policyList.Add(newPolicy);
            }
        }

        policy = policyList.ToArray();
    }

    public void CheckAllDependencies()
    {
        foreach (Policy policy in policy)
        {
            policy.CheckDependencies();
        }
    }
}
