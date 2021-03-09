using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private CharacterController controller;

    private float moveSpeed = 8f;
    private float gravity = -9.81f;
    private float jumpHeight = 5f;

    public Transform groundCheck;
    private float groundDistance = 0.2f;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xAxis + transform.forward * zAxis;

        controller.Move(move * moveSpeed * Time.deltaTime);


    }
}
