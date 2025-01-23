using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    public bool bubble;
    public bool player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bubble = false;
        player = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            if(bubble)
            {
                if(player)
                {
                    //go to next scene
                    Debug.Log("next level");
                }
            }
        }
        //if bubble overlaps, destroy bubble and set bubble true

        //if bubble true then if player overlap and preses W, they go to next level
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bubble"))
        {
            Debug.Log("bubble");
            //destroy bubble
            Destroy(other.gameObject);
            //set bubble true
            bubble = true;
        }

        else if(other.CompareTag("Player"))
        {
            player = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            player = false;
        }
    }
}
