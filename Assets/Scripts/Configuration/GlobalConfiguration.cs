using UnityEngine;

[System.Serializable]
public class GlobalConfiguration 
{
    public SettingsConfig settingsConfig = new SettingsConfig();
    public InventaryData inventaryData = new InventaryData();
    public ProgressData progressData = new ProgressData();
    public ScoreData scoreData = new ScoreData();
}

[System.Serializable]
public class SettingsConfig
{
    #region Som

    public int _isMute;
    public bool isMute;

    public float volume;

    #endregion
}

[System.Serializable]
public class InventaryData
{

}

[System.Serializable]
public class ProgressData
{

}

[System.Serializable]
public class ScoreData
{
    public float cash;
    public float score;
}




