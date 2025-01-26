using UnityEngine;
using UnityEngine.UI;

public class SliderHandler : MonoBehaviour
{
    public Slider slider;
    public float volume;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider.value = 75f;
        AkSoundEngine.SetRTPCValue("_MasterVolume", slider.value, null);
        slider.onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float sliderVal)
    {
        Debug.Log("change");
        Debug.Log(sliderVal);
        AkSoundEngine.SetRTPCValue("_MasterVolume", sliderVal, null);
    }

    // Update is called once per frame
    
}
