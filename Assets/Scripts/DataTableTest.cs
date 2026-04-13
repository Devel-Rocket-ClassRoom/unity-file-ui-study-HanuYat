using UnityEngine;

public class DataTableTest : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Variables.Language = Languages.Korean;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Variables.Language = Languages.English;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Variables.Language = Languages.Japanese;
        }
    }

    public void OnClickStringTableKr()
    {
        var table = DataTableManager.StringTable.Get("You Die");
    }

    public void OnClickStringTableEn()
    {
        var table = DataTableManager.StringTable.Get("You Live");
    }

    public void OnClickStringTableJp()
    {
        var table = DataTableManager.StringTable.Get("Hello");
    }
}