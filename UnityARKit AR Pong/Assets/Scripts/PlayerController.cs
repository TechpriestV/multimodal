﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Camera playerCam; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount != 1)
            return;

        var ray = playerCam.ScreenPointToRay(Input.touches[0].position);
        var hitInfo = new RaycastHit();
        if(Physics.Raycast(ray, out hitInfo)) {
            if (hitInfo.transform.name != "Bounds South")
                return;
            var newPos = transform.position;
            newPos.x = hitInfo.point.x;
            transform.position = newPos; 
        }

    }
}
