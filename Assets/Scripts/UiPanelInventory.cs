using System;
using TMPro;
using UnityEngine;
using static UiInvenSlotList;

public class UiPanelInventory : MonoBehaviour
{
    public TMP_Dropdown sorting;
    public TMP_Dropdown filtering;
    public TMP_Dropdown language;

    public UiInvenSlotList uiInvenSlotList;

    private void OnEnable()
    {
        OnLoad();
        OnChangeSorting(sorting.value);
        OnChangeFiltering(filtering.value);
    }

    public void OnChangeSorting(int index)
    {
        uiInvenSlotList.Sorting = (UiInvenSlotList.SortingOptions)index;
    }

    public void OnChangeFiltering(int index)
    {
        uiInvenSlotList.Filtering = (UiInvenSlotList.FilteringOptions)index;
    }

    public Languages GetLanguages(int index)
    {
        return (Languages)index;
    }

    public void OnSave()
    {
        SaveLoadManager.Data.ItemList = uiInvenSlotList.GetSaveItemDataList();
        SaveLoadManager.Data.itemSortingOption = uiInvenSlotList.Sorting.ToString();
        SaveLoadManager.Data.itemFilteringOption = uiInvenSlotList.Filtering.ToString();
        SaveLoadManager.Save();
    }

    public void OnLoad()
    {
        SaveLoadManager.Load();
        uiInvenSlotList.SetSaveItemDataList(SaveLoadManager.Data.ItemList);
        uiInvenSlotList.Sorting = Enum.Parse<SortingOptions>(SaveLoadManager.Data.itemSortingOption);
        uiInvenSlotList.Filtering = Enum.Parse<FilteringOptions>(SaveLoadManager.Data.itemFilteringOption);
        sorting.value = (int)uiInvenSlotList.Sorting;
        filtering.value = (int)uiInvenSlotList.Filtering;
    }

    public void OnCreateItem()
    {
        uiInvenSlotList.AddRandomItem();
    }

    public void OnRemoveItem()
    {
        uiInvenSlotList.RemoveItem();
    }
}