using System;
using JetBrains.Annotations;
using UnityEngine;

public abstract class Rune : MonoBehaviour, IInteract
{
    [NonSerialized] [CanBeNull] public Alter alter;
    [field: SerializeField] public int ValueID { get; protected set; }
    public virtual void TriggerPillarPlacement(int itemIndex, Alter[] pillars)
    {
        
    }

    public virtual void Drop()
    {
        PlayerInteract.Instance.HeldRune = null;
    }

    public virtual void PickUp()
    {
        PlayerInteract.Instance.HeldRune = this;
    }

    public virtual void OnInteract()
    {
        if (alter != null)
            return;
        
        if (PlayerInteract.Instance.HeldRune)
            PlayerInteract.Instance.HeldRune.Drop();
        
        PickUp();
    }
}
