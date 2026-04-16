using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using SaveDataVC = SaveDataV3;

public static class SaveLoadManager
{
    public enum SaveMode
    {
        Text,
        Encrypted
    }

    public static SaveMode Mode { get; set; } = SaveMode.Text;
    public static int SaveDataVersion { get; } = 3;

    private static readonly string SaveDirectory = Path.Combine(Application.persistentDataPath, "Save");
    private static readonly string[] SaveFileNames =
    {
        "SaveAuto.json",
        "Save1.json",
        "Save2.json",
        "Save3.json"
    };

    public static SaveDataVC Data { get; set; } = new SaveDataVC();

    private static JsonSerializerSettings settings = new JsonSerializerSettings()
    {
        Formatting = Formatting.Indented,
        TypeNameHandling = TypeNameHandling.All
    };

    public static bool Save(int slot = 0)
    {
        if (Data == null || slot < 0 || slot >= SaveFileNames.Length)
        {
            return false;
        }

        try
        {
            if (!Directory.Exists(SaveDirectory))
            {
                Directory.CreateDirectory(SaveDirectory);
            }

            var path = Path.Combine(SaveDirectory, SaveFileNames[slot]);
            var json = JsonConvert.SerializeObject(Data, settings);
            File.WriteAllText(path, json);
            return true;
        }
        catch
        {
            Debug.LogError("Save 예외");
            return false;
        }
    }

    public static bool Load(int slot = 0)
    {
        if (slot < 0 || slot >= SaveFileNames.Length)
        {
            return false;
        }

        var path = Path.Combine(SaveDirectory, SaveFileNames[slot]);
        if (!File.Exists(path))
        {
            return false;
        }

        try
        {
            var json = File.ReadAllText(path);
            var saveData = JsonConvert.DeserializeObject<SaveData>(json, settings);
            while (saveData.Version < SaveDataVersion)
            {
                Debug.Log(saveData.Version);
                saveData = saveData.VersionUp();
                Debug.Log(saveData.Version);
            }

            Data = saveData as SaveDataVC;
            return true;
        }
        catch
        {
            Debug.LogError("Load 예외");
            return false;
        }
    }
}