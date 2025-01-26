using UnityEngine;

public class SorrowHandler : MonoBehaviour
{
    public GameObject sfxObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sfxObj = GameObject.FindWithTag("SFX");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("enter");
        if(other.CompareTag("Bubble"))
        {
            Debug.Log("tag");
            other.gameObject.GetComponent<BubbleController>().sorrow = true;
            Debug.Log("sorrow true");
            AkSoundEngine.PostEvent("sorrow_collect", sfxObj);
            Destroy(this.gameObject);
        }
    }
}
