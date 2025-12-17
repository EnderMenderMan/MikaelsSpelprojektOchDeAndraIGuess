using AYellowpaper.SerializedCollections;
using UnityEngine;

public class SpecialCharactersUI : MonoBehaviour
{
    public static SpecialCharactersUI Instance { get; private set; }
    public enum Character
    {
        BasicRune,
        KickRune,
        WallRune,
        LockRune,
    }
    [SerializeField] Transform characterHolder;
    [SerializedDictionary("Character", "Prefab")] public SerializedDictionary<Character, GameObject> prefabs;

    public GameObject Create(Character character, Vector3 position, string id = "None")
    {
        GameObject prefab;
        if (prefabs.TryGetValue(character, out prefab) == false)
            return null;

        GameObject createdGameObject = Instantiate(prefab, position, Quaternion.identity, characterHolder);
        createdGameObject.name = id;
        return createdGameObject;
    }
    public void Destory(string id)
    {
        foreach (Transform child in characterHolder.GetComponentInChildren<Transform>())
        {
            if (child.transform == characterHolder.transform || child.name != id)
                continue;
            Destroy(child.gameObject);
        }
    }
    public GameObject GetPrefab(Character character)
    {
        GameObject prefab;
        if (prefabs.TryGetValue(character, out prefab) == false)
            return null;
        return prefab;

    }
    void Awake()
    {
        Instance = this;
    }
}
