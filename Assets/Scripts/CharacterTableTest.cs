using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class CharacterTableTest : MonoBehaviour
{
    public string id;

    public Image itemImage;
    public LocalizationText textName;

    public CharacterTableInfo characterTableInfo;

    private void OnEnable()
    {
        OnChangeCharacterId();
    }

    private void OnValidate()
    {
        OnChangeCharacterId();
    }

    public void OnChangeCharacterId()
    {
        CharacterData data = DataTableManager.CharacterTable.Get(id);
        if (data != null)
        {
            itemImage.sprite = data.SPriteIcon;
            textName.id = data.Name;

            textName.OnChangedId();
        }
    }

    public void OnClick()
    {
        characterTableInfo.SetCharacterData(id);
    }
}