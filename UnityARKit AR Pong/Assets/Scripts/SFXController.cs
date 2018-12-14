using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{

    public static AudioClip computerScoreSound, playerScoreSound, wallBounceSound, paddleBounceSound, playerWinSound, computerWinSound, gameSoundtrack;
    static AudioSource audioSource;

    // Use this for initialization
    void Start()
    {

        wallBounceSound = Resources.Load<AudioClip>("wall_bounce1");
        paddleBounceSound = Resources.Load<AudioClip>("paddle_bounce2");
        computerScoreSound = Resources.Load<AudioClip>("computer_score_dundundun");
        playerScoreSound = Resources.Load<AudioClip>("score_player");
        computerWinSound = Resources.Load<AudioClip>("synthwave_soundtrack1");
        playerWinSound = Resources.Load<AudioClip>("synthwave_soundtrack1");
        gameSoundtrack = Resources.Load<AudioClip>("synthwave_soundtrack1");

        audioSource = GetComponent<AudioSource>();
    }



    public static void PlaySound(string clip)
    {

        switch (clip)
        {
            case "wallB":
                audioSource.PlayOneShot(wallBounceSound);
                break;
            case "paddleB":
                audioSource.PlayOneShot(paddleBounceSound);
                break;
            case "compScore":
                audioSource.PlayOneShot(computerScoreSound);
                break;
            case "playerScore":
                audioSource.PlayOneShot(playerScoreSound);
                break;
            case "compWin":
                audioSource.PlayOneShot(computerWinSound);
                break;
            case "playerWin":
                audioSource.PlayOneShot(playerWinSound);
                break;
            case "soundtrack":
                audioSource.PlayOneShot(gameSoundtrack);
                break;
        }

    }
}