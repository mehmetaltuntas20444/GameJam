using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pick")
        {
            StackManager.Instance.PickUp(collision.gameObject, true, "Untagged");
        }
    }
}
