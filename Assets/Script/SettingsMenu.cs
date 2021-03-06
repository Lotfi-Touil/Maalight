    
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    Resolution[] resolutions;
    public AudioMixer audioMixer;
    public Dropdown reservationDropdown;
    public void Start()
    {
        resolutions = Screen.resolutions.Select(Resolution => new Resolution { width = Resolution.width, height = Resolution.height }).Distinct().ToArray();;
        reservationDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        
        reservationDropdown.AddOptions(options);
        reservationDropdown.value = currentResolutionIndex;
        Debug.Log(currentResolutionIndex);
        reservationDropdown.RefreshShownValue();
        Screen.fullScreen = true;
    }

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void setFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen; 
    }

    public void setResolution(int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width,res.height,Screen.fullScreen);
    }
    
}
