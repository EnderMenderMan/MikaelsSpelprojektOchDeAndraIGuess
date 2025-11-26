using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 dir;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = dir * speed;
    }

    private void OnEnable()
    {
        PlayerInteract.InputActions.Player.Move.performed += context =>
        {
            dir = context.ReadValue<Vector2>();
        };
        PlayerInteract.InputActions.Player.Move.canceled += context =>
        {
            dir = Vector2.zero;
        };
        PlayerInteract.InputActions.Player.Move.Enable();
    }

    private void OnDisable()
    {
        PlayerInteract.InputActions.Player.Move.Disable();
    }
}
