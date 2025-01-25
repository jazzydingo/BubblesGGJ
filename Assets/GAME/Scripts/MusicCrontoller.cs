using UnityEngine;

public class MusicCrontoller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    { if (FindObjectsOfType<MusicCrontoller>().Length > 1)
        {
            Destroy(gameObject);

        }
        else
        {DontDestroyOnLoad(gameObject);

        }
    }
}
