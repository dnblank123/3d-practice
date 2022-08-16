using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Events;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volSlider;
    public TMPro.TMP_Dropdown resoDropdown;
    Resolution[] resolutions;
    public Toggle fullScreenToggle;
    public TMPro.TMP_Dropdown qualityDropDown;

    //prefs 
    const string prefName = "optionValue";
    const string resName = "resoOption";

    private bool isFullscreen = false;

    private int screenInt;
    
    private void Awake()
    {
        screenInt = PlayerPrefs.GetInt("togglestate");

        if(screenInt == 1)
        {
            isFullscreen = true;
            fullScreenToggle.isOn = true;
            
        } else {
            fullScreenToggle.isOn = false;
        }

        resoDropdown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(resName, resoDropdown.value);
            PlayerPrefs.Save();
        }
        ));
        qualityDropDown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(prefName, qualityDropDown.value);
            PlayerPrefs.Save();
        }
        ));
    }
    private void Start() 
    {
        volSlider.value = PlayerPrefs.GetFloat("MVolume", 1f);
        audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("MVolume"));
        qualityDropDown.value = PlayerPrefs.GetInt(prefName, 3);


        resolutions = Screen.resolutions;
        resoDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width+ " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.width &&
               resolutions[i].height == Screen.height)
               {
                   currentResolutionIndex = i;
               }
            
            
        }
        resoDropdown.AddOptions(options);
        //resoDropdown.value = currentResolutionIndex;
        resoDropdown.value = PlayerPrefs.GetInt(resName, currentResolutionIndex);
        resoDropdown.RefreshShownValue();

    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

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
        if(isFullscreen == false)
        {
            PlayerPrefs.SetInt("togglestate", 0);

        } else {
            isFullscreen = true;
            PlayerPrefs.SetInt("togglestate", 1);

        }
    }
}
