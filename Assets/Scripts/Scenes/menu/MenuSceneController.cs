using UnityEngine;

public class MenuSceneController : MonoBehaviour
{
    private string GameScene = "Scene_01";

    public void playAudio(GameObject audioSource)
    {
        Instantiate(audioSource);
    }

    public void GoToGameScene()
    {
        Initiate.Fade(GameScene, Color.black, 0.5f);
    }
}
