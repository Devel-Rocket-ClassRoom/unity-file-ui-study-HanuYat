using Newtonsoft.Json;
using System;

[Serializable]
public class SaveItemData
{
    public Guid InstanceId { get; set; }

    [JsonConverter(typeof(ItemDataConverter))]
    public ItemData ItemData { get; set; }
    public DateTime CreationTime { get; set; }

    public SaveItemData()
    {
        InstanceId = Guid.NewGuid();
        CreationTime = DateTime.Now;
    }

    public static SaveItemData GetRandomItem()
    {
        var newItem = new SaveItemData();
        newItem.ItemData = DataTableManager.ItemTable.GetRandom();

        return newItem;
    }
}