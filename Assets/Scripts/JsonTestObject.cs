using UnityEngine;

public class JsonTestObject : MonoBehaviour
{
    public string prefabName;

    private Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    public void Set(ShapeData data)
    {
        //prefabName = data.prefabName;
        transform.position = data.pos;
        transform.rotation = data.rot;
        transform.localScale = data.scale;
        rend.material.color = data.color;
    }

    public ShapeData GetSaveData()
    {
        var shape = new ShapeData();
        shape.prefabName = prefabName;
        shape.pos = transform.position;
        shape.rot = transform.rotation;
        shape.scale = transform.localScale;
        shape.color = rend.material.color;

        return shape;
    }
}