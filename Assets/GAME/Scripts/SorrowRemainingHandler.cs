using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SorrowRemainingHandler : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject door;
    public int remaining;
    public bool detected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        door = GameObject.FindWithTag("Door");
        remaining = 10;
        detected = false;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Remaining:     x" + remaining;
        if(door.GetComponent<DoorHandler>().bubble && !detected)
        {
            detected = true;
            remaining--;
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
