using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class ShapeData
{
    public string prefabName;
    public Vector3 pos;
    public Quaternion rot;
    public Vector3 scale;
    public Color color;

    public override string ToString()
    {
        return $"{pos} / {rot} / {scale} / {color}";
    }
}

public class Shapes : MonoBehaviour
{
    private JsonSerializerSettings settings;
    private string fileName = "Shapes.Json";

    private string filePath => Path.Combine(Application.persistentDataPath, "JsonTest");
    private string fullPath => Path.Combine(Application.persistentDataPath, "JsonTest", fileName);

    private string[] prefabNames =
    {
        "Cube",
        "Cylinder",
        "Capsule",
        "Sphere"
    };

    private void Awake()
    {
        settings = new JsonSerializerSettings();
        settings.Formatting = Formatting.Indented;
        settings.Converters.Add(new Vector3Converter());
        settings.Converters.Add(new QuaternionConverter());
        settings.Converters.Add(new ColorConverter());

        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }
    }

    public void OnClickSave()
    {
        var saveList = new List<ShapeData>();

        var shapes = GameObject.FindGameObjectsWithTag("Shape");
        foreach (var shape in shapes)
        {
            var jsonTestObj = shape.GetComponent<JsonTestObject>();
            saveList.Add(jsonTestObj.GetSaveData());
        }

        var json = JsonConvert.SerializeObject(saveList, settings);
        File.WriteAllText(fullPath, json);
    }

    public void OnClickLoad()
    {
        OnClickClear();

        var json = File.ReadAllText(fullPath);
        var saveList = JsonConvert.DeserializeObject<List<ShapeData>>(json, settings);
        foreach (var saveData in saveList)
        {
            var prefab = Resources.Load<JsonTestObject>(saveData.prefabName);
            var jsonTestObj = Instantiate(prefab);
            jsonTestObj.Set(saveData);
        }
    }

    public void OnClickCreate()
    {
        for (int i = 0; i < 10; i++)
        {
            CreateRandomObject();
        }
    }

    private void CreateRandomObject()
    {
        var prefabName = prefabNames[Random.Range(0, prefabNames.Length)];
        var prefab = Resources.Load<JsonTestObject>(prefabName);
        var obj = Instantiate(prefab);

        obj.transform.position = Random.insideUnitSphere * 10f;
        obj.transform.rotation = Random.rotation;
        obj.transform.localScale = Vector3.one * Random.Range(0.5f, 2f);
        obj.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }

    public void OnClickClear()
    {
        var shapes = GameObject.FindGameObjectsWithTag("Shape");
        foreach (var shape in shapes)
        {
            Destroy(shape);
        }
    }
}