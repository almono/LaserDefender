using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;

    Vector2 rawInput;

    void Update()
    {
        MovePlayer();
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();

    }

    void MovePlayer()
    {
        Vector3 deltaPosition = rawInput * moveSpeed * Time.deltaTime; // time delta time is frame independent
        transform.position += deltaPosition;
    }
}
