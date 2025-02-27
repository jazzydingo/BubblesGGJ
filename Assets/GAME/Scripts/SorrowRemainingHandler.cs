using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SorrowRemainingHandler : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject door;
    public GameObject sorrow;
    public GameObject bubble;
    public int remaining;
    public bool detected;
    public bool puzzle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sorrow = GameObject.FindWithTag("Sorrow");
        bubble = GameObject.FindWithTag("Bubble");
        remaining = 10;
        detected = false;
        puzzle = false;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Remaining:      x" + remaining;
        /*
        detected = false;
        sorrow = GameObject.FindWithTag("Sorrow");
        door = GameObject.FindWithTag("Door");
        
        if(sorrow != null)
        {
            puzzle = true;
        }
        if(puzzle)
        {
            if(door.GetComponent<DoorHandler>().bubble && !detected)
            {
                detected = true;
                remaining--;
            }
            
        }
        */
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            Debug.Log("yes");
            remaining = 9;
        }
        else if(SceneManager.GetActiveScene().buildIndex == 9)
        {
            remaining = 8;
        }
        else if(SceneManager.GetActiveScene().buildIndex == 10)
        {
            remaining = 7;
        }
        else if(SceneManager.GetActiveScene().buildIndex == 11)
        {
            remaining = 6;
        }
        else if(SceneManager.GetActiveScene().buildIndex == 12)
        {
            remaining = 5;
        }
        else if(SceneManager.GetActiveScene().buildIndex == 14)
        {
            remaining = 4;
        }
        else if(SceneManager.GetActiveScene().buildIndex == 15)
        {
            remaining = 3;
        }
        else if(SceneManager.GetActiveScene().buildIndex == 16)
        {
            remaining = 2;
        }
        else if(SceneManager.GetActiveScene().buildIndex == 17)
        {
            remaining = 1;
        }
        else if(SceneManager.GetActiveScene().buildIndex == 18)
        {
            remaining = 0;
        }





        if(SceneManager.GetActiveScene().buildIndex == 20)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // This will make the GameObject persist across scenes.
    }

}
