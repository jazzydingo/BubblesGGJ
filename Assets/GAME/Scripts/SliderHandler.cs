using UnityEngine;
using UnityEngine.UI;

public class SliderHandler : MonoBehaviour
{
    public Slider slider;
    private float volume;

    void Start()
    {
        // Load saved volume or default to 75
        volume = PlayerPrefs.GetFloat("MasterVolume", 75f);
        slider.value = volume;

        // Set Wwise RTPC value
        AkSoundEngine.SetRTPCValue("_MasterVolume", volume, null);

        // Add listener to update volume
        slider.onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float sliderVal)
    {
        Debug.Log("Volume Changed: " + sliderVal);
        
        volume = sliderVal;
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save(); // Ensures data is saved immediately

        AkSoundEngine.SetRTPCValue("_MasterVolume", sliderVal, null);
    }

    void OnApplicationQuit()
    {
        // If you only want to reset the volume setting on quit
        PlayerPrefs.DeleteKey("MasterVolume");
    }
}