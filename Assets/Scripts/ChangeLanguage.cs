using UnityEngine;

[ExecuteInEditMode]
public class ChangeLanguage : MonoBehaviour
{
#if UNITY_EDITOR
    private LocalizationText[] texts;
#endif

#if UNITY_EDITOR
    private void Update()
    {
        texts = GetComponentsInChildren<LocalizationText>();
    }
#endif

#if UNITY_EDITOR
    [ContextMenu("OnChangeKorean")]
    private void OnChangeKorean()
    {
        foreach (var text in texts)
        {
            text.editorLang = Languages.Korean;
            text.OnChangedLang(Languages.Korean);
        }
    }
#endif

#if UNITY_EDITOR
    [ContextMenu("OnChangeJapanese")]
    private void OnChangeJapanese()
    {
        foreach (var text in texts)
        {
            text.editorLang = Languages.Japanese;
            text.OnChangedLang(Languages.Japanese);
        }
    }
#endif


#if UNITY_EDITOR
    [ContextMenu("OnChangeEnglish")]
    private void OnChangeEnglish()
    {
        foreach (var text in texts)
        {
            text.editorLang = Languages.English;
            text.OnChangedLang(Languages.English);
        }
    }
#endif
}