using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARPaddle : MonoBehaviour {

    // Use this for initialization

    public GameObject ARCamera;

    private Vector3 position;
	void Start () {
        if(!ARCamera){
            throw new UnityException("No ARCamera to follow");
        }
        position.z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        position.x = ARCamera.transform.position.x;
        position.y = ARCamera.transform.position.y;

        transform.position = position;
	}
}
