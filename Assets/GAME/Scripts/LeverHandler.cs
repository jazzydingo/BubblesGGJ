using UnityEngine;
using UnityEngine.InputSystem;

public class LeverHandler : MonoBehaviour
{
    public bool lever;
    public bool interact;
    public bool overlap;

    public Sprite leverUp;
    public Sprite leverDown;

    public GameObject leverObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lever = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        overlap = true;
        if(other.CompareTag("Bubble"))
        {
            FlipLever();
        }
        else if(other.CompareTag("Player"))
        {
            
            FlipLever();
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

    }

    void FlipLever()
    {
        if(!lever)
        {
            lever = true;
            //set sprite to down
            leverObj.GetComponent<SpriteRenderer>().sprite = leverDown;
        }
        else
        {
            lever = false;
            //set sprite to up
            leverObj.GetComponent<SpriteRenderer>().sprite = leverUp;
        }
    }
}
