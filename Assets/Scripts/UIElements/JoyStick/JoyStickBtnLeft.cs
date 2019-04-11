using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoyStickBtnLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Button btn;
    public PlayerC player;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (btn.interactable)
        {
            player.OnButtonDownMoveLeft();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        player.OnButtonUpMoveLeft();
    }
}
