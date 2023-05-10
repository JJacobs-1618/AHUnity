using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public GameManager gm;
    [SerializeField] TextMeshProUGUI phaseText;


    private void OnEnable()
    {
        PhaseManager.OnGamePhaseChanged += PhaseManager_OnGamePhaseChanged;
    }

    private void PhaseManager_OnGamePhaseChanged(GamePhase obj)
    {
        phaseText.text = obj.ToString();
    }

    public void Init()
    {
        gm.GameSetupButton();
    }
    public void Slider()
    {
        throw new System.NotImplementedException();
    }
    public void Upkeep()
    {
        gm.UpkeepButton();
    }
    public void Movement()
    {
        gm.MovementButton();
    }
    public void Ark()
    {
        gm.ArkButton();
    }
    public void OW()
    {
        gm.OWButton();
    }
    public void Mythos()
    {
        gm.MythosButton();
    }
}
