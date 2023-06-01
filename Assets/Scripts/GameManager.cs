using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("GameInformation")]
    [SerializeField] static GameRule gameRules;
    [SerializeField] PhaseManager pm;
    [SerializeField] GameBoard gameboard;
    [Header("AncientOne")]
    [SerializeField] GameObject ancientOne;
    [Header("PlayerInformation")]
    [SerializeField] List<GameObject> investigatorsGO;
    [SerializeField] List<Investigator> investigators;
    [SerializeField] int firstPlayer;
    [SerializeField] int currentPlayer;
    [Header("MonsterInformation")]
    [SerializeField] List<GameObject> monstersOnBoard;
    [SerializeField] List<GameObject> monstersInOutskirts;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        GenerateGameRules(investigatorsGO.Count);
    }

    private void OnEnable()
    {
        PhaseManager.OnGamePhaseChanged += Pm_OnGamePhaseChanged;
    }

    private void OnDisable()
    {
        PhaseManager.OnGamePhaseChanged -= Pm_OnGamePhaseChanged;
    }

    private void OnDestroy()
    {
        PhaseManager.OnGamePhaseChanged -= Pm_OnGamePhaseChanged;
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
            case GamePhase.InvestigatorSetup:
                InvestigatorSetup();
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
        // monster cup (w/ or w/o masks)
        // place investigators
        PlaceInvestigators(); 
        pm.UpdateGamePhase(GamePhase.InvestigatorSetup);
    }

    private void InvestigatorSetup()
    {
        Investigator curr = investigators[currentPlayer];
        if (!curr.performedSetup)
        {
            // give possessions
            // give random items
            curr.PlayerTurn();
            currentPlayer = (currentPlayer + 1) % investigatorsGO.Count;
        }
        else
        {
            // draw/resolve mythos
            DrawAndResolveMythos();
        }
    }

    private void Upkeep()
    {
        Investigator curr = investigators[currentPlayer];
        if (!curr.performedUpkeep)
        {
            curr.PlayerTurn();
            currentPlayer = (currentPlayer + 1) % investigatorsGO.Count;
        } else
        {
            pm.UpdateGamePhase(GamePhase.Movement);
        }
    }

    private void Movement()
    {
        if (!investigators[currentPlayer]._investigatorController.hasMoved)
        {
            //investigators[currentPlayer].ShowUI();
            //investigators[currentPlayer].controller.Move(); /* Takes control in controller, yielding control after movement. */
            investigators[currentPlayer].PlayerTurn();
            currentPlayer = (currentPlayer + 1) % investigatorsGO.Count;
        } else
        {
            pm.UpdateGamePhase(GamePhase.ArkhamEncounter);
        }
    }

    private void ArkhamEncounter()
    {
        Investigator curr = investigators[currentPlayer];
        if (!curr.performedArkhamEnc)
        {
            curr.PlayerTurn();
            currentPlayer = (currentPlayer + 1) % investigatorsGO.Count;
        }
        else
        {
            pm.UpdateGamePhase(GamePhase.OtherWorldEncounter);
        }        
    }

    private void OtherWorldEncounter()
    {
        Debug.LogError("Unimplemented TODO");
        pm.UpdateGamePhase(GamePhase.Mythos);
    }

    private void Mythos()
    {
        Debug.LogError("Unimplemented TODO");
        LoopRefresh();
        pm.UpdateGamePhase(GamePhase.Upkeep);
    }

    private void LoopRefresh()
    {
        foreach(Investigator i in investigators)
        {
            i.performedUpkeep = false;
            i.performedMovement = false;
            i._investigatorController.hasMoved = false;
            i.performedArkhamEnc = false;
            i.performedOtherWorldEnc = false;            
        }
    }

    private void DrawAndResolveMythos()
    {
        Debug.LogError("Unimplemented TODO");
        pm.UpdateGamePhase(GamePhase.Upkeep);
    }

    private void PlaceInvestigators()
    {
        if (investigatorsGO.Count != 0)
        {
            foreach (GameObject go in investigatorsGO)
            {
                Investigator i = go.GetComponent<Investigator>();
                investigators.Add(i);
                go.transform.position = GameBoard.instance.GetLocation(i.GetHome()).transform.position;
                i.SetCurrentLocation(GameBoard.instance.GetLocation(i.GetHome()).GetComponent<GameTile>());
            }
        }
    }

    //*TESTING* REMOVE
    public void GameSetupButton()
    {
        pm.UpdateGamePhase(GamePhase.GameSetup);
    }

    private static void GenerateGameRules(int numberOfPlayers)
    {
        switch (numberOfPlayers)
        {
            case 1:
                gameRules.numberOfPlayers = 1;
                gameRules.openGateLimit = 8;
                gameRules.monsterLimit = 4;
                gameRules.outskirtsLimit = 7;
                gameRules.monstersDrawn = 1;
                break;
            case 2:
                gameRules.numberOfPlayers = 2;
                gameRules.openGateLimit = 8;
                gameRules.monsterLimit = 5;
                gameRules.outskirtsLimit = 6;
                gameRules.monstersDrawn = 1;
                break;
            case 3:
                gameRules.numberOfPlayers = 3;
                gameRules.openGateLimit = 7;
                gameRules.monsterLimit = 6;
                gameRules.outskirtsLimit = 5;
                gameRules.monstersDrawn = 1;
                break;
            case 4:
                gameRules.numberOfPlayers = 4;
                gameRules.openGateLimit = 7;
                gameRules.monsterLimit = 7;
                gameRules.outskirtsLimit = 4;
                gameRules.monstersDrawn = 1;
                break;
            case 5:
                gameRules.numberOfPlayers = 5;
                gameRules.openGateLimit = 6;
                gameRules.monsterLimit = 8;
                gameRules.outskirtsLimit = 3;
                gameRules.monstersDrawn = 2;
                break;
            case 6:
                gameRules.numberOfPlayers = 6;
                gameRules.openGateLimit = 6;
                gameRules.monsterLimit = 9;
                gameRules.outskirtsLimit = 2;
                gameRules.monstersDrawn = 2;
                break;
            case 7:
                gameRules.numberOfPlayers = 7;
                gameRules.openGateLimit = 5;
                gameRules.monsterLimit = 10;
                gameRules.outskirtsLimit = 1;
                gameRules.monstersDrawn = 2;
                break;
            case 8:
                gameRules.numberOfPlayers = 8;
                gameRules.openGateLimit = 5;
                gameRules.monsterLimit = 11;
                gameRules.outskirtsLimit = 0;
                gameRules.monstersDrawn = 2;
                break;
        }
    }

}

struct GameRule
{
    public int numberOfPlayers;
    public int openGateLimit;
    public int monsterLimit;
    public int outskirtsLimit;
    public int monstersDrawn;
}