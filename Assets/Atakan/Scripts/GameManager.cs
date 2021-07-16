
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum GameState
    {
        Start,
        InGame,
        Finish
    }
    public GameState gameState;

    private void Start()
    {
        gameState = GameState.Start;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            gameState = GameState.InGame;
    }
}
