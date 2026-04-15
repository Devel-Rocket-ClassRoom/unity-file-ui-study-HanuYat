using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerInfo
{
    public string playerName;
    public int lives;
    public float health;
    public Vector3 position;

    // 무시됨
    public Dictionary<string, int> scores = new Dictionary<string, int>
    {
        { "stage1", 100 },
        { "stage2", 200 }
    };
}

public class JsonUtilityTest : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //save
            var obj = new PlayerInfo
            {
                playerName = "ABC",
                lives = 10,
                health = 10.999f,
                position = new Vector3(1f, 2f, 3f)
            };

            var folderPath = Path.Combine(Application.persistentDataPath, "JsonTest");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var path = Path.Combine(folderPath, "Player.Json");
            var json = JsonUtility.ToJson(obj, prettyPrint: true);
            File.WriteAllText(path, json);

            Debug.Log(path);
            Debug.Log(json);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Load
            var path = Path.Combine(Application.persistentDataPath, "JsonTest", "Player.Json");
            var json = File.ReadAllText(path);

            //var obj = JsonUtility.FromJson<PlayerInfo>(json);
            var obj = new PlayerInfo();
            JsonUtility.FromJsonOverwrite(json, obj);

            Debug.Log($"{obj.playerName} / {obj.lives} / {obj.health} / {obj.position}");
            Debug.Log(json);
        }
    }
}