using UnityEngine;
using UnityEngine.Events;
using System;

public class LevelLoad : MonoBehaviour
{
    [NonSerialized] public int levelIndex = -1;
    [Tooltip("if true will enable this gameobject (SetActive(true)) when this level is loaded (the function LoadLevel() is called)")][SerializeField] bool enableGameObjectOnLoad = true;
    [Tooltip("if true when this gameobject gets enabled (SetActive(true)) then call the function OnThisLevelEnter()")][SerializeField] bool enableAutoCallOnThisLevelEnter = true;
    [SerializeField] UnityEvent onLevelLoad;
    public void LoadLevel()
    {

        onLevelLoad?.Invoke();
        if (enableGameObjectOnLoad)
            gameObject.SetActive(true);

    }
    public void OnThisLevelEnter() => LoadSaveLevelManager.levelIndex = levelIndex;

    void OnEnable()
    {
        if (levelIndex == -1 || enableAutoCallOnThisLevelEnter == false)
            return;
        OnThisLevelEnter();
    }
}
