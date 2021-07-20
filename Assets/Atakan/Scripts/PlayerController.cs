using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        if (GameManager.Instance.gameState == GameManager.GameState.InGame)
        {
            transform.position += transform.forward * (Time.deltaTime * speed);
        }
    }

}
