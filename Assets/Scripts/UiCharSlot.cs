using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiCharSlot : MonoBehaviour
{
    public int slotIndex = -1;

    public Image charImage;
    public TextMeshProUGUI charName;

    public SaveCharData SaveCharData { get; private set; }

    public Button slotButton;

    public void SetEmpty()
    {
        charImage.sprite = null;
        charName.text = string.Empty;
        SaveCharData = null;
    }

    public void SetItem(SaveCharData data)
    {
        SaveCharData = data;
        charImage.sprite = SaveCharData.CharacterData.SPriteIcon;
        charName.text = SaveCharData.CharacterData.StringName;
    }
}