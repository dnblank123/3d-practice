using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resoDropdown;
    //public TMPro.TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;

    private void Start() 
    {
        resolutions = Screen.resolutions;
        resoDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width+ " x " + resolutions[i].height+ " @ " + resolutions[i].refreshRate + "hz";
            options.Add(option);

            if(resolutions[i].width == Screen.width &&
               resolutions[i].height == Screen.height)
               {
                   currentResolutionIndex = i;
               }
            
            
        }
        resoDropdown.AddOptions(options);
        resoDropdown.value = currentResolutionIndex;
        resoDropdown.RefreshShownValue();

    }


    public void SetVolume(float Volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(Volume) * 20);

    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
