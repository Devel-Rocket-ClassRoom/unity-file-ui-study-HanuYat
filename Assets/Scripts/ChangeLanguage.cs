using UnityEngine;
using TMPro;

[ExecuteInEditMode]
public class ChangeLanguage : MonoBehaviour
{
    public LocalizationText[] texts;
    public LocalizationDropDown[] dropDowns;

    public TMP_Dropdown language;

    private void OnEnable()
    {
        texts = GetComponentsInChildren<LocalizationText>();
        dropDowns = GetComponentsInChildren<LocalizationDropDown>();
    }

    public void OnChangeLanguage()
    {
        if (language.value == 0)
        {
            OnChangeKorean();
        }

        if (language.value == 1)
        {
            OnChangeEnglish();
        }

        if (language.value == 2)
        {
            OnChangeJapanese();
        }
    }

    public void OnChangeKorean()
    {
        foreach (var text in texts)
        {
            text.editorLang = Languages.Korean;
            text.OnChangedId();
            text.OnChangedLang(Languages.Korean);
        }

        foreach (var dropDown in dropDowns)
        {
            dropDown.editorLang = Languages.Korean;
            dropDown.OnChangeLanguage(dropDown.editorLang);
        }
    }

    public void OnChangeJapanese()
    {
        foreach (var text in texts)
        {
            text.editorLang = Languages.Japanese;
            text.OnChangedId();
            text.OnChangedLang(Languages.Japanese);
        }

        foreach (var dropDown in dropDowns)
        {
            dropDown.editorLang = Languages.Japanese;
        }
    }


    public void OnChangeEnglish()
    {
        foreach (var text in texts)
        {
            text.editorLang = Languages.English;
            text.OnChangedId();
            text.OnChangedLang(Languages.English);
        }

        foreach (var dropDown in dropDowns)
        {
            dropDown.editorLang = Languages.English;
        }
    }
}