using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    private Vector3 scale;
    public GameObject spawner;
    public GameObject bubble;
    
    private BubbleController bubbleController;
    private Vector3 spawnerOffset;
    public GameObject bubbleobj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scale = transform.localScale;
        Vector3 spawnerOffset = new Vector3(1,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (scale.x > 0)
        {
            //facing right, spawner at 1
            spawner.transform.position = transform.position + spawnerOffset;
        }
        else if (scale.x < 0)
        {
            //facing left, spawner at -1
            spawner.transform.position = transform.position - spawnerOffset;
        }

        if(GameObject.FindWithTag("Bubble") == null)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                GameObject bubbleobj = Instantiate(bubble, spawner.transform.position, Quaternion.identity);
                //set up true
                bubbleController = bubbleobj.GetComponent<BubbleController>();
                bubbleController.GoUp();
                
            }
            else if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                GameObject bubbleobj = Instantiate(bubble, spawner.transform.position, Quaternion.identity);
                //set up true
                bubbleobj.GetComponent<BubbleController>().GoDown();
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                GameObject bubbleobj = Instantiate(bubble, spawner.transform.position, Quaternion.identity);
                //set up true
                bubbleobj.GetComponent<BubbleController>().GoRight();
            }
            else if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                GameObject bubbleobj = Instantiate(bubble, spawner.transform.position, Quaternion.identity);
                //set up true
                bubbleobj.GetComponent<BubbleController>().GoLeft();
            }
        }
        
    }
}
