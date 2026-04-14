using UnityEngine;

[ExecuteInEditMode]
public class ChangeCharacterLanguage : MonoBehaviour
{
    public LocalizationText textName;
    public LocalizationText textDesc;
    public LocalizationText textAttack;
    public LocalizationText textDefence;

    public LocalizationText textNameLabel;
    public LocalizationText textDescLabel;
    public LocalizationText textAttackLabel;
    public LocalizationText textDefenceLabel;
    public void OnChangeKorean()
    {
        textName.editorLang = Languages.Korean;
        textDesc.editorLang = Languages.Korean;
        textAttack.editorLang = Languages.Korean;
        textDefence.editorLang = Languages.Korean;
        textNameLabel.editorLang = Languages.Korean;
        textDescLabel.editorLang = Languages.Korean;
        textAttackLabel.editorLang = Languages.Korean;
        textDefenceLabel.editorLang = Languages.Korean;

        textName.OnChangedLang(Languages.Korean);
        textDesc.OnChangedLang(Languages.Korean);
        textAttack.OnChangedLang(Languages.Korean);
        textDefence.OnChangedLang(Languages.Korean);
        textNameLabel.OnChangedLang(Languages.Korean);
        textDescLabel.OnChangedLang(Languages.Korean);
        textAttackLabel.OnChangedLang(Languages.Korean);
        textDefenceLabel.OnChangedLang(Languages.Korean);
    }

    public void OnChangeJapanese()
    {
        textName.editorLang = Languages.Japanese;
        textDesc.editorLang = Languages.Japanese;
        textAttack.editorLang = Languages.Japanese;
        textDefence.editorLang = Languages.Japanese;
        textNameLabel.editorLang = Languages.Japanese;
        textDescLabel.editorLang = Languages.Japanese;
        textAttackLabel.editorLang = Languages.Japanese;
        textDefenceLabel.editorLang = Languages.Japanese;

        textName.OnChangedLang(Languages.Japanese);
        textDesc.OnChangedLang(Languages.Japanese);
        textAttack.OnChangedLang(Languages.Japanese);
        textDefence.OnChangedLang(Languages.Japanese);
        textNameLabel.OnChangedLang(Languages.Japanese);
        textDescLabel.OnChangedLang(Languages.Japanese);
        textAttackLabel.OnChangedLang(Languages.Japanese);
        textDefenceLabel.OnChangedLang(Languages.Japanese);
    }


    public void OnChangeEnglish()
    {
        textName.editorLang = Languages.English;
        textDesc.editorLang = Languages.English;
        textAttack.editorLang = Languages.English;
        textDefence.editorLang = Languages.English;
        textNameLabel.editorLang = Languages.English;
        textDescLabel.editorLang = Languages.English;
        textAttackLabel.editorLang = Languages.English;
        textDefenceLabel.editorLang = Languages.English;

        textName.OnChangedLang(Languages.English);
        textDesc.OnChangedLang(Languages.English);
        textAttack.OnChangedLang(Languages.English);
        textDefence.OnChangedLang(Languages.English);
        textNameLabel.OnChangedLang(Languages.English);
        textDescLabel.OnChangedLang(Languages.English);
        textAttackLabel.OnChangedLang(Languages.English);
        textDefenceLabel.OnChangedLang(Languages.English);
    }
}