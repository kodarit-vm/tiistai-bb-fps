using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    public float mouseSensitivity = 200f;
    private float mouseX;
    private float mouseY;
    private float xRotation = 0f;
    private GameObject player;

    [Header("Ylös- ja alas- suuntainen liikkuminen")]
    public float minYAngle = -70f;
    public float maxYAngle = 90f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        player.transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minYAngle, maxYAngle);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
