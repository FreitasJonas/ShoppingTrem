using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour, IPointerClickHandler
{
    private bool isMute = false;

    public Sprite muteSprite;
    public Sprite noMuteSprite;
    public Slider slider;

    public ICameraConfig cameraConfig;

    void Start()
    {
        cameraConfig = GameObject.FindWithTag("camera").GetComponent<ICameraConfig>();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clecked!");

        this.isMute = !this.isMute;
        this.slider.interactable = !this.isMute;
        this.gameObject.GetComponent<Image>().sprite = isMute == false ? noMuteSprite : muteSprite;

        cameraConfig.ApplyMute(isMute);
    }

    public void setMute(bool mute) { 

        this.isMute = mute;
        this.slider.interactable = !mute;
        this.gameObject.GetComponent<Image>().sprite = isMute == false ? noMuteSprite : muteSprite;

        cameraConfig.ApplyMute(isMute);
    }

    public void OnValueChanged()
    {
        cameraConfig.ApplyVolume(slider.value);
    }

    public bool GetMuteValue()
    {
        return isMute;
    }
}
