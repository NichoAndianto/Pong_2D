using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class BallControl : MonoBehaviour
{
    Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
    }
    void GoBall()
    {
        float rand = Random.Range(0, 2);

        if(rand < 1)
        {
            rb2d.AddForce(new Vector2(20, -15));
        }
        else
        {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    }
    void ResetBall()
    {
        rb2d.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
    void RestartBall()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }

    [SerializeField] private int wallCollisionCount;
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player1") 
        {
            rb2d.AddForce(new Vector2(20,-15));
            wallCollisionCount = 0;

        }
        else if (coll.gameObject.name == "PLayer2") 
        {
            rb2d.AddForce(new Vector2(-20,-15));
            wallCollisionCount = 0;
        }
        else 
        {
            wallCollisionCount = wallCollisionCount + 1;
            Debug.Log("Wall Collision! = " + wallCollisionCount);
            if (wallCollisionCount > 6) GoBall();
        }
    }

}

