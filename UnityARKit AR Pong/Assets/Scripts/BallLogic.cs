using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallLogic : MonoBehaviour
{

    public GameLogic gameLogic;
    public GameObject computerPaddle;
    public GameObject touchPaddle;
    public GameObject gesturePaddle;

    public Material Material1;
    public Material Material2;

    //https://docs.unity3d.com/ScriptReference/Vector3.html
    //Representation of 3D vectors and points.
    Vector3 velocity;

    [Range(0, 1)]
    public float speed;  // public makes it vis in unity

    void Start()
    {
        ResetBall();
    }

    public void ResetBall()
    {
        transform.position = Vector3.zero; //setting pos to (0,0,0)
        Wait();
        float z =  1f;
        //float x = Random.Range(0, 2) * 2f - 1f * Random.Range(0.2f, 1f);
        //float y = Random.Range(0, 2) * 2f - 1f * Random.Range(0.2f, 1f);
        float x = Random.Range(-0.3f, 0.3f);
        float y = Random.Range(-0.3f, 0.3f);
        //float x = 0f;
        //float y = 0f;

        velocity = new Vector3(x, y, z);
    }
    public void Stop()
    {
        velocity = Vector3.zero;
    }
    // Update is called once per frame
    // FixedUpdate instead of update to make sure its 
    // in sync /w physics

    void FixedUpdate()
    {
        velocity = velocity.normalized * speed * 0.05f;
        transform.position += velocity;
    }

    void OnCollisionEnter(Collision collision)
    //https://docs.unity3d.com/ScriptReference/Collision.html
    //https://docs.unity3d.com/ScriptReference/Collider.OnCollisionEnter.html
    {
        if (collision.transform.tag == "Player")
        {
            gameLogic.CountBounces();
        }

        switch (collision.transform.name)
        {
            case "Bounds East":
            case "Bounds West":
                velocity.x *= -1f;
                SFXController.PlaySound("wallB");
                return;
            case "Bounds Upper":
            case "Bounds Lower":
                velocity.y *= -1f;
                SFXController.PlaySound("wallB");
                return;

            case "Inner Wall":
                velocity.z *= -1f;
                SFXController.PlaySound("wallB");
                return;
            case "Bounds North":
                ResetBall();
                gameLogic.IncrementScore(collision.transform.name);
                SFXController.PlaySound("playerScore");
                return;

            case "Bounds South":
                ResetBall();
                gameLogic.IncrementScore(collision.transform.name);
                SFXController.PlaySound("compScore");
                return;
            case "Touch Paddle":
                SFXController.PlaySound("paddleB");
                velocity.z *= -1f;
                StartCoroutine(Flasher(touchPaddle));
                return;
            case "Gesture Paddle":
                SFXController.PlaySound("paddleB");
                velocity.z *= -1f;
                StartCoroutine(Flasher(gesturePaddle));
                return;

            case "Computer Paddle":
                SFXController.PlaySound("paddleB");
                velocity.z *= -1f;
                StartCoroutine(Flasher(computerPaddle));
                return;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }

    IEnumerator Flasher(GameObject paddle) {
        paddle.GetComponent<MeshRenderer>().material = Material2;
        yield return new WaitForSeconds(.15f);
        paddle.GetComponent<MeshRenderer>().material = Material1;
    }
}