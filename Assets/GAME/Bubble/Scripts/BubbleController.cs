using UnityEngine;

public class BubbleController : MonoBehaviour
{
    private Rigidbody2D body;
    public int speed;
    public bool right;
    public bool left;
    public bool up;
    public bool down;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        up = false;
        down = false;
        right = false;
        left = false;
        speed = 50;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!up && !down && !right && !left)
        {
            body.linearVelocity = new Vector2(0, 0);
        }
        if(right)
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

    void StopMotion()
    {
        up = false;
        down = false;
        right = false;
        left = false;
    }
}
