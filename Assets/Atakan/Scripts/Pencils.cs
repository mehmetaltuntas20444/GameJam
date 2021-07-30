using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pencils : MonoBehaviour
{
    public int listIndex; 
    float scalepow = 5f;
    public bool moving;
    public Vector3 destiny;
    public float movingTime;


    private void Update()
    {

        if (GameManager.Instance.gameState == GameManager.GameState.InGame)
        {
            var scale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z-Time.deltaTime*scalepow);
            ScaleAround(-transform.up,scale);
            if(transform.localScale.z <= 0 || transform.position.y < 0)
            {
                kill();
            }
        }

        if(moving)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, destiny, Time.deltaTime* movingTime );
        }
    }
    private void kill()
    {
        StackManager.Instance.popUp(listIndex);
        Destroy(gameObject);
        StackManager.Instance.sortPencils(4f);

    }

    public void ScaleAround(Vector3 pivot, Vector3 newScale)
    {
        Vector3 A = transform.localPosition;
        Vector3 B = pivot;
 
        Vector3 C = A - B; // diff from object pivot to desired pivot/origin
 
        float RS = newScale.x / transform.localScale.x; // relataive scale factor
 
        // calc final position post-scale
        Vector3 FP = B + C * RS;
 
        // finally, actually perform the scale/translation
        transform.localScale = newScale;
        transform.localPosition = FP;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube" && GetComponent<StackTrigger>().inPlayer)
        {
            kill();
        }
        if(collision.gameObject.tag == "FinishLevel")
        {
            GameManager.Instance.gameState = GameManager.GameState.Finish;
        }
    }


}
