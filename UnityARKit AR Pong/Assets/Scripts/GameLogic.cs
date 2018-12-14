using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {

    public Text txtPlayerScore;
    public Text txtComputerScore;
    public int playerScore;
    public int computerScore;

    // public static function so that ball logic can call this 
    // w/o having to reference the gamelogic

    public void IncrementScore(string colliderName) {
        switch(colliderName) {
            case "Bounds South":
                computerScore++;
                txtComputerScore.text = "Computer: " + computerScore;
                return;
            case "Bounds North":
                playerScore++;
                txtPlayerScore.text = "Player: " + playerScore;
                return;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
