using UnityEngine;

public class Follow_player : MonoBehaviour
{

    public Transform player;
    public bool finalLevel;
    public GameObject bubble;

    // Update is called once per frame
    void Start()
    {

    }
    void Update()
    {
        bubble = GameObject.FindWithTag("Bubble");
        transform.position = player.transform.position + new Vector3(0, 1, -5);

        if(finalLevel  && bubble != null)
        {
            transform.position = bubble.transform.position + new Vector3(0, 1, -5);
        }
        
    }
}
