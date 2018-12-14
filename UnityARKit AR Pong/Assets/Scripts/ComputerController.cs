using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour {

    public Transform ball;

    [Range(0, 1)]
    public float skill;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = transform.position;
        newPos.x = Mathf.Lerp(transform.position.x, ball.position.x, skill);
        transform.position = newPos;
	}
}
