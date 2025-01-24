using UnityEngine;

public class TrapDoorHandler : MonoBehaviour
{
    public GameObject lever;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lever.GetComponent<LeverHandler>().lever)
        {
            Destroy(this.gameObject);
        }
    }
}
