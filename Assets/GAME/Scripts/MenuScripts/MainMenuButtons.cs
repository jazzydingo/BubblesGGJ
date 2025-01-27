using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using AK.Wwise;

public class MainMenuButtons : MonoBehaviour
{
    private uint soundID;
    public GameObject sfxObj;
    public GameObject MenuMusic;

    void Awake()
    {
        StartCoroutine(LoadSoundBankAsync());
    }

    IEnumerator LoadSoundBankAsync()
    {
        string soundBankPath = Application.streamingAssetsPath + "/Audio/GeneratedSoundBanks/Main.bnk";
        uint bankID;

        // Load the soundbank asynchronously
        AKRESULT result = AkSoundEngine.LoadBank(soundBankPath, out bankID);

        if (result == AKRESULT.AK_Success)
        {
            Debug.Log("SoundBank loaded successfully!");
        }
        else
        {
            Debug.LogError("Failed to load SoundBank.");
        }

        yield return null;
    }

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
