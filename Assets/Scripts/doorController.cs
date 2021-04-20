using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    enum DoorState { Open, Close };
    DoorState state = DoorState.Close;

    public Transform EndPoint;
    public float moveSpeed = 1f;

    private Vector3 startPoint;
    private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            switch (state)
            {
                case DoorState.Close:
                    if (transform.position.y != startPoint.y)
                    {
                        transform.position = Vector3.Lerp(transform.position, startPoint, moveSpeed * Time.deltaTime);
                    }
                    else
                    {
                        isMoving = false;
                        state = DoorState.Close;
                    }
                    break;

                case DoorState.Open:
                    if (transform.position.y != EndPoint.position.y)
                    {
                        transform.position = Vector3.Lerp(transform.position, EndPoint.position, moveSpeed *  Time.deltaTime);
                    }
                    else
                    {
                        isMoving = false;
                        state = DoorState.Open;
                    }
                    break;
            }
        }
    }

    public void OpenDoor()
    {
        state = DoorState.Open;
        isMoving = true;
    }
    public void CloseDoor()
    {
        state = DoorState.Close;
        isMoving = true;
    }
}
