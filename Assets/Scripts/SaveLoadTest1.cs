using UnityEngine;
using SaveDataVC = SaveDataV4;

public class SaveLoadTest1 : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SaveLoadManager.Data = new SaveDataVC();
            SaveLoadManager.Data.Name = "Hero";
            SaveLoadManager.Data.Gold = 1500;
            SaveLoadManager.Save();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (SaveLoadManager.Load())
            {
                Debug.Log(SaveLoadManager.Data.Name);
                Debug.Log(SaveLoadManager.Data.Gold);

                foreach (var saveItemData in SaveLoadManager.Data.ItemList)
                {
                    Debug.Log(saveItemData.InstanceId);
                    Debug.Log(saveItemData.ItemData.Name);
                    Debug.Log(saveItemData.CreationTime);
                }
            }
            else
            {
                Debug.Log("세이브 파일 없음.");
            }
        }
    }
}