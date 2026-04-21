using Newtonsoft.Json;
using System;

[Serializable]
public class SaveCharData
{
    public Guid InstanceId { get; set; }

    [JsonConverter(typeof(CharacterDataConverter))]
    public CharacterData CharacterData { get; set; }
    public DateTime CreationTime { get; set; }

    public SaveCharData()
    {
        InstanceId = Guid.NewGuid();
        CreationTime = DateTime.Now;
    }

    public static SaveCharData GetRandomCharacter()
    {
        var newChar = new SaveCharData();
        newChar.CharacterData = DataTableManager.CharacterTable.GetRandom();

        return newChar;
    }

    public override string ToString()
    {
        return $"{InstanceId} / {CharacterData.StringName} / {CreationTime}";
    }
}