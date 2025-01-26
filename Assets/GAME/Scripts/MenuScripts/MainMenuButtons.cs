using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    private uint soundID;
    public GameObject sfxObj;

    public void Start()
    {
        sfxObj = GameObject.FindWithTag("SFX");
    }
    public void PlayGame()
    {
        //play sound
        AkSoundEngine.PostEvent("play_octo_opening", sfxObj);
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
