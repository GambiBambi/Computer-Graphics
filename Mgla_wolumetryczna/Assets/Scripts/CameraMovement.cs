using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed = 10;
    public float edgeMoveThreshold = 10;
    public float edgeMoveSpeed = 20;
    public float moveSpeed = 20;

    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X");
        float rotationY = mouseX * rotationSpeed * Time.deltaTime * 10;
        float currentRotationY = transform.eulerAngles.y + rotationY;
        transform.rotation = Quaternion.Euler(0, currentRotationY, 0);

        Vector3 mousePosition = Input.mousePosition;
        Vector3 rotation = new Vector3(0, 0, 0);
        if (mousePosition.x < edgeMoveThreshold)
            rotation = new Vector3(0, -edgeMoveSpeed * Time.deltaTime, 0);
        if (mousePosition.x > Screen.width - edgeMoveThreshold)
            rotation = new Vector3(0, edgeMoveSpeed * Time.deltaTime, 0);
        transform.Rotate(rotation);

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        movement.Normalize();
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}