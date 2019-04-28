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
        var configuration = ConfigurationManager.Instance.GetDefaultConfiguration();
        var Json = "";  

        try
        {
            if (PlayerPrefs.HasKey(Instance.key))
            {
                Json = PlayerPrefs.GetString(Instance.key);
                 
                configuration = new GlobalConfiguration();
                JsonUtility.FromJsonOverwrite(Json, configuration);
            }

            return configuration;
        }
        catch (Exception e)
        {
            return configuration;
        }        
    }

    public void SaveConfiguration(GlobalConfiguration configuration)
    {
        var Json = JsonUtility.ToJson(configuration, true);

        PlayerPrefs.SetString(Instance.key, Json);
    }

    private GlobalConfiguration GetDefaultConfiguration()
    {
        var configuration = new GlobalConfiguration();

        //Settings
        configuration.settingsConfig.isMute = false;
        configuration.settingsConfig.volume = 0.5f;

        //Score
        configuration.scoreData.cash = 500;
        configuration.scoreData.score = 1000;

        //Progress


        //Inventary

        return configuration;
    }
}
