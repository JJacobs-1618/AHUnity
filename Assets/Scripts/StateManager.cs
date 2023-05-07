using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static StateManager instance;
    private GameState currentState;
    private GameState lastState; /* Possible catch to avoid skipping stages? I dunno */

    public static event Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void UpdateGameState(GameState update)
    {
        lastState = currentState;
        currentState = update;
        OnGameStateChanged?.Invoke(currentState);
    }

    public GameState getCurrentGameState()
    {
        return currentState;
    }
}

public enum GameState
{
    GameSetup,
    Upkeep,
    Movement,
    ArkhamEncounter,
    OtherWorldEncounter,
    Mythos,
    Paused
}