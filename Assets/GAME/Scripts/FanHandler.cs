using UnityEngine;

public class FanHandler : MonoBehaviour
{
    public bool fan;
    public bool overlap;

    public bool down;
    public bool up;
    public bool left;
    public bool right;
    public GameObject bubble;

    public GameObject sfxObj;

    public ParticleSystem bubbles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fan = false;
        overlap = false;
        bubbles.gameObject.SetActive(false);
        sfxObj = GameObject.FindWithTag("SFX");
    }

    // Update is called once per frame
    void Update()
    {
        if(fan)
        {
            bubbles.gameObject.SetActive(true);
            //make bubble go in direction if in path
            if(overlap)
            {
                if(up)
                {
                    bubble.GetComponent<BubbleController>().GoUp();
                }
                else if(down)
                {
                    bubble.GetComponent<BubbleController>().GoDown();
                }
                else if(right)
                {
                    bubble.GetComponent<BubbleController>().GoRight();
                }
                else if(left)
                {
                    bubble.GetComponent<BubbleController>().GoLeft();
                }
            }
        }
        else
        {
            bubbles.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if fan is on make bubble go in right direction (opposite from fan)
        if(other.CompareTag("Bubble"))
        {
            bubble = other.gameObject;
            overlap = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Bubble"))
        {
            overlap = false;
        }
    }

    public void Flip()
    {
        
        fan = !fan;
        if(fan)
        {
            AkSoundEngine.PostEvent("fan_starts", sfxObj);

        }
        else
        {
            AkSoundEngine.PostEvent("fan_stops", sfxObj);
        }

    }
}
