using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour
{
    public float rotationSpeed = 50f; // Скорость вращения
    public float floatHeight = 0.5f; // Высота, на которую объект будет подниматься и опускаться
    public float floatSpeed = 1f; // Скорость подъема и спуска

    private Vector3 startPosition;

    void Start()
    {
        // Сохраняем начальную позицию объекта
        startPosition = transform.position;
    }

    void Update()
    {
        // Вращение вокруг оси Y
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);

        // Вычисляем новое вертикальное положение
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // Обновляем позицию объекта
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
