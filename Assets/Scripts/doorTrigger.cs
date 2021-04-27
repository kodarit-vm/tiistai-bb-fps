using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTrigger : MonoBehaviour
{
    public enum TriggerState { Opens, Closes };

    public TriggerState state = TriggerState.Opens;
    public doorController door;

    private void OnTriggerEnter(Collider other)
    {
        if (state == TriggerState.Opens)
        {
            door.OpenDoor();
        }

        if (state == TriggerState.Closes)
        {
            door.CloseDoor();
        }
    }
}
