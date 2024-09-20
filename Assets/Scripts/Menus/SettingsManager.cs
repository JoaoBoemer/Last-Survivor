using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private Toggle fullscreenTog;
    [SerializeField] private TMP_Text resolutionText;
    public List<Resolution> resolutions = new List<Resolution>();
    private int selectedRes;

    private void Start()
    {
        if(PlayerPrefs.HasKey("masterVolume") || PlayerPrefs.HasKey("musicVolume") || PlayerPrefs.HasKey("SFXVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMasterVolume();
            SetMusicVolume();
            SetSFXVolume();
        }

        if(!resolutions.Where(res => res.vertical == Screen.height && res.horizontal == Screen.width).Any())
        {
            Resolution newRes = new Resolution();
            newRes.horizontal = Screen.width;
            newRes.vertical = Screen.height;
            
            resolutions.Add(newRes);
        }

        if(PlayerPrefs.HasKey("fullscreen"))
        {
            LoadGraphics();            
        }
        else
        {
            selectedRes = resolutions.Count - 1;
            UpdateResLabel();
        }
    }

    #region [Volume]
    public void SetMasterVolume()
    {
        float volume = masterSlider.value;
        mixer.SetFloat("master", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("masterVolume", volume);
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        mixer.SetFloat("music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    
    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        mixer.SetFloat("SFX", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    private void LoadVolume()
    {
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        SetMasterVolume();
        SetMusicVolume();
        SetSFXVolume();
    }
    #endregion

    #region [Graphics]

    private void LoadGraphics()
    {
        fullscreenTog.isOn = PlayerPrefs.GetInt("fullscreen", 1) == 1;
        
        Screen.SetResolution(PlayerPrefs.GetInt("resWidth", 1920), PlayerPrefs.GetInt("resHeight", 1080), fullscreenTog.isOn);
        selectedRes = PlayerPrefs.GetInt("selectedRes");
        UpdateResLabel();
    }

    public void ResLeft()
    {
        if(selectedRes > 0)
            selectedRes--;
        UpdateResLabel();
    }

    public void ResRight()
    {
        if(selectedRes < resolutions.Count-1)
            selectedRes++;
        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        resolutionText.text = resolutions[selectedRes].horizontal.ToString() + " x " + resolutions[selectedRes].vertical.ToString();
    }

    public void OnClick_ApplyChanges()
    {
        PlayerPrefs.SetInt("fullscreen", fullscreenTog.isOn ? 1 : 0);
        PlayerPrefs.SetInt("resWidth", resolutions[selectedRes].horizontal);
        PlayerPrefs.SetInt("resHeight", resolutions[selectedRes].vertical);
        PlayerPrefs.SetInt("selectedRes", selectedRes);
        LoadGraphics();
    }

    #endregion

    public void OnClick_Return()
    {
        UIManager.OpenMenu(Menu.MAIN_MENU, gameObject);
    }
}

[System.Serializable]
public class Resolution
{
    public int horizontal, vertical;
}