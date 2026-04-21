using System;
using TMPro;
using UnityEngine;
using static UiCharSlotList;

public class UiCharInventory : MonoBehaviour
{
    public TMP_Dropdown sorting;
    public TMP_Dropdown filtering;

    public UiCharSlotList uiCharSlotList;

    private void OnEnable()
    {
        OnLoad();
        OnChangeSorting(sorting.value);
        OnChangeFiltering(filtering.value);
    }

    public void OnChangeSorting(int index)
    {
        uiCharSlotList.Sorting = (UiCharSlotList.SortingOptions)index;
    }

    public void OnChangeFiltering(int index)
    {
        uiCharSlotList.Filtering = (UiCharSlotList.FilteringOptions)index;
    }

    public Languages GetLanguages(int index)
    {
        return (Languages)index;
    }

    public void OnSave()
    {
        SaveLoadManager.Data.CharList = uiCharSlotList.GetSaveCharDataList();
        SaveLoadManager.Data.charSortingOption = uiCharSlotList.Sorting.ToString();
        SaveLoadManager.Data.charFilteringOption = uiCharSlotList.Filtering.ToString();
        SaveLoadManager.Save();
    }

    public void OnLoad()
    {
        SaveLoadManager.Load();
        uiCharSlotList.SetSaveCharDataList(SaveLoadManager.Data.CharList);
        uiCharSlotList.Sorting = Enum.Parse<SortingOptions>(SaveLoadManager.Data.charSortingOption);
        uiCharSlotList.Filtering = Enum.Parse<FilteringOptions>(SaveLoadManager.Data.charFilteringOption);
        sorting.value = (int)uiCharSlotList.Sorting;
        filtering.value = (int)uiCharSlotList.Filtering;
    }

    public void OnAdd()
    {
        uiCharSlotList.AddRandomCharacter();
    }

    public void OnRemove()
    {
        uiCharSlotList.RemoveCharacter();
    }
}