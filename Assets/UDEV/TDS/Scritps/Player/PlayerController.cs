using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private Transform graphic;
    [SerializeField] private Transform weaponHolder;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleInput();
        RotateToMouse();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void HandleInput()
    {
        moveInput = Vector2.zero;

        if (Keyboard.current.wKey.isPressed)
            moveInput.y += 1;

        if (Keyboard.current.sKey.isPressed)
            moveInput.y -= 1;

        if (Keyboard.current.aKey.isPressed)
            moveInput.x -= 1;

        if (Keyboard.current.dKey.isPressed)
            moveInput.x += 1;
    }

    private void Move()
    {
        rb.linearVelocity =
            moveInput.normalized * moveSpeed;
    }

    private void RotateToMouse()
    {
        Vector3 mousePos =
            Camera.main.ScreenToWorldPoint(
                Mouse.current.position.ReadValue());

        mousePos.z = 0;

        Vector2 direction =
            mousePos - weaponHolder.position;

        float angle =
            Mathf.Atan2(direction.y, direction.x)
            * Mathf.Rad2Deg;

        weaponHolder.rotation =
            Quaternion.Euler(0, 0, angle);

        if (direction.x < 0)
        {
            graphic.localScale =
                new Vector3(-1, 1, 1);
        }
        else
        {
            graphic.localScale =
                new Vector3(1, 1, 1);
        }
    }
}