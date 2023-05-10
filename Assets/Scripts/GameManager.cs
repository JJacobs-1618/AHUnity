using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] PhaseManager pm;
    [SerializeField] GameBoard gameboard;

    [SerializeField] List<GameObject> investigatorsGO;
    [SerializeField] List<Investigator> investigators;
    [SerializeField] int firstPlayer;
    [SerializeField] int currentPlayer;
    [SerializeField] List<GameObject> monstersOnBoard;
    [SerializeField] List<GameObject> monstersInOutskirts;

    [SerializeField] GameObject ancientOne;

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

    private void OnEnable()
    {
        PhaseManager.OnGamePhaseChanged += Pm_OnGamePhaseChanged;
    }

    private void OnDisable()
    {
        PhaseManager.OnGamePhaseChanged += Pm_OnGamePhaseChanged;
    }

    private void OnDestroy()
    {
        PhaseManager.OnGamePhaseChanged += Pm_OnGamePhaseChanged;
    }



    private void Pm_OnGamePhaseChanged(GamePhase phase)
    {
        if (pm.GetLastGamePhase() != pm.GetCurrentGamePhase())
        {
            currentPlayer = firstPlayer; /* Reset current player */

        }
        switch (phase)
        {
            case GamePhase.GameSetup:
                GameSetup();
                break;
            case GamePhase.Upkeep:
                Upkeep();
                break;
            case GamePhase.Movement:
                Movement();
                break;
            case GamePhase.ArkhamEncounter:
                ArkhamEncounter();
                break;
            case GamePhase.OtherWorldEncounter:
                OtherWorldEncounter();
                break;
            case GamePhase.Mythos:
                Mythos();
                break;
            case GamePhase.Paused:
                break;
        }
    }

    private void GameSetup()
    {
        // Prepare gameboard (places clue tokens)
        gameboard.InitGameBoard();
        // choose first player
        firstPlayer = UnityEngine.Random.Range(0, investigators.Count);
        // Reveal ancient one
        // shuffle decks
        // give possessions
        // give random items
        // investigator setup

        // monster cup (w/ or w/o masks)
        // place investigators
        PlaceInvestigators();
        // draw/resolve mythos
        DrawAndResolveMythos();
    }

    private void Upkeep()
    {
        throw new NotImplementedException();
    }

    private void Movement()
    {
        if (!investigators[currentPlayer].controller.hasMoved)
        {
            investigators[currentPlayer].controller.Move(); /* Takes control in controller, yielding control after movement. */
            currentPlayer = (currentPlayer + 1) % investigatorsGO.Count;
        } else
        {
            pm.UpdateGamePhase(GamePhase.ArkhamEncounter);
        }
    }

    private void ArkhamEncounter()
    {
        throw new NotImplementedException();
    }

    private void OtherWorldEncounter()
    {
        throw new NotImplementedException();
    }

    private void Mythos()
    {
        throw new NotImplementedException();
    }

    private void DrawAndResolveMythos()
    {
        throw new NotImplementedException();
    }

    private void PlaceInvestigators()
    {
        if (investigatorsGO.Count != 0)
        {
            foreach (GameObject go in investigatorsGO)
            {
                Investigator i = go.GetComponent<Investigator>();
                investigators.Add(i);
                go.transform.position = GameBoard.instance.GetLocation(i.GetHome());
            }
        }
    }

    //*TESTING* REMOVE
    public void GameSetupButton()
    {
        pm.UpdateGamePhase(GamePhase.GameSetup);
    }
    //*TESTING* REMOVE
    public void MovementButton()
    {
        currentPlayer = firstPlayer;
        pm.UpdateGamePhase(GamePhase.Movement);
    }
}