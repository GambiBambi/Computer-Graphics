using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firefly : MonoBehaviour
{
    public Transform centerPoint;
    public Transform centerObject;
    public float speed = 1f;
    public float rotationSpeed = 1f;
    private float angle = 0f; 

    private void Update()
    {
        float radius = Vector3.Distance(centerPoint.position, centerObject.position);
        float x = centerPoint.position.x + radius * Mathf.Cos(angle);
        float z = centerPoint.position.z + radius * Mathf.Sin(angle);
        transform.position = new Vector3(x, transform.position.y, z);
        Vector3 directionToCenter = centerPoint.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(directionToCenter, Vector3.up);
        targetRotation *= Quaternion.Euler(0f, 90f, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        angle += speed * Time.deltaTime;
        if (angle >= 360f)
            angle = 0f;
    }
}
