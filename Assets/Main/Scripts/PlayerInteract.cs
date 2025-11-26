using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerInteract : MonoBehaviour
{
    public static PlayerInteract Instance;
    public static InputSystem_Actions InputActions;
    [NonSerialized] [CanBeNull] public Rune HeldRune;
    [SerializeField] Collider2D interactColliderDetection;

    private void Awake()
    {
        Instance = this;
        InputActions = new InputSystem_Actions();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HeldRune)
            HeldRune.transform.position = transform.position;
    }

    private void OnEnable()
    {
        PlayerInteract.InputActions.Player.Attack.performed += context =>
        {
            bool interacted = false;
            List<Collider2D> collisions = new List<Collider2D>();
            interactColliderDetection.Overlap(collisions);
            foreach (var collision in collisions)
            {
                if (HeldRune != null && HeldRune.gameObject == collision.gameObject)
                    continue;
                if (!collision.CompareTag("Interactable"))
                    continue;
                interacted = true;
                collision.GetComponent<IInteract>().OnInteract();
                break;
            }

            if (interacted == false && HeldRune != null)
            {
                HeldRune.Drop();
            }
        };
        PlayerInteract.InputActions.Player.Attack.Enable();
    }

    private void OnDisable()
    {
        PlayerInteract.InputActions.Player.Attack.Disable();
    }
}
