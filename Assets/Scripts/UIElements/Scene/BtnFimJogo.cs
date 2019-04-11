using UnityEngine;

public class BtnFimJogo : MonoBehaviour {


    public void GoToMenuScene()
    {
        Initiate.Fade("Scene_menu", Color.black, 1.0f);
    }
}
