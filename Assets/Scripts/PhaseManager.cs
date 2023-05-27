using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    public static PhaseManager instance;
    private GamePhase currentPhase;
    private GamePhase lastPhase; /* Possible catch to avoid skipping phases? I dunno */

    public static event Action<GamePhase> OnGamePhaseChanged;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        lastPhase = GamePhase.GameSetup;
        currentPhase = GamePhase.GameSetup;
    }

    public void UpdateGamePhase(GamePhase update)
    {
        lastPhase = currentPhase;
        currentPhase = update;
        OnGamePhaseChanged?.Invoke(currentPhase);
    }

    public GamePhase GetCurrentGamePhase() { return currentPhase; }
    public GamePhase GetLastGamePhase() { return lastPhase; }
}

public enum GamePhase
{
    GameSetup,
    InvestigatorSetup,
    Upkeep,
    Movement,
    Combat,
    ArkhamEncounter,
    OtherWorldEncounter,
    Mythos,
    Any,
    Paused
}