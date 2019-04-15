using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour, IPointerClickHandler
{
    private bool isMute = false;

    public Sprite muteSprite;
    public Sprite noMuteSprite;

    public Slider slider;

    public void Start()
    {
        //this.gameObject.GetComponent<Image>().sprite = noMuteSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        this.isMute = !this.isMute;
        this.slider.interactable = !this.isMute;
        this.gameObject.GetComponent<Image>().sprite = isMute == false ? noMuteSprite : muteSprite;
    }

    public void setMute(bool mute) {

        Debug.Log("mute: " + mute);

        this.isMute = mute;
        this.slider.interactable = !mute;
        this.gameObject.GetComponent<Image>().sprite = isMute == false ? noMuteSprite : muteSprite;
    }

    public int GetMuteValue()
    {
        var val = isMute ? 1 : 0;
        Debug.Log("Val: " + val);
        return val;
    }
}
