using UnityEngine;
using UnityEngine.UI;

public class DifficultyWindow : GenericWindow
{
    public Toggle[] toggles;

    public Button cancelButton;
    public Button applyButton;

    public int selected;
    private int previousSelect;

    private void Awake()
    {
        toggles[0].onValueChanged.AddListener(OnEasy);
        toggles[1].onValueChanged.AddListener(OnNormal);
        toggles[2].onValueChanged.AddListener(OnHard);

        cancelButton.onClick.AddListener(OnCancel);
        applyButton.onClick.AddListener(OnApply);
    }

    public override void Open()
    {
        base.Open();
        toggles[selected].isOn = true;
        previousSelect = selected;
    }

    public override void Close()
    {
        base.Close();
    }

    public void OnEasy(bool active)
    {
        if (active)
        {
            selected = 0;
            Debug.Log("OnEasy");
        }
    }

    public void OnNormal(bool active)
    {
        if (active)
        {
            selected = 1;
            Debug.Log("OnNormal");
        }
    }

    public void OnHard(bool active)
    {
        if (active)
        {
            selected = 2;
            Debug.Log("OnHard");
        }
    }

    public void OnCancel()
    {
        selected = previousSelect;
        windowManager.Open(0);
    }

    public void OnApply()
    {
        windowManager.Open(0);
    }
}