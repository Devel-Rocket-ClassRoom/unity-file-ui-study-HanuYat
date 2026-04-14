using UnityEngine;
using UnityEngine.UI;

public class ItemTableInfo : MonoBehaviour
{
    public Image itemImage;
    public LocalizationText textName;
    public LocalizationText textDesc;

    private void OnEnable()
    {
        SetEmpty();
    }

    public void SetEmpty()
    {
        itemImage.sprite = null;
        textName.id = string.Empty;
        textDesc.id = string.Empty;
        textName.text.text = string.Empty;
        textDesc.text.text = string.Empty;
    }

    public void SetItemData(string itemId)
    {
        ItemData itemData = DataTableManager.ItemTable.Get(itemId);
        SetItemData(itemData);
    }

    public void SetItemData(ItemData data)
    {
        itemImage.sprite = data.SPriteIcon;
        textName.id = data.Name;
        textDesc.id = data.Desc;

        textName.OnChangedId();
        textDesc.OnChangedId();
    }
}