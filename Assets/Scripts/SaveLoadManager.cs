using Newtonsoft.Json;
using System.IO;
using UnityEngine;
using SaveDataVC = SaveDataV3;

public static class SaveLoadManager
{
    public enum SaveMode
    {
        Text, // .json
        Encrypted // .dat
    }

    public static SaveMode Mode { get; set; } = SaveMode.Encrypted;
    public static int SaveDataVersion { get; } = 3;

    public static byte[] Encrypted;

    private static readonly string SaveDirectory = Path.Combine(Application.persistentDataPath, "Save");
    private static readonly string[] SaveFileNames =
    {
        "SaveAuto",
        "Save1",
        "Save2",
        "Save3"
    };

    public static SaveDataVC Data { get; set; } = new SaveDataVC();

    private static JsonSerializerSettings settings = new JsonSerializerSettings()
    {
        Formatting = Formatting.Indented,
        TypeNameHandling = TypeNameHandling.All
    };

    public static bool Save(int slot = 0)
    {
        return Save(slot, Mode);
    }

    public static bool Save(int slot, SaveMode mode)
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

            var path = GetSavePath(slot);
            var json = JsonConvert.SerializeObject(Data, settings);
            switch (Mode)
            {
                case SaveMode.Text:
                    File.WriteAllText(path, json);
                    break;

                case SaveMode.Encrypted:
                    File.WriteAllBytes(path, CryptoUtil.Encrypt(json));
                    break;
            }

            Debug.Log(path);
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
        return Load(slot, Mode);
    }

    public static bool Load(int slot, SaveMode mode)
    {
        if (slot < 0 || slot >= SaveFileNames.Length)
        {
            return false;
        }

        var path = GetSavePath(slot);
        if (!File.Exists(path))
        {
            return false;
        }

        try
        {
            var json = string.Empty;
            switch (Mode)
            {
                case SaveMode.Text:
                    json = File.ReadAllText(path);
                    break;

                case SaveMode.Encrypted:
                    json = CryptoUtil.Decrypt(File.ReadAllBytes(path));
                    break;
            }

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

    public static string GetSavePath(SaveMode mode, int slot)
    {
        var ext = mode == SaveMode.Text ? ".json" : ".dat";

        return Path.Combine(SaveDirectory, $"{SaveFileNames[slot]}{ext}");
    }

    private static string GetSavePath(int slot)
    {
        return GetSavePath(Mode, slot);
    }
}