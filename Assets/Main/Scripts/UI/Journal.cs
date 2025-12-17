using UnityEngine;
using System;
using AYellowpaper.SerializedCollections;
using System.Collections.Generic;
using TMPro;

public class Journal : MonoBehaviour, IDataPersitiens
{
    public static Journal Instance { get; private set; }
    public enum HintType
    {
        BasicRune,
        GrowRune,
        HideRune,
        KickRune,
        LockRune,
        SeeRune,
        RunRune,
        ShootRune,
        SpeedRune,
        SwapRune,
        TransformRune,
        WallRune,
        LastElementUsedOnlyForCode,
    }
    // public enum HintState
    // {
    //     NotAdded,
    //     Added,
    //     Removed,
    // }

    [System.Serializable]
    public struct Hint
    {
        [NonSerialized] public int state;
        public TextMeshProUGUI textElement;
        [TextArea(1, 3)] public string[] esay;
        [TextArea(1, 3)] public string[] normal;
        [TextArea(1, 3)] public string[] hard;
    }
    int hintOrderIndex;
    [SerializeField] HintType[] hintOrder;
    [SerializedDictionary("HintType", "Hint")] public SerializedDictionary<HintType, Hint> hints;
    Hint[] hintsArray;


    public void TriggerNextHint()
    {

        if (hintOrderIndex >= hintOrder.Length)
            return;


        TryTriggerHint(hintOrder[hintOrderIndex]);
        hintOrderIndex++;

        return;
    }
    public bool TryTriggerHint(HintType hintType)
    {
        if (hintsArray[(int)hintType].state < 0)
            return false;

        if (hintsArray[(int)hintType].textElement == null)
            return true;

        Hint targetHint = hintsArray[(int)hintType];
        switch (GameData.difficulty)
        {
            case GameData.Difficulty.Easy:
                TrySetTextElementHint(targetHint, targetHint.esay);
                break;
            case GameData.Difficulty.Normal:
                TrySetTextElementHint(targetHint, targetHint.normal);
                break;
            case GameData.Difficulty.Hard:
                TrySetTextElementHint(targetHint, targetHint.hard);
                break;
        }
        hintsArray[(int)hintType].state++;
        return true;
    }
    bool TrySetTextElementHint(Hint hint, string[] textArray)
    {
        int arrayIndex = hint.state;
        if (textArray.Length <= arrayIndex)
            return false;

        hint.textElement.text = textArray[arrayIndex];
        return true;
    }

    void Awake()
    {
        Instance = this;
        hintsArray = new Hint[(int)HintType.LastElementUsedOnlyForCode];
        foreach (KeyValuePair<HintType, Hint> keyValuePair in hints)
            hintsArray[(int)keyValuePair.Key] = keyValuePair.Value;
        hints.Clear();

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadData(GameData data)
    {
        if (data.journal.hintStates == null || hintsArray == null)
            return;

        for (int i = 0; i < hintsArray.Length && i < data.journal.hintStates.Length; i++)
        {
            if (hintsArray[i].state == data.journal.hintStates[i])
                continue;
            hintsArray[i].state = data.journal.hintStates[i];
            switch (hintsArray[i].state)
            {
                case 1:
                    TryTriggerHint((HintType)i);
                    break;
            }
        }
    }

    public void SaveData(ref GameData data)
    {
        data.journal.hintStates = new int[hintsArray.Length];
        for (int i = 0; i < hintsArray.Length; i++)
        {
            data.journal.hintStates[i] = hintsArray[i].state;
        }
    }
}
