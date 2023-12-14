using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Setting : MonoBehaviour
{

    Resolution[] resolutions;   // một mảng chứa độ phân giải
    public Dropdown resolutionsDropdown;
    void Start()
    {
        resolutions = Screen.resolutions; // gán độ phân giải = độ phân giải màn hình mong muốn
        resolutionsDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for(int i=0 ; i<resolutions.Length ; i++)
        {
            string opption = resolutions[i].width + " x " + resolutions[i].height; 
            options.Add(opption);

            if(resolutions[i].width == Screen.currentResolution.width && 
            resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionsDropdown.AddOptions(options);
        resolutionsDropdown.value = currentResolutionIndex;
        resolutionsDropdown.RefreshShownValue();
    }
    public void Setsolution(int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width , resolution.height , Screen.fullScreen);
    }
    public void SetQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullScreen(bool isFullScreen){
        Screen.fullScreen = isFullScreen;
    }
}
