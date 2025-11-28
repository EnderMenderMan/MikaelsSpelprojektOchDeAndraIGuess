using System;
using System.Linq;
using UnityEngine;

public class TransformRune : Rune
{
    Rune selectedChild;
    [SerializeField] Rune[] runes;
    int selectedRuneIndex;

    public void SwapSelectedRune(Alter currentAlter = null)
    {
        selectedRuneIndex++;
        selectedRuneIndex %= runes.Length;
        selectedChild.gameObject.SetActive(false);
        if (currentAlter != null)
            SwapAlterPlace(currentAlter);
        selectedChild = runes[selectedRuneIndex];
    }

    void SwapAlterPlace(Alter alter)
    {
        alter.equippedRune = runes[selectedRuneIndex];
    }

    public override void TriggerRunePlacement(int itemIndex, Alter[] alters) => selectedChild.TriggerRunePlacement(itemIndex, alters);
    public override bool TryBePlaced(int alterIndex, Alter[] alters, AlterCluster cluster) => selectedChild.TryBePlaced(alterIndex, alters, cluster);
}
