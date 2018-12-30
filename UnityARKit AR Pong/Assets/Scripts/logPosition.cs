using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logPosition : MonoBehaviour {

    private void FixedUpdate()
    {
        Debug.Log("Position: " + transform.position);   
    }
}