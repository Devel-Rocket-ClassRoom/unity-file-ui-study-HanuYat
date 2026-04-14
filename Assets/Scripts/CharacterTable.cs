using System.Collections.Generic;
using UnityEngine;

// ID, 이름, 설명, 공격력, 캐릭터아이콘
// DataTable 상속
// DataTableManager 등록
// 테스트 패널
public class CharacterData
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Desc { get; set; }
    public string Attack { get; set; }
    public string Defence { get; set; }
    public string Icon { get; set; }
    public string NameLabel { get; set; }
    public string DescLabel { get; set; }
    public string AttackLabel { get; set; }
    public string DefenceLabel { get; set; }

    public string StringName => DataTableManager.StringTable.Get(Name);
    public string StringDesc => DataTableManager.StringTable.Get(Desc);
    public Sprite SPriteIcon => Resources.Load<Sprite>($"Icon/{Icon}");

    public override string ToString()
    {
        return $"{Id} / {Name} / {Desc} / {Attack} / {Defence} / {Icon} / {NameLabel} / {DescLabel} / {AttackLabel} / {DefenceLabel}";
    }
}

public class CharacterTable : DataTable
{
    private readonly Dictionary<string, CharacterData> table = new Dictionary<string, CharacterData>();

    public override void Load(string fileName)
    {
        table.Clear();

        var path = string.Format(FormatPath, fileName);
        var textAsset = Resources.Load<TextAsset>(path);
        var list = LoadCSV<CharacterData>(textAsset.text);

        foreach (var character in list)
        {
            if (!table.ContainsKey(character.Id))
            {
                table.Add(character.Id, character);
            }
            else
            {
                Debug.LogError($"캐릭터 아이디 중복: {character.Id}");
            }
        }
    }

    public CharacterData Get(string id)
    {
        if (!table.ContainsKey(id))
        {
            Debug.LogError($"캐릭터 아이디 없음: {id}");
            return null;
        }
        return table[id];
    }
}