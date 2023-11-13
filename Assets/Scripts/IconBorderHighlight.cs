using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class IconBorderHighlight : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 100f;

    private void OnEnable()
    {
        transform.rotation = Quaternion.identity;
    }


    // Update is called once per frame
    void Update()
    {        
        transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
