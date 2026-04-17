using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardWindow : GenericWindow
{
    private readonly StringBuilder sb = new StringBuilder();
    public GameObject rootKeyboard;
    public TextMeshProUGUI inputText;

    public Button cancelButton;
    public Button deleteButton;
    public Button acceptButton;

    public int maxTextLength = 7;

    private float timer = 0f;
    private float delay = 0.7f;
    private bool isBlink = false;

    private void Awake()
    {
        var buttons = rootKeyboard.GetComponentsInChildren<Button>();
        foreach (var button in buttons)
        {
            var text = button.GetComponentInChildren<TextMeshProUGUI>();
            button.onClick.AddListener(() => OnKey(text.text));
        }

        cancelButton.onClick.AddListener(OnCancel);
        deleteButton.onClick.AddListener(OnDelete);
        acceptButton.onClick.AddListener(OnAccept);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > delay)
        {
            timer = 0f;
            isBlink = !isBlink;
            UpdateInputText();
        }
    }

    public override void Open()
    {
        base.Open();
        sb.Clear();
        UpdateInputText();
    }


    public void OnCancel()
    {
        sb.Clear();
        UpdateInputText();
    }

    public void OnDelete()
    {
        if (sb.Length > 0)
        {
            sb.Length -= 1;
            UpdateInputText();
        }
    }

    public void OnAccept()
    {
        windowManager.Open(0);
    }

    public void OnKey(string Key)
    {
        if (sb.Length < maxTextLength)
        {
            sb.Append(Key);
            UpdateInputText();
        }
    }

    private void UpdateInputText()
    {
        bool showCursor = sb.Length < maxTextLength && !isBlink;
        if (showCursor)
        {
            sb.Append('_');
        }
        inputText.SetText(sb);
        if (showCursor)
        {
            sb.Length -= 1;
        }
    }
}