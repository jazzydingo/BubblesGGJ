using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsQuit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindWithTag("Bubble").transform.position.y > 30)
        {
            SceneManager.LoadScene(0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(0);
    }
}
