using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiInvenSlot : MonoBehaviour
{
    public int slotIndex = -1;

    public Image itemImage;
    public TextMeshProUGUI itemName;

    public SaveItemData SaveItemData { get; private set; }

    public Button slotButton;

    public void SetEmpty()
    {
        itemImage.sprite = null;
        itemName.text = string.Empty;
        SaveItemData = null;
    }

    public void SetItem(SaveItemData data)
    {
        SaveItemData = data;
        itemImage.sprite = SaveItemData.ItemData.SPriteIcon;
        itemName.text = SaveItemData.ItemData.StringName;
    }
}