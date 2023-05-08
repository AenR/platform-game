using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicslider;
    public void Low()
    {
        QualitySettings.SetQualityLevel(1);
    }

    public void Medium()
    {
        QualitySettings.SetQualityLevel(3);
    }

    public void High()
    {
        QualitySettings.SetQualityLevel(6);
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
