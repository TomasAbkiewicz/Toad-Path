using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public Slider volumeSlider;
    public Toggle musicToggle;
    public Slider brightnessSlider;
    public AudioSource musicSource;
    public GameObject brightnessOverlay;

    void Start()
    {
        optionsPanel.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(Enemy.Demo);
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value;
    }

    public void ToggleMusic(bool isOn)
    {
        if (musicSource != null)
            musicSource.mute = !isOn;
    }

    public void SetBrightness(float value)
    {
        if (brightnessOverlay != null)
        {
            var color = brightnessOverlay.GetComponent<Image>().color;
            color.a = 1f - value;
            brightnessOverlay.GetComponent<Image>().color = color;
        }
    }
}
