using UnityEngine;

[ExecuteInEditMode]
public class ChangeLanguage : MonoBehaviour
{
    public LocalizationText text;

    public void OnChangeKorean()
    {
        text.editorLang = Languages.Korean;
        text.OnChangedLang(Languages.Korean);
    }

    public void OnChangeJapanese()
    {
        text.editorLang = Languages.Japanese;
        text.OnChangedLang(Languages.Japanese);
    }


    public void OnChangeEnglish()
    {
        text.editorLang = Languages.English;
        text.OnChangedLang(Languages.English);
    }
}