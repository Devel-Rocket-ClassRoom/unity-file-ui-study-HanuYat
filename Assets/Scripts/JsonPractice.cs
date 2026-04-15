using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;

[Serializable]
public class SomeClass
{
    public Vector3 pos = Vector3.zero;
    public Quaternion rot = Quaternion.identity;
    public Vector3 scale = Vector3.one;
    public Color color = Color.white;

    public override string ToString()
    {
        return $"{pos} / {rot} / {scale} / {color}";
    }
}

public class JsonPractice : MonoBehaviour
{
    private JsonSerializerSettings setting;

    string fileName = "SomeClass.Json";
    string filePath => Path.Combine(Application.persistentDataPath, "JsonTest");

    string fullPath => Path.Combine(Application.persistentDataPath, "JsonTest", fileName);

    private void Awake()
    {
        setting = new JsonSerializerSettings();
        setting.Formatting = Formatting.Indented;
        setting.Converters.Add(new Vector3Converter());
        setting.Converters.Add(new QuaternionConverter());
        setting.Converters.Add(new ColorConverter());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Load();
        }
    }

    public void Save()
    {
        var obj = new SomeClass();

        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }

        var json = JsonConvert.SerializeObject(obj, setting);
        File.WriteAllText(fullPath, json);

        Debug.Log(fullPath);
        Debug.Log(json);
    }

    public void Load()
    {
        var json = File.ReadAllText(fullPath);
        var obj = JsonConvert.DeserializeObject<SomeClass>(json, setting);

        Debug.Log(obj);
        Debug.Log(json);
    }
}