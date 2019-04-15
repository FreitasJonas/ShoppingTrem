using UnityEngine;

public class MenuSceneController : MonoBehaviour
{
    private string GameScene = "sceneFase01";

    public void playAudio(GameObject audioSource)
    {
        Instantiate(audioSource);
    }

    public void GoToGameScene()
    {
        Initiate.Fade(GameScene, Color.black, 0.5f);
    }

    public void OnClickBtnMenu(GameObject gameObject)
    {
        gameObject.GetComponent<Animator>().SetBool("isHidden", false);
    }

    public void OnClosePanelMenu(GameObject gameObject)
    {
        gameObject.GetComponent<Animator>().SetBool("isHidden", true);
    }
}
