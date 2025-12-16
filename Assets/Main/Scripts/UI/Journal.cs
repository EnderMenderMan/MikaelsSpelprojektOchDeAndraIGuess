using UnityEngine;
using System;
using AYellowpaper.SerializedCollections;
using System.Collections.Generic;

public class Journal : MonoBehaviour, IDataPersitiens
{
    [Tooltip("The text where the hints are writen to (Temporary)")][SerializeField] TMPro.TextMeshProUGUI textElement;
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
    public enum HintState
    {
        NotAdded,
        Added,
        Removed,
    }

    [System.Serializable]
    public struct Hint
    {
        [NonSerialized] public HintState state;
        public string normal;
        public string hard;
    }
    [SerializedDictionary("HintType", "Hint")] public SerializedDictionary<HintType, Hint> hints;
    Hint[] hintsArray;


    public void TryAddHint(HintType hintType)
    {
        if (hintsArray[(int)hintType].state == HintState.Added)
            return;

        hintsArray[(int)hintType].state = HintState.Added;
        switch (GameData.difficulty)
        {
            case GameData.Difficulty.Normal:
                textElement.text += hintsArray[(int)hintType].normal + '\n';
                break;
            case GameData.Difficulty.Hard:
                textElement.text += hintsArray[(int)hintType].hard + '\n';
                break;
        }
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
                case HintState.Added:
                    TryAddHint((HintType)i);
                    break;
            }
        }
    }

    public void SaveData(ref GameData data)
    {
        data.journal.hintStates = new HintState[hintsArray.Length];
        for (int i = 0; i < hintsArray.Length; i++)
        {
            data.journal.hintStates[i] = hintsArray[i].state;
        }
    }
}
