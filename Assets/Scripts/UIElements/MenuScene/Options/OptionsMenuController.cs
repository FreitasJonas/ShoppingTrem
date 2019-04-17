using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuController : MonoBehaviour
{
    public Slider sliderVolume;
    public VolumeController volumeController;

    private GlobalConfiguration configuration;

    private void Start()
    {
        configuration = ConfigurationManager.Instance.LoadConfigurarion();

        if (configuration != null)
        {
            sliderVolume.value = (float)configuration.settingsConfig.volume;
            volumeController.setMute(configuration.settingsConfig.isMute == 0 ? false : true);
        }
        else
        {
            Debug.Log("configuration = null");
        }
    }

    public void SavePrefs()
    {
        if(configuration == null)
        {
            configuration = new GlobalConfiguration();
        }

        configuration.settingsConfig.isMute = volumeController.GetMuteValue();
        configuration.settingsConfig.volume = sliderVolume.value;

        ConfigurationManager.Instance.SaveConfiguration(configuration);
    }
}
