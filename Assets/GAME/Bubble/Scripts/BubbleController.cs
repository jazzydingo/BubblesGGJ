using UnityEngine;

public class BubbleController : MonoBehaviour
{
    private Rigidbody2D body;
    public int speed;
    public bool right;
    public bool left;
    public bool up;
    public bool down;
    public bool sorrow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        
        speed = 50;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!up && !down && !right && !left)
        {
            body.linearVelocity = new Vector2(0, 0);
        }
        else if(right)
        {
            body.linearVelocity = new Vector2(speed * Time.deltaTime, 0);
        }
        else if(left)
        {
            body.linearVelocity = new Vector2(-speed * Time.deltaTime, 0);
        }
        else if(up)
        {
            body.linearVelocity = new Vector2(0, speed * Time.deltaTime);
        }
        else if(down)
        {
            body.linearVelocity = new Vector2(0, -speed * Time.deltaTime);
        }
    }

    public void StopMotion()
    {
        up = false;
        down = false;
        right = false;
        left = false;
    }

    public void GoLeft()
    {
        StopMotion();
        left = true;
    }

    public void GoRight()
    {
        StopMotion();
        right = true;
    }

    public void GoUp()
    {
        Debug.Log("go up");
        StopMotion();
        up = true;
    }

    public void GoDown()
    {
        StopMotion();
        down = true;
    }
}
