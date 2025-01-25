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

    public GameObject objectToControl;

    public FanHandler fanHandler;

    private Material material;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lever = false;
        material = this.gameObject.GetComponent<SpriteRenderer>().material;
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
            material.SetFloat("_Thickness", 0.023f);
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        material.SetFloat("_Thickness", 0f);
    }

    void FlipLever()
    {
        if(!lever)
        {
            lever = true;
            //set sprite to down
            leverObj.GetComponent<SpriteRenderer>().sprite = leverDown;
            if(objectToControl != null)
            {
                
                fanHandler = objectToControl.GetComponent<FanHandler>();
                fanHandler.Flip();
            }
        }
        else
        {
            lever = false;
            //set sprite to up
            leverObj.GetComponent<SpriteRenderer>().sprite = leverUp;
            if(objectToControl != null)
            {
                fanHandler = objectToControl.GetComponent<FanHandler>();
                fanHandler.Flip();
            }
            
        }
    }
}
