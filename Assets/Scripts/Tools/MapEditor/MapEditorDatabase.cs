using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData
{
    public string Name;
    public GameObject Prefab;
}

[CreateAssetMenu(menuName = "Tools/MapEditorDatabase")]
public class MapEditorDatabase : ScriptableObject
{
    public List<ItemData> prefabsList = new List<ItemData>();
}
