using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDetailsUIController : MonoBehaviour
{
    [SerializeField] PlayerUIController uiController;
    [SerializeField] GameObject inventoryUI;
    [SerializeField] GameObject detailedStatsUI;
    [SerializeField] Investigator investigator;
    [SerializeField] TextMeshProUGUI currentSanityText;
    [SerializeField] TextMeshProUGUI currentStaminaText;

    private void Start()
    {
        //inventoryUI.SetActive(false);
        //detailedStatsUI.SetActive(false);
        //investigator = uiController.GetInvestigator();
        //currentSanityText.text = investigator.GetStats().GetCurrentSanity().ToString();
        //currentStaminaText.text = investigator.GetStats().GetCurrentStamina().ToString();
    }

    public void InventoryButton()
    {
        if (inventoryUI.activeSelf)
            hideInventory();
        else
            showInventory();
    }
    public void DetailedStatsButton()
    {
        if (detailedStatsUI.activeSelf)
            hideDetailedStats();
        else
            showDetailedStats();
    }

    public void UpdateStatsText()
    {
        //currentSanityText.text = investigator.GetStats().GetCurrentSanity().ToString();
        //currentStaminaText.text = investigator.GetStats().GetCurrentStamina().ToString();
    }

    private void showInventory() { inventoryUI.SetActive(true); }
    private void hideInventory() { inventoryUI.SetActive(false); }
    private void showDetailedStats() { detailedStatsUI.SetActive(true); }
    private void hideDetailedStats() { detailedStatsUI.SetActive(false); }
}

