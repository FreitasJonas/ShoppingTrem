using UnityEngine;

[System.Serializable]
public class GlobalConfiguration : MonoBehaviour
{
    public SettingsConfig settingsConfig = new SettingsConfig();
    //public InventaryData inventaryData = new InventaryData();
    //public ProgressData progressData = new ProgressData();
    public ScoreData scoreData = new ScoreData();
}

[System.Serializable]
public class SettingsConfig
{
    #region Som

    public int isMute;
    public double volume;

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




