using UnityEngine;

[System.Serializable]
public class DropableItem {

    public string name;

    [Range(0.01f, 1f)]
    public float chance;

    public GameObject gameObject;
}
