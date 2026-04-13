using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class LocalizationText : MonoBehaviour
{
#if UNITY_EDITOR
    public Languages editorLang;
#endif

    public string id;
    public TextMeshProUGUI text;


    private void OnEnable()
    {
        if (Application.isPlaying)
        {
            Variables.OnLanguageChanged += OnChangedLang;
            OnChangedLang();
        }
#if UNITY_EDITOR
        else
        {
            OnChangedLang(editorLang);
        }
#endif
    }

    private void OnDisable()
    {
        if (Application.isPlaying)
        {
            Variables.OnLanguageChanged -= OnChangedLang;
        }
    }

    private void OnValidate()
    {
#if UNITY_EDITOR
        OnChangedLang(editorLang);
#endif
    }

    public void OnChangedLang()
    {
        text.text = DataTableManager.StringTable.Get(id);
    }

#if UNITY_EDITOR
    private void OnChangedLang(Languages lang)
    {
        var stringTable = DataTableManager.GetStringTable(lang);
        text.text = stringTable.Get(id);
    }
#endif
}