using UnityEngine;

public class GlobalConfiguration : MonoBehaviour
{
    public bool isMute;

    public float volume;
    public float cash;
    public float score;

    public static GlobalConfiguration Instance { get; set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }        
    }
}
