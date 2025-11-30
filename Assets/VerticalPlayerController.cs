using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlayerController : MonoBehaviour
{
    [Header("Швидкість руху по Y")]
    public float moveSpeed = 5f;

    [Header("Обмеження руху по Y (опціонально)")]
    public bool useBounds = false;
    public float minY = -5f;
    public float maxY = 5f;

    void Update()
    {
        // Читаємо натискання: W/S, ↑/↓
        float vertical = 0f;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            vertical = 1f;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            vertical = -1f;
        }

        // Рухаємо об’єкт лише по Y
        Vector3 move = new Vector3(0f, vertical, 0f) * moveSpeed * Time.deltaTime;
        transform.position += move;

        // Якщо хочеш обмежити рух по висоті
        if (useBounds)
        {
            Vector3 pos = transform.position;
            pos.y = Mathf.Clamp(pos.y, minY, maxY);
            transform.position = pos;
        }
    }
}