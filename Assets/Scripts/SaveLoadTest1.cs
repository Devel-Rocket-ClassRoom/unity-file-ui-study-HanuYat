using UnityEngine;
using SaveDataVC = SaveDataV3;

public class SaveLoadTest1 : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SaveLoadManager.Data = new SaveDataVC();
            SaveLoadManager.Data.Name = "Hero";
            SaveLoadManager.Data.Gold = 1500;
            SaveLoadManager.Data.Items.Add("Item1");
            SaveLoadManager.Data.Items.Add("Item2");
            SaveLoadManager.Data.Items.Add("Item3");
            SaveLoadManager.Data.Items.Add("Item4");
            SaveLoadManager.Save();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (SaveLoadManager.Load())
            {
                Debug.Log(SaveLoadManager.Data.Name);
                Debug.Log(SaveLoadManager.Data.Gold);

                foreach (var itemId in SaveLoadManager.Data.Items)
                {
                    Debug.Log(DataTableManager.ItemTable.Get(itemId).Name);
                }
            }
            else
            {
                Debug.Log("세이브 파일 없음.");
            }
        }
    }
}