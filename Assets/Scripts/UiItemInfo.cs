using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiItemInfo : MonoBehaviour
{
    public Image itemIcon;

    public TextMeshProUGUI itemType;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDesc;
    public TextMeshProUGUI itemValue;
    public TextMeshProUGUI itemCost;

    public void SetEmpty()
    {
        itemIcon.sprite = null;
        itemType.text = string.Empty;
        itemName.text = string.Empty;
        itemDesc.text = string.Empty;
        itemValue.text = string.Empty;
        itemCost.text = string.Empty;
    }

    public void SetItem(SaveItemData saveItemData)
    {
        var data = saveItemData.ItemData;

        itemIcon.sprite = data.SPriteIcon;
        itemType.text = string.Concat($"{DataTableManager.StringTable.Get("Type")}: ", data.StringType);
        itemName.text = string.Concat($"{DataTableManager.StringTable.Get("Name")}: ", data.StringName);
        itemDesc.text = string.Concat($"{DataTableManager.StringTable.Get("Desc")}: ", data.StringDesc);
        itemValue.text = string.Concat($"{DataTableManager.StringTable.Get("Value")}: ", data.Value.ToString());
        itemCost.text = string.Concat($"{DataTableManager.StringTable.Get("Cost")}: ", data.Cost.ToString());
    }
}