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

    public enum CountRules {Bounces, Score}
    public CountRules ctRules;

    private int bounces;
    public int scoreLimit = 5;

    // public static function so that ball logic can call this 
    // w/o having to reference the gamelogic


    public void IncrementScore(string colliderName) {
        switch(colliderName) {
            case "Bounds South":
                computerScore++;
                updateText();
                CheckGameOver(computerScore, "Computer");
                return;
            case "Bounds North":
                playerScore++;
                updateText();
                CheckGameOver(computerScore, "Player");
                return;
        }
       
    }

    public void CountBounces(){
        bounces++;
        updateText();
    }

    // Use this for initialization
    void Start () {
        
        Button.SetActive(false);
        if (ctRules.ToString() == "Score"){
            txtPlayerScore.text = "Player: 0";
            txtComputerScore.text = "Computer: 0";
        }else if (ctRules.ToString() == "Bounces"){
            txtPlayerScore.text = "Bounces: " + bounces;
            txtComputerScore.text = "";
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void updateText() {
        if (ctRules.ToString() == "Score")
        {
            txtPlayerScore.text = "Player: " + playerScore;
            txtComputerScore.text = "Computer: " + computerScore;
        }
        else if (ctRules.ToString() == "Bounces")
        {
            txtPlayerScore.text = "Bounces: " + bounces;
        }
    }

    private void CheckGameOver(int value, string entity) {
        if (ctRules.ToString() == "Score") {
            if (value >= scoreLimit) {
                winner.text = entity + " winns!";
                GameOver();
            }
        } else if (ctRules.ToString() == "Bounces") {
            if (entity == "Computer"){
                winner.text = "You missed!\nYou managed to bounce the ball " + bounces + " times!";
                GameOver();
            }
        } else {
            throw new UnityException("Unknown gamemode!");
        }
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
        bounces = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
