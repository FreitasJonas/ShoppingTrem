using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuController : MonoBehaviour
{
    public Slider sliderVolume;
    public VolumeController volumeController;

    private void Start()
    {
        if(PlayerPrefs.HasKey("volume"))
        {
            sliderVolume.value = PlayerPrefs.GetFloat("volume");
        }

        if(PlayerPrefs.HasKey("isMute"))
        {
            volumeController.setMute(PlayerPrefs.GetInt("isMute") == 0 ? false : true);
        }        
    }

    public void SavePrefs()
    {
        PlayerPrefs.SetFloat("volume", sliderVolume.value);
        PlayerPrefs.SetInt("isMute", volumeController.GetMuteValue());
    }
}
