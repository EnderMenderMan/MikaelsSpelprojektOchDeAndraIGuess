using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private InputSystem_Actions inputActions;
    public static PlayerMovement Instance;
    [SerializeField] private float speed;
    private Vector2 dir;

    [CanBeNull] private Rigidbody2D rb;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        Instance = this;
    }

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
        inputActions.Player.Move.performed += context =>
        {
            dir = context.ReadValue<Vector2>();
        };
        inputActions.Player.Move.canceled += context =>
        {
            dir = Vector2.zero;
        };
        inputActions.Player.Move.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.Move.Disable();
    }
}
