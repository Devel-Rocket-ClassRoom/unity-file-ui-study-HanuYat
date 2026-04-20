using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//Id, Type, Name, Desc, Value, Cost, Icon

public class ItemData
{
    public string Id { get; set; }
    public ItemTypes Type { get; set; }
    public string Name { get; set; }
    public string Desc { get; set; }
    public int Value { get; set; }
    public int Cost { get; set; }
    public string Icon { get; set; }
    public string StringName => DataTableManager.StringTable.Get(Name);
    public string StringDesc => DataTableManager.StringTable.Get(Desc);
    public Sprite SPriteIcon => Resources.Load<Sprite>($"Icon/{Icon}");

    public override string ToString()
    {
        return $"{Id} / {Type} / {Name} / {Desc} / {Value} / {Cost} / {Icon}";
    }
}

public class ItemTable : DataTable
{
    private readonly Dictionary<string, ItemData> table = new Dictionary<string, ItemData>();

    private List<string> keyList = new List<string>();

    public override void Load(string fileName)
    {
        table.Clear();

        var path = string.Format(FormatPath, fileName);
        var textAsset = Resources.Load<TextAsset>(path);
        var list = LoadCSV<ItemData>(textAsset.text);

        foreach (var item in list)
        {
            if (!table.ContainsKey(item.Id))
            {
                table.Add(item.Id, item);
            }
            else
            {
                Debug.LogError($"아이템 아이디 중복: {item.Id}");
            }
        }

        keyList = table.Keys.ToList();
    }

    public ItemData Get(string id)
    {
        if (!table.ContainsKey(id))
        {
            Debug.LogError($"아이템 아이디 없음: {id}");
            return null;
        }
        return table[id];
    }

    public ItemData GetRandom()
    {
        return Get(keyList[Random.Range(0, keyList.Count)]);
    }
}