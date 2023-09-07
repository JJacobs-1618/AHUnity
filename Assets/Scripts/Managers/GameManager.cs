using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Camera mainCamera;

    private PhaseManager pm;
    private GameBoard gb;

    public List<GameObject> chosenInvestigators;

    private List<GameObject> investigators;
    private List<Investigator> investigatorRefs;

    // For Phases
    private int firstPlayerIndex;
    private int currentPlayerIndex;

    private int round;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        investigators = new();
        investigatorRefs = new();
        round = 0;
    }
    private void OnEnable()
    {
        PhaseManager.OnGamePhaseChanged += Pm_OnGamePhaseChanged;
    }

    private void OnDisable()
    {
        PhaseManager.OnGamePhaseChanged -= Pm_OnGamePhaseChanged;
    }

    private void Start()
    {
        pm = PhaseManager.instance;
        gb = GameBoard.instance;

        pm.UpdateGamePhase(GamePhase.GameSetup); // Starts Game Flow
    }

    private void Pm_OnGamePhaseChanged(GamePhase obj)
    {
        switch (obj)
        {
            case GamePhase.GameSetup:
                HandleGameSetup();
                break;
            case GamePhase.InvestigatorSetup:
                HandleInvestigatorSetup();
                break;
            case GamePhase.InitialMythos:
                HandleInitialMythos();
                break;
            case GamePhase.Upkeep:
                StartCoroutine(HandleUpkeep());
                break;
            case GamePhase.Movement:
                StartCoroutine(HandleMovement());
                break;
            case GamePhase.Combat:
                //HandleCombat();
                break;
            case GamePhase.ArkhamEncounter:
                StartCoroutine(HandleArkhamEncounter());
                break;
            case GamePhase.OtherWorldEncounter:
                StartCoroutine(HandleOtherWorldEncounter());
                break;
            case GamePhase.Mythos:
                StartCoroutine(HandleMythos());
                break;
            case GamePhase.NextRound:
                StartCoroutine(HandleNextRound());
                break;
            case GamePhase.Any:
                break;
            case GamePhase.Paused:
                break;
        }
    }


    private void HandleGameSetup()
    {
        gb.SetupBoard();
        // Tell Phase Manager setup is over and to move to Investigator Setup
        PhaseManager.instance.UpdateGamePhase(GamePhase.InvestigatorSetup);
    }

    private void HandleInvestigatorSetup()
    {
        Debug.Log("Investigator Setup Starting.");
        //TODO REMOVE THIS. It should be set up by something else        
        investigators.Add(Instantiate(chosenInvestigators[0], null));
        investigatorRefs.Add(investigators[0].GetComponent<Investigator>());
        // Select First Player
        firstPlayerIndex = currentPlayerIndex = UnityEngine.Random.Range(0, investigators.Count);
        // Set player rotation
        // Setup First Player

        // Setup remaining players, if any
        PlaceInvestigators();
        Debug.Log("Investigator Setup Ending.");
        // Tell PhaseManager to go to First Mythos Phase
        pm.UpdateGamePhase(GamePhase.InitialMythos);
    }

    private void PlaceInvestigators()
    {
        foreach (Investigator i in investigatorRefs)
        {
            i.CurrentTile = gb.GetLocation(i.data.home);
            i.transform.position = i.CurrentTile.transform.position + i.data.placementOffset;
        }
    }
    private void HandleInitialMythos()
    {
        StartCoroutine(WaitForInvestigatorInitThenGoToUpkeep());        
    }

    private IEnumerator WaitForInvestigatorInitThenGoToUpkeep()
    {
        yield return new WaitForSeconds(1.5f);
        ResetInvestigatorPhaseSwitches();
        Debug.Log($"Round {round}: Initial Mythos Phase Starting");
        // Draw and Resolve Initial Mythos per rules
        Debug.Log($"Round {round}: Initial Mythos Phase Ending. Going to Upkeep...");
        round++;
        pm.UpdateGamePhase(GamePhase.Upkeep);
    }

    private IEnumerator HandleUpkeep()
    {
        Debug.Log($"Round {round}: Upkeep Phase Begins");
        yield return new WaitForSeconds(1.5f);
        // Get currentPlayer and perform upkeep
        // if(investigatorRefs.investigatorData.hasPerformedUpkeep) pm.UpdateGamePhase(GamePhase.Movement);
        //investigatorRefs[currentPlayerIndex].PerformUpkeep();
        // Investigator handles change in phase
        Debug.Log($"Round {round}: Upkeep Phase Ending. Going to Movement...");
        pm.UpdateGamePhase(GamePhase.Movement);
    }

    public IEnumerator HandleMovement()
    {
        Debug.Log($"Round {round}: Movement Phase Begins");
        yield return new WaitForSeconds(1.5f);
        Investigator current = investigatorRefs[currentPlayerIndex];
        if (current.data.hasPerformedMovement) // If the current player has moved, this should logically be the first player again. 
        {
            Debug.Log($"Round {round}: Movement Phase Ending. Beginning Arkham Encounter Phase...");
            currentPlayerIndex = firstPlayerIndex;
            pm.UpdateGamePhase(GamePhase.ArkhamEncounter);
            yield break;
        }
        current.PerformMovement();
    }

    private IEnumerator HandleArkhamEncounter()
    {
        Debug.Log($"Round {round}: Arkham Encounter Phase Begins");
        yield return new WaitForSeconds(1.5f);
        Debug.Log($"Round {round}: Arkham Encounter Phase Ending. Beginning Other World Encounter Phase...");
        pm.UpdateGamePhase(GamePhase.OtherWorldEncounter);
    }

    private IEnumerator HandleOtherWorldEncounter()
    {
        Debug.Log($"Round {round}: Other World Encounter Phase Begins");
        yield return new WaitForSeconds(1.5f);
        Debug.Log($"Round {round}: Other World Encounter Phase Ending. Beginning Mythos Phase...");
        pm.UpdateGamePhase(GamePhase.Mythos);
    }

    private IEnumerator HandleMythos()
    {
        Debug.Log($"Round {round}: Mythos Phase Begins");
        // Draw and reveal card
        Card card = gb.mythos.DrawCard();        
        MythosCardSO mythos = (MythosCardSO)card.data;
        while (mythos.cardName == "The Story Continues...")
        {
            gb.mythos.TheStoryContinues();
            card = gb.mythos.DrawCard();
            mythos = (MythosCardSO)card.data;
        }
        yield return new WaitForSeconds(1.5f);
        OpenGateAndSpawnMonster(mythos);
        yield return new WaitForSeconds(1.5f);
        PlaceClueToken(mythos.clueAppears);
        yield return new WaitForSeconds(1.5f);
        MoveMonsters(mythos.whiteMovers, mythos.blackMovers);
        // yield return new WaitForSeconds(1.5f);
        // ActivateMythosAbility(MythosAbility mythos.data.Ability);
        // First Player draws and resolves a mythos card
        firstPlayerIndex = (firstPlayerIndex + 1) % investigators.Count;
        Debug.Log($"Investigator {firstPlayerIndex}: {investigatorRefs[firstPlayerIndex].data.investigatorName} is now first player.");
        Debug.Log($"Round {round}: Mythos Phase Ending. Beginning round {round+1}");
        pm.UpdateGamePhase(GamePhase.NextRound);
    }

    private void PlaceClueToken(LocationTileSO clueAppears)
    {
        clueAppears.clueTokens++;
    }

    private void OpenGateAndSpawnMonster(MythosCardSO mythos)
    {
        if (gb.SpawnGate(mythos))
        {
            gb.SpawnMonster(gb.GetLocation(mythos.GateAppears.gameTileName));
        }
    }

    private void MoveMonsters(List<DimensionSymbolType> white, List<DimensionSymbolType> black)
    {
        foreach (Monster m in gb.monstersInPlay)
        {
            if (white.Contains(m.data.Symbol))
            {
                m.MoveWhite();
            } else if (black.Contains(m.data.Symbol))
            {
                m.MoveBlack();
            }
        }
    }

    private IEnumerator HandleNextRound()
    {
        yield return new WaitForSeconds(1.5f);
        round++;
        ResetInvestigatorPhaseSwitches();
        
        pm.UpdateGamePhase(GamePhase.Upkeep);
    }

    private void ResetInvestigatorPhaseSwitches()
    {
        foreach (Investigator i in investigatorRefs)
        {
            i.data.hasPerformedUpkeep = false;
            i.data.hasPerformedMovement = false;
            i.data.hasPerformedArkhamEncounter = false;
            i.data.hasPerformedOtherWorldEncounter = false;
        }
    }

    public void AddInvestigator(GameObject investigator)
    {
        investigators.Add(investigator);
        investigatorRefs.Add(investigator.GetComponent<Investigator>());
    }
    public void RemoveInvestigator(GameObject investigator)
    {
        investigators.Remove(investigator);
        investigatorRefs.Remove(investigator.GetComponent<Investigator>());
        Destroy(investigator);
    }
}
    /*
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


    private void Pm_OnGamePhaseChanged(GamePhase phase)
    {
        if (pm.GetLastGamePhase() != pm.GetCurrentGamePhase())
        {
            currentPlayer = firstPlayer; 

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
        //gameboard.InitGameBoard();
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
            //investigators[currentPlayer].controller.Move(); 
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
                //go.transform.position = GameBoard.instance.GetLocation(i.GetHome()).transform.position;
                //i.SetCurrentLocation(GameBoard.instance.GetLocation(i.GetHome()).GetComponent<GameTile>());
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
    */