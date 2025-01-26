using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorHandler : MonoBehaviour
{
    public bool bubble;
    public bool player;
    public Sprite openDoor;
    public Material material;
    public GameObject sfxObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //bubble = false;
        //player = false;
        sfxObj = GameObject.FindWithTag("SFX");        
        material = this.gameObject.GetComponent<SpriteRenderer>().material;
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
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }
        //if bubble overlaps, destroy bubble and set bubble true

        //if bubble true then if player overlap and preses W, they go to next level

        if(bubble)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = openDoor;
            
        }
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
                AkSoundEngine.PostEvent("door", sfxObj);
            }
            
        }

        else if(other.CompareTag("Player"))
        {
            player = true;
            if(bubble)
            {
                //highlight
                material.SetFloat("_Thickness", 0.023f);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            player = false;
            material.SetFloat("_Thickness", 0f);
        }
    }
}
