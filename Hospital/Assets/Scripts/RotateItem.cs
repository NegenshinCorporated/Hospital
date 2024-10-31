using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour
{
    public float rotationSpeed = 50f; // �������� ��������
    public float floatHeight = 0.5f; // ������, �� ������� ������ ����� ����������� � ����������
    public float floatSpeed = 1f; // �������� ������� � ������

    private Vector3 startPosition;

    void Start()
    {
        // ��������� ��������� ������� �������
        startPosition = transform.position;
    }

    void Update()
    {
        // �������� ������ ��� Y
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);

        // ��������� ����� ������������ ���������
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // ��������� ������� �������
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
