using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{

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
}
