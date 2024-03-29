using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float paddingLeft = 0.5f, paddingRight = 0.5f, paddingTop = 3f, paddingBottom = 2f;

    Vector2 rawInput;
    Vector2 minBounds, maxBounds; // for restricting player to move only inside the camera viewport

    Shooter shooter;

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    private void Start()
    {
        InitBounds();
    }

    void Update()
    {
        MovePlayer();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0)); // left bottom of screen
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if(shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }

    void MovePlayer()
    {
        Vector2 deltaPosition = rawInput * moveSpeed * Time.deltaTime; // time delta time is frame independent

        Vector2 newPosition = new Vector2();
        newPosition.x = Mathf.Clamp(transform.position.x + deltaPosition.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPosition.y = Mathf.Clamp(transform.position.y + deltaPosition.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);

        transform.position = newPosition;
    }
}
