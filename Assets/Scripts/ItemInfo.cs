using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class ItemInfo : MonoBehaviour
{
    public string id;

    public Image itemImage;
    public LocalizationText textName;

    public ItemTableInfo itemTableInfo;

    private void OnEnable()
    {
        OnChangeItemId();
    }

    private void OnValidate()
    {
        OnChangeItemId();
    }

    public void OnChangeItemId()
    {
        ItemData data = DataTableManager.ItemTable.Get(id);
        if (data != null)
        {
            itemImage.sprite = data.SPriteIcon;
            textName.id = data.Name;

            textName.OnChangedId();
        }
    }

    public void OnClick()
    {
        itemTableInfo.SetItemData(id);
    }
}