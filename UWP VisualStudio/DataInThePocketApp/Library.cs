using Windows.Storage;

public class Library
{
    public string LoadSetting(string keyLoad)
    {
        if (ApplicationData.Current.LocalSettings.Values[keyLoad] != null)
        {
            return ApplicationData.Current.LocalSettings.Values[keyLoad].ToString();
        }
        else
            return string.Empty;
    }
    public void SaveSettings(string keySave, string valueToSave)
    {
        ApplicationData.Current.LocalSettings.Values[keySave] = valueToSave;
    }
}