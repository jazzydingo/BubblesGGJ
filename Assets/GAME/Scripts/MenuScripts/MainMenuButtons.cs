using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using AK.Wwise;

public class MainMenuButtons : MonoBehaviour
{
    private uint soundID;
    public GameObject sfxObj;
    public GameObject MenuMusic;

    

public void Start()
    {
        sfxObj = GameObject.FindWithTag("SFX");
    }
    public void PlayGame()
    {
        //play sound
        Destroy(MenuMusic);
        AkSoundEngine.PostEvent("octo_opening", sfxObj);
        //wait until sound end
        StartCoroutine(WaitForSound());


    }

    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(5f); 
        SceneManager.LoadSceneAsync(1);
    }

    public void QuiteGame()
    {
        Application.Quit();
    }
}
