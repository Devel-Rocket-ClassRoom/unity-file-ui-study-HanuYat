using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiCharSlotList : MonoBehaviour
{
    public enum SortingOptions
    {
        CreationTimeAscending,
        CreationTimeDescending,
        NameAscending,
        NameDescending,
        AttackAscending,
        AttackDescending
    }

    public enum FilteringOptions
    {
        None,
        Melee,
        Ranged
    }

    public readonly System.Comparison<SaveCharData>[] comparisons =
    {
        (lhs, rhs) => lhs.CreationTime.CompareTo(rhs.CreationTime),
        (lhs, rhs) => rhs.CreationTime.CompareTo(lhs.CreationTime),
        (lhs, rhs) => lhs.CharacterData.StringName.CompareTo(rhs.CharacterData.StringName),
        (lhs, rhs) => rhs.CharacterData.StringName.CompareTo(lhs.CharacterData.StringName),
        (lhs, rhs) => lhs.CharacterData.Attack.CompareTo(rhs.CharacterData.Attack),
        (lhs, rhs) => rhs.CharacterData.Defence.CompareTo(lhs.CharacterData.Defence)
    };

    public readonly System.Func<SaveCharData, bool>[] filterings =
    {
        (x) => true,
        (x) => x.CharacterData.Type == CharacterTypes.Melee,
        (x) => x.CharacterData.Type == CharacterTypes.Ranged,
    };

    public UnityEvent onUpdateSlots;
    public UnityEvent<SaveCharData> onSelectSlot;
    public UnityEvent<SaveCharData> onDeSelectSlot;

    public UiCharSlot prefab;
    public UiCharInfo uiCharInfo;
    public ScrollRect scrollRect;

    private List<UiCharSlot> uiSlotList = new List<UiCharSlot>();

    private List<SaveCharData> saveCharDataList = new List<SaveCharData>();

    private SortingOptions sorting = SortingOptions.CreationTimeAscending;
    private FilteringOptions filtering = FilteringOptions.None;

    private int selectedSlot = -1;

    public SortingOptions Sorting
    {
        get => sorting;

        set
        {
            if (sorting != value)
            {
                sorting = value;
                UpdateSlots();
            }
        }
    }

    public FilteringOptions Filtering
    {
        get => filtering;

        set
        {
            if (filtering != value)
            {
                filtering = value;
                UpdateSlots();
            }
        }
    }

    private void Start()
    {
        onSelectSlot.AddListener(OnSelectSlot);
        onDeSelectSlot.AddListener(OnDeSelectSlot);
    }

    public void SetSaveCharDataList(List<SaveCharData> source)
    {
        saveCharDataList = source.ToList();
        UpdateSlots();
    }

    public List<SaveCharData> GetSaveCharDataList()
    {
        return saveCharDataList;
    }

    private void OnSelectSlot(SaveCharData data)
    {
        uiCharInfo.SetItem(data);
        Debug.Log(data);
    }

    private void OnDeSelectSlot(SaveCharData data)
    {
        uiCharInfo.SetEmpty();
    }

    private void UpdateSlots()
    {
        var list = saveCharDataList.Where(filterings[(int)filtering]).ToList();
        list.Sort(comparisons[(int)sorting]);

        if (uiSlotList.Count < list.Count)
        {
            for (int i = uiSlotList.Count; i < list.Count; i++)
            {
                var newSlot = Instantiate(prefab, scrollRect.content);
                newSlot.slotIndex = i;
                newSlot.SetEmpty();
                newSlot.gameObject.SetActive(false);

                newSlot.slotButton.onClick.AddListener(() =>
                {
                    selectedSlot = newSlot.slotIndex;
                    onSelectSlot?.Invoke(newSlot.SaveCharData);
                });

                uiSlotList.Add(newSlot);
            }
        }

        for (int i = 0; i < uiSlotList.Count; i++)
        {
            if (i < list.Count)
            {
                uiSlotList[i].gameObject.SetActive(true);
                uiSlotList[i].SetItem(list[i]);
            }
            else
            {
                uiSlotList[i].gameObject.SetActive(false);
                uiSlotList[i].SetEmpty();
            }
        }

        selectedSlot = -1;
        onUpdateSlots?.Invoke();
    }

    public void AddRandomCharacter()
    {
        saveCharDataList.Add(SaveCharData.GetRandomCharacter());
        UpdateSlots();
    }

    public void RemoveCharacter()
    {
        if (selectedSlot == -1)
        {
            return;
        }

        saveCharDataList.Remove(uiSlotList[selectedSlot].SaveCharData);
        UpdateSlots();
    }
}