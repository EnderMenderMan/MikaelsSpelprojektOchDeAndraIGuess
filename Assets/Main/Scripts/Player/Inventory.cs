using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] Transform runePickupTransformUp;
    [SerializeField] Transform runePickupTransformDown;
    [SerializeField] Transform runePickupTransformLeft;
    Transform currenctPickupTransform;
    [SerializeField] Transform ogRuneTransform;

    public static Inventory PlayerInventory { get; private set; }
    [field: SerializeField] public Rune heldRune { get; private set; }


    public void PickupUp() => currenctPickupTransform = runePickupTransformUp;
    public void PickupDown() => currenctPickupTransform = runePickupTransformDown;
    public void PickupSide() => currenctPickupTransform = runePickupTransformLeft;


    public bool TryPickUpRune(Rune rune)
    {
        if (heldRune != null)
        {
            rune.SetCollidersActive(false);
            if (DropRuneAtPosition(rune.transform.position) == false)
            { rune.SetCollidersActive(true); return false; }
            rune.SetCollidersActive(true);
        }

        ShadowForcePickUp(rune);
        heldRune.OnPickUp();
        return true;
    }

    public bool CanPickupRune(Rune rune)
    {
        if (heldRune != null && CanDropRune() == false)
            return false;

        return true;
    }
    public bool CanDropRune()
    {
        if (heldRune == null)
            return false;
        return CanDropRune(heldRune.transform.position);
    }
    public bool CanDropRune(Vector3 position)
    {
        if (heldRune == null)
            return false;
        if (WorldData.Instance != null && WorldData.Instance.IsGridSpaceFree(position) == false)
            return false;

        return true;
    }

    public void ShadowForcePickUp(Rune rune)
    {
        if (rune == null)
            return;
        heldRune = rune;
        heldRune.IsInteractDisabled = true;
        Utility.CopyTransform(ogRuneTransform, rune.transform);
    }

    public bool DropRune()
    {
        if (heldRune == null)
            return false;
        return DropRuneAtPosition(heldRune.transform.position);

    }

    public bool DropRuneAtPosition(Vector2 position)
    {
        if (heldRune == null)
            return false;
        heldRune.OnDropped();
        heldRune.SetCollidersActive(false);
        if (WorldData.Instance != null && WorldData.Instance.IsGridSpaceFree(position) == false)
        { heldRune.SetCollidersActive(true); return false; }
        heldRune.SetCollidersActive(true);

        heldRune.transform.position = WorldData.Instance != null ? WorldData.Instance.WorldGrid.WorldToCell(position) + WorldData.Instance.WorldGrid.cellSize / 2 : position;
        heldRune.AfterDropped();
        ShadowForceDropRune(); // TODO: test change order
        return true;
    }

    public void ShadowForceDropRune()
    {
        if (heldRune == null)
            return;

        Utility.CopyTransform(heldRune.transform, ogRuneTransform);
        heldRune.IsInteractDisabled = false;
        heldRune = null;
    }

    void Awake()
    {
        currenctPickupTransform = runePickupTransformUp;

        if (GetComponent<PlayerInteract>() != null)
            PlayerInventory = this;
    }
    void Start()
    {
        PlayerInteract.Instance.OnNoInteract.AddListener(DropRuneSub);
    }


    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) // Debuging
        {
            ShadowForceDropRune();
        }
        if (heldRune)
        {

            Utility.CopyTransform(heldRune.transform, currenctPickupTransform);
            // heldRune.transform.position = runePickupTransformUp.position;
        }

    }

    void DropRuneSub() => DropRune();
}


