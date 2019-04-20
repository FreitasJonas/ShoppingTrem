using Newtonsoft.Json;
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
                var Json = PlayerPrefs.GetString(Instance.key);
                 
                var configuration = new GlobalConfiguration();
                JsonUtility.FromJsonOverwrite(Json, configuration);

                return configuration;
            }
            else
            {
                return null;
            }
        }
        catch (Exception e)
        {
            return null;
        }
        
    }

    public void SaveConfiguration(GlobalConfiguration configuration)
    {
        var Json = JsonUtility.ToJson(configuration, true);

        PlayerPrefs.SetString(Instance.key, Json);
    }
}
