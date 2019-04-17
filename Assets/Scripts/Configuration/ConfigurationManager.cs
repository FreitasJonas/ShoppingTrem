using System;
using UnityEngine;

public class ConfigurationManager : MonoBehaviour
{
    private string key = "ST_Player_prefs";
    public static ConfigurationManager Instance { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public GlobalConfiguration LoadConfigurarion()
    {
        try
        {
            if (PlayerPrefs.HasKey(Instance.key))
            {
                var jSon = PlayerPrefs.GetString(Instance.key);
                Debug.Log("Load: " + jSon);

                GlobalConfiguration configuration = (GlobalConfiguration)JsonUtility.FromJson(jSon, typeof(GlobalConfiguration));

                Debug.Log("VOLUME: " + configuration.settingsConfig.volume);

                return configuration;
            }
            else
            {
                return null;
            }
        }
        catch (Exception e)
        {
            Debug.Log("Deserialize Error! " + e.Message);
            return null;
        }
        
    }

    public void SaveConfiguration(GlobalConfiguration configuration)
    {
        var jSon = JsonUtility.ToJson(configuration, true);
        Debug.Log("Save: " + jSon);

        PlayerPrefs.SetString(Instance.key, jSon);
    }
}
