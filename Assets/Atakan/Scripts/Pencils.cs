using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pencils : MonoBehaviour
{
    public float scalepow;
    private float _health;
    [SerializeField] private float maxHealth;
    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            if(_health > maxHealth)
                _health = maxHealth;
            else if (_health < 0)
            {
                _health = 0;
            }
            else
                _health = value;
        }
    }

    private void Update()
    {
        if (GameManager.Instance.gameState == GameManager.GameState.InGame)
        {
            var scale = new Vector3(transform.localScale.x, transform.localScale.y-Time.deltaTime*scalepow, transform.localScale.z);
            ScaleAround(-transform.up,scale);
        }
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
    
    /* public void ScaleAround(GameObject target, Vector3 pivot, Vector3 newScale)
     {
     Vector3 A = target.transform.localPosition;
     Vector3 B = pivot;
 
     Vector3 C = A - B; // diff from object pivot to desired pivot/origin
 
     float RS = newScale.x / target.transform.localScale.x; // relataive scale factor
 
     // calc final position post-scale
     Vector3 FP = B + C * RS;
 
     // finally, actually perform the scale/translation
     target.transform.localScale = newScale;
     target.transform.localPosition = FP;
     }
     */
}
