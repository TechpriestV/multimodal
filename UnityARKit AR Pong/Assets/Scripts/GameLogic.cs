using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {

    public Text txtPlayerScore;
    public Text txtComputerScore;
    public int playerScore;
    public int computerScore;
    public Text winner;
    public BallLogic ballLogic;
    public GameObject Button;

    // public static function so that ball logic can call this 
    // w/o having to reference the gamelogic


    public void IncrementScore(string colliderName) {
        switch(colliderName) {
            case "Bounds South":
                computerScore++;
                txtComputerScore.text = "Computer: " + computerScore;
                if (computerScore == 5)
                    GameOver();
                    winner.text = "Computer winns!";
                return;
            case "Bounds North":
                playerScore++;
                txtPlayerScore.text = "Player: " + playerScore;
                if (playerScore == 5)
                    GameOver();
                    winner.text = "Player winns!";
                return;
        }
       
    }

    // Use this for initialization
    void Start () {

        Button.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameOver()
    {
        ballLogic.Stop();
        Button.SetActive(true);
    }
    public void RestartGame()
    {
        playerScore = 0;
        computerScore = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
