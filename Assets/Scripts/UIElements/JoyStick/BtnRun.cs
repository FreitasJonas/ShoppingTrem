using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnRun : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PlayerC player;   

    // Use this for initialization
    void Start () {
		
	}

    public void OnPointerDown(PointerEventData eventData)
    {   
        player.OnButtonDownRun();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        player.OnButtonUpRun();
    }
}
