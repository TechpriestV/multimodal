using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingLines : MonoBehaviour {

    public Transform ball;
    private Vector3 position;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        position.z = ball.transform.position.z;
        transform.position = position;

    }
}
