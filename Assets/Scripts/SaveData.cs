using System;
using System.Collections.Generic;

[Serializable]
public abstract class SaveData
{
    public int Version { get; protected set; }

    public abstract SaveData VersionUp();
}

[Serializable]
public class SaveDataV1 : SaveData
{
    public string PlayerName { get; set; } = string.Empty;

    public SaveDataV1()
    {
        Version = 1;
    }

    public override SaveData VersionUp()
    {
        var saveData = new SaveDataV2();
        saveData.Name = PlayerName;
        return saveData;
    }
}

[Serializable]
public class SaveDataV2 : SaveData
{
    public string Name { get; set; } = string.Empty;
    public int Gold { get; set; } = 0;

    public SaveDataV2()
    {
        Version = 2;
    }

    public override SaveData VersionUp()
    {
        var saveData = new SaveDataV3();
        saveData.Name = Name;
        saveData.Gold = Gold;
        return saveData;
    }
}

[Serializable]
public class SaveDataV3 : SaveData
{
    public string Name { get; set; }
    public int Gold { get; set; }
    public List<string> Items { get; set; } = new List<string>();

    public SaveDataV3()
    {
        Version = 3;
    }

    public override SaveData VersionUp()
    {
        var saveData = new SaveDataV4();
        saveData.Name = Name;
        saveData.Gold = Gold;

        foreach (var item in Items)
        {
            var itemData = new SaveItemData();
            itemData.ItemData = DataTableManager.ItemTable.Get(item);

            saveData.ItemList.Add(itemData);
        }

        return saveData;
    }
}

[Serializable]
public class SaveDataV4 : SaveDataV2
{
    public List<SaveItemData> ItemList { get; set; } = new List<SaveItemData>();

    public SaveDataV4()
    {
        Version = 4;
    }
}