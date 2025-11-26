using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

public class Alter : MonoBehaviour, IInteract
{
    private AlterCluster alterCluster;
    private int clusterIndex;
    [SerializeField] Vector3 kickOffset;
    [CanBeNull] public Rune equippedRune;

    public void ConnectToCluster(AlterCluster cluster,int clusterIndex)
    {
        alterCluster = cluster;
        this.clusterIndex = clusterIndex;
    }
    public void KickItem()
    {
        if (equippedRune == null)
            return;
        equippedRune.transform.position = transform.position + kickOffset;
        equippedRune.alter = null;
        equippedRune = null;
    }

    public void PlaceItem(Rune rune)
    {
        KickItem();
        this.equippedRune = rune;
        rune.alter = this;
        rune.transform.position = transform.position;
        alterCluster.TriggerItemPlacement(clusterIndex);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInteract()
    {
        if (PlayerInteract.Instance.HeldRune && equippedRune)
        {
            Rune heldRune = PlayerInteract.Instance.HeldRune;
            PlayerInteract.Instance.HeldRune.Drop();
            equippedRune.PickUp();
            KickItem();
            PlaceItem(heldRune);
            return;
        }

        if (equippedRune)
        {
            equippedRune.PickUp();
            KickItem();
            return;
        }

        if (PlayerInteract.Instance.HeldRune)
        {
            PlaceItem(PlayerInteract.Instance.HeldRune);
            PlayerInteract.Instance.HeldRune.Drop();
            return;
        }
    }
}
