using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllSettings : MonoBehaviour {

    public enum ControllerTypes {Touch, Gesture};
    public ControllerTypes crType;
    public GameObject Touch;
    public GameObject Gesture;

    //Runs before start, on scene load
    void Awake () {
        if(!Touch){
            throw new UnityException("Need to set gameobject for touch controls!");
        }
        if(!Gesture){
            throw new UnityException("Need to set gameobject for gesture controls!");
        }
        if (crType.ToString() == "Touch"){
            Touch.SetActive(true);
            Gesture.SetActive(false);
        }else{
            Touch.SetActive(false);
            Gesture.SetActive(true);
        }
    }
}
