using UnityEngine;

public class TrapDoorHandler : MonoBehaviour
{
    public GameObject lever;
    public GameObject sfxObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sfxObj = GameObject.FindWithTag("SFX");
    }

    // Update is called once per frame
    void Update()
    {
        if(lever.GetComponent<LeverHandler>().lever)
        {
            AkSoundEngine.PostEvent("trap_door", sfxObj);
            Destroy(this.gameObject);
        }
    }
}
