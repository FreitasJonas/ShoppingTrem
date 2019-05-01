using UnityEngine;

public class MainMenuCameraController : MonoBehaviour, ICameraConfig
{
    private AudioListener audioListner;
    private AudioSource audioSource;
    private GlobalConfiguration configuration;

    private void Start()    
    {
        configuration = ConfigurationManager.Instance.LoadConfigurarion();
        audioListner = GetComponent<AudioListener>();   
        audioSource = GetComponent<AudioSource>();
        ApplyMute(configuration.settingsConfig.isMute);
        ApplyVolume(configuration.settingsConfig.volume);
    }

    public void ApplyMute(bool isMute)
    {
        audioSource.mute = isMute;
    }

    public void ApplyVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
