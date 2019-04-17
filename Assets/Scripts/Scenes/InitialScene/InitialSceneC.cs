using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialSceneC : MonoBehaviour
{
    public void OnClickStartButton()
    {
        Initiate.Fade("sceneMenu", Color.black, 0.5f);
    }
}
