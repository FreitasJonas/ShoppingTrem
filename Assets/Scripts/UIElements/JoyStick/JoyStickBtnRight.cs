using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoyStickBtnRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Button btn;
    public PlayerC player;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (btn.interactable)
        {
            player.OnButtonDownMoveRight();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        player.OnButtonUpMoveRight();
    }
}
