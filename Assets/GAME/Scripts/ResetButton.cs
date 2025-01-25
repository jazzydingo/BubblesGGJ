using UnityEngine;
using UnityEngine.SceneManagement;


public class ResetButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SpeedUp()
    {
        if(GameObject.FindWithTag("Bubble") != null)
        GameObject.FindWithTag("Bubble").GetComponent<BubbleController>().speed += 75;
    }
}
