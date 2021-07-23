using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : Singleton<StackManager>
{
    [SerializeField] private float distanceBetwwenObjects;
    [SerializeField] private float forwardDistance;
    [SerializeField] public Transform prevObject;
    [SerializeField] public Transform parent;
    [SerializeField] public GameObject prevR;
    [SerializeField] public GameObject prevL;
    void Start()
    {
        distanceBetwwenObjects = 0.5f;
        forwardDistance = 0.7f;
    }

 

    public void PickUp(GameObject pickedObject, bool needTag = false, string tag=null)
    {
        if (needTag)
        {
            pickedObject.tag = tag;
        }
        pickedObject.transform.parent = parent;
        Vector3 desPos = prevObject.localPosition;
        if(parent.childCount < 7)
        {
            desPos.x += distanceBetwwenObjects;
            prevR = pickedObject;
        }
        else if(parent.childCount >= 7 && parent.childCount < 12)
        {
            if (parent.childCount == 7)
            {
                desPos.x += distanceBetwwenObjects;
                desPos.x = 0;
            }
            desPos.x += -distanceBetwwenObjects;
            prevL = pickedObject;
        }
        else if(parent.childCount >= 12)
        {
            if(parent.childCount == 12)
            {
                desPos.z += forwardDistance;
                desPos.x = 0;
                desPos.x += distanceBetwwenObjects;
                prevR = pickedObject;
            }
            else if(parent.childCount < 15)
            {
                desPos.x += distanceBetwwenObjects;
                prevR = pickedObject;
            }
            else if (parent.childCount >= 15)
            {
                if (parent.childCount == 15)
                {
                    desPos.x += distanceBetwwenObjects;
                    desPos.x = 0;
                }
                desPos.x += -distanceBetwwenObjects;
                prevL = pickedObject;

            }
        }
        pickedObject.GetComponent<Pencils>().enabled = true;
        pickedObject.transform.localPosition = desPos;
        prevObject = pickedObject.transform;
    }

}
