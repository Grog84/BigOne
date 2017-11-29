using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData
{
    public string Name;
    public GameObject Prefab;
}

[System.Serializable]
public class ItemBlock
{
    public string Name;
    [SerializeField]
    public List<ItemData> prefabsList = new List<ItemData>();
}

[CreateAssetMenu(menuName = "Tools/MapEditorDatabase")]
public class MapEditorDatabase : ScriptableObject
{
    //public List<ItemData> prefabsList = new List<ItemData>();
    public List<ItemBlock> blocksList = new List<ItemBlock>();
}
