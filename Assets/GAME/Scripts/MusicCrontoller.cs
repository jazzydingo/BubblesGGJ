using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicCrontoller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 20 || SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(gameObject);

        }
    }

    private void Awake()
    { 
        if(FindObjectsOfType<MusicCrontoller>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);

        }
    }
}
