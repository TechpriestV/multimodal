using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallLogic : MonoBehaviour
{

    public GameLogic gameLogic;

    //https://docs.unity3d.com/ScriptReference/Vector3.html
    //Representation of 3D vectors and points.
    Vector3 velocity;

    [Range(0, 1)]
    public float speed = 0.1f;  // public makes it vis in unity

    void Start()
    {
        ResetBall();
    }

    void ResetBall()
    {
        transform.position = Vector3.zero; //setting pos to (0,0,0)
        float z = Random.Range(0, 2) * 2f - 1f;
        float x = Random.Range(0, 2) * 2f - 1f * Random.Range(0.2f, 1f);
        velocity = new Vector3(x, 0, z);
    }


    // Update is called once per frame
    // FixedUpdate instead of update to make sure its 
    // in sync /w physics

    void FixedUpdate()
    {
        velocity = velocity.normalized * speed;
        transform.position += velocity;
    }

    void OnCollisionEnter(Collision collision)
    //https://docs.unity3d.com/ScriptReference/Collision.html
    //https://docs.unity3d.com/ScriptReference/Collider.OnCollisionEnter.html
    {

        switch (collision.transform.name)
        {
            case "Bounds East":
            case "Bounds West":
                velocity.x *= -1f;
                return;
            case "Bounds North":
            case "Bounds South":
                ResetBall();
                gameLogic.IncrementScore(collision.transform.name);
                return;
            case "Player Paddle":
            case "Computer Paddle":
                velocity.z *= -1f;
                return;
        }
    }

}