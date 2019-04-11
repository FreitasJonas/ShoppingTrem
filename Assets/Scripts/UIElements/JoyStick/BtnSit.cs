using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnSit : MonoBehaviour {

    public PlayerC player;

    private Button _button;

	// Use this for initialization
	void Start () {

        _button = GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {

        _button.interactable = player.canSit;		
	}

    public void OnButtonDownSit()
    {
        player.OnButtonDownSit();
    }
}
