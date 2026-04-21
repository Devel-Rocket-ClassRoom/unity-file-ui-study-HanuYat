using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiCharInfo : MonoBehaviour
{
    public Image charIcon;

    public TextMeshProUGUI charType;
    public TextMeshProUGUI charName;
    public TextMeshProUGUI charDesc;
    public TextMeshProUGUI charAttack;
    public TextMeshProUGUI charDefence;

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    SetEmpty();
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    SetItem(SaveItemData.GetRandomItem());
        //    Debug.Log("SetItem");
        //}
    }

    public void SetEmpty()
    {
        charIcon.sprite = null;
        charType.text = string.Empty;
        charName.text = string.Empty;
        charDesc.text = string.Empty;
        charAttack.text = string.Empty;
        charDefence.text = string.Empty;
    }

    public void SetItem(SaveCharData saveItemData)
    {
        var data = saveItemData.CharacterData;

        charIcon.sprite = data.SPriteIcon;
        charType.text = string.Concat($"{DataTableManager.StringTable.Get("Type")}: ", data.Type.ToString().ToUpper());
        charName.text = string.Concat($"{DataTableManager.StringTable.Get("Name")}: ", data.StringName);
        charDesc.text = string.Concat($"{DataTableManager.StringTable.Get("Desc")}: ", data.StringDesc);
        charAttack.text = string.Concat($"{DataTableManager.StringTable.Get("Attack")}: ", data.StringAttack);
        charDefence.text = string.Concat($"{DataTableManager.StringTable.Get("Defence")}: ", data.StringDefence);
    }
}