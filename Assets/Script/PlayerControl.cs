using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public KeyCode MoveUp;
    public KeyCode MoveDown;
    public float  speed;
    public float boundY1,boundY2;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }
    private void Movement()
    {
        var vel = rb2d.linearVelocity;
        if(Input.GetKey(MoveUp))
        {
            vel.y = speed;
        }
        else if (Input.GetKey(MoveDown))
        {
            vel.y = -speed;
        }
        else {
            vel.y = 0;
        }
        rb2d.linearVelocity = vel;
    }
    void Update()
    {
        Movement();

        var pos = transform.position;
        if(pos.y > boundY1)
        {
            pos.y = boundY1;
        }
        else if(pos.y <boundY2)
        {
            pos.y = boundY2;
        }
        transform.position = pos;

        
    }
    
}
