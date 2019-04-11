using UnityEngine;

public class CameraMenu : MonoBehaviour {

    //name of the scene you want to load
    public string scene;
    
    public void GoToGameScene()
    {
        Initiate.Fade(scene, Color.black, 0.5f);
    }
}
