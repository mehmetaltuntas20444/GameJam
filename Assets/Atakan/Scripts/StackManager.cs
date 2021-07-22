using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    public static StackManager instance;

    [SerializeField] private float distanceBetwwenObjects;
    [SerializeField] private float forwardDistance;
    [SerializeField] private Transform prevObject;
    [SerializeField] private Transform parent;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        distanceBetwwenObjects = prevObject.localScale.x;
        forwardDistance = prevObject.localScale.z;
    }

    public void PickUp(GameObject pickedObject, bool needTag = false, string tag=null, bool leftOrRight = true)
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
        }
        else if(parent.childCount >= 7 && parent.childCount < 12)
        {
            if (parent.childCount == 7)
            {
                desPos.x += distanceBetwwenObjects;
                desPos.x = 0;
            }
            desPos.x += -distanceBetwwenObjects;
        }
        else if(parent.childCount >= 12)
        {
            if(parent.childCount == 12)
            {
                desPos.z += forwardDistance;
                desPos.x = 0;
                desPos.x += distanceBetwwenObjects;
            }
            else if(parent.childCount < 15)
            {
                desPos.x += distanceBetwwenObjects;
            }
            else if (parent.childCount >= 15)
            {
                if (parent.childCount == 15)
                {
                    desPos.x += distanceBetwwenObjects;
                    desPos.x = 0;
                }
                desPos.x += -distanceBetwwenObjects;
            }
        }


        //desPos.x += leftOrRight ? distanceBetwwenObjects : -distanceBetwwenObjects;
        pickedObject.GetComponent<Pencils>().enabled = true;
        pickedObject.transform.localPosition = desPos;
        prevObject = pickedObject.transform;
    }
    void Update()
    {
        
    }
}
