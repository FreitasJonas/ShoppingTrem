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
                Debug.Log("Load: " + Json);

                GlobalConfiguration configuration = JsonConvert.DeserializeObject<GlobalConfiguration>(Json);
                    //(GlobalConfiguration)JsonUtility.FromJson(jSon, typeof(GlobalConfiguration));

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
        //var jSon = JsonUtility.ToJson(configuration, true);
        var Json = JsonConvert.SerializeObject(configuration, Formatting.Indented);
        Debug.Log("Save: " + Json);

        PlayerPrefs.SetString(Instance.key, Json);
    }
}
