using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DoorHandler : MonoBehaviour
{
    public bool bubble;
    public bool player;
    public int nextSceneIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bubble = false;
        player = false;
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(InputSystem.actions["Move"].ReadValue<Vector2>().y ==1 )
        {
            if(bubble)
            {
                if(player)
                {
                    //go to next scene
                    Debug.Log("next level");
                    SceneManager.LoadScene(nextSceneIndex);
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
            if(other.gameObject.GetComponent<BubbleController>().sorrow  == true)
            {
                //destroy bubble
                Destroy(other.gameObject);
                //set bubble true
                bubble = true;
            }
            
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
