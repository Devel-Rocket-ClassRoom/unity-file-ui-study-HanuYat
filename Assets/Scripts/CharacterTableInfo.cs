using UnityEngine;
using UnityEngine.UI;

public class CharacterTableInfo : MonoBehaviour
{
    public Image itemImage;
    public LocalizationText textName;
    public LocalizationText textDesc;
    public LocalizationText textAttack;
    public LocalizationText textDefence;

    public LocalizationText textNameLabel;
    public LocalizationText textDescLabel;
    public LocalizationText textAttackLabel;
    public LocalizationText textDefenceLabel;
    private void OnEnable()
    {
        SetEmpty();
    }

    public void SetEmpty()
    {
        itemImage.sprite = null;
        textName.id = string.Empty;
        textDesc.id = string.Empty;
        textAttack.id = string.Empty;
        textDefence.id = string.Empty;

        textName.text.text = string.Empty;
        textDesc.text.text = string.Empty;
        textAttack.text.text = string.Empty;
        textDefence.text.text = string.Empty;
    }

    public void SetCharacterData(string charId)
    {
        CharacterData charaterData = DataTableManager.CharacterTable.Get(charId);
        SetCharacterData(charaterData);
    }

    public void SetCharacterData(CharacterData data)
    {
        itemImage.sprite = data.SPriteIcon;
        textName.id = data.Name;
        textDesc.id = data.Desc;
        textAttack.id = data.Attack;
        textDefence.id = data.Defence;

        textNameLabel.id = data.NameLabel;
        textDescLabel.id = data.DescLabel;
        textAttackLabel.id = data.AttackLabel;
        textDefenceLabel.id = data.DefenceLabel;

        textName.OnChangedId();
        textDesc.OnChangedId();
        textAttack.OnChangedId();
        textDefence.OnChangedId();

        textNameLabel.OnChangedId();
        textDescLabel.OnChangedId();
        textAttackLabel.OnChangedId();
        textDefenceLabel.OnChangedId();
    }
}