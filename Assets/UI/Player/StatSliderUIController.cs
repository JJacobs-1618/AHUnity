using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StatSliderUIController : MonoBehaviour, IUpkeepable
{
    [SerializeField] PlayerUIController playerUI;
    [SerializeField] Investigator investigator;
    [SerializeField] InvestigatorStats stats;

    [SerializeField] TextMeshProUGUI availableFocusText;

    [SerializeField] Slider speedSneakSlider;
    [SerializeField] Slider fightWillSlider;
    [SerializeField] Slider loreLuckSlider;

    StandaloneInputModule input;

    int availableFocus;
    int priorSpeedSneakValue;
    bool updatedSpeedSneak;
    int priorFightWillValue;
    bool updatedFightWill;
    int priorLoreLuckValue;
    bool updatedLoreLuck;


    private void Start()
    {
        investigator = playerUI.GetInvestigator();
        stats = investigator.GetStats();
        
        Reset();

        speedSneakSlider.onValueChanged.AddListener(delegate { speedSneakSliderChanged(); });
        fightWillSlider.onValueChanged.AddListener(delegate { fightWillSliderChanged(); });
        loreLuckSlider.onValueChanged.AddListener(delegate { loreLuckSliderChanged(); });

        availableFocusText.text = availableFocus.ToString();

        input = EventSystem.current.GetComponent<StandaloneInputModule>();
    }

    private void Reset() 
    { 
        availableFocus = stats.GetFocus();

        updatedSpeedSneak = false;
        updatedFightWill = false;
        updatedLoreLuck = false;

        availableFocusText.text = availableFocus.ToString();
    }
    public void InitialSetup()
    {
        availableFocus = int.MaxValue;
        availableFocusText.text = "No Limit.";
    }
    private void speedSneakSliderChanged()
    {
        SliderChanged(ref updatedSpeedSneak, priorSpeedSneakValue, speedSneakSlider);
    }
    private void fightWillSliderChanged()
    {
        SliderChanged(ref updatedFightWill, priorFightWillValue, fightWillSlider);
    }
    private void loreLuckSliderChanged()
    {
        SliderChanged(ref updatedLoreLuck, priorLoreLuckValue, loreLuckSlider);
    }

    private void SliderChanged(ref bool isUpdated, int priorValue, Slider changedSlider)
    {
        if (PhaseManager.instance.GetCurrentGamePhase() == GamePhase.InvestigatorSetup)
            return;

        if (availableFocus < 0)
        {
            // Error State
            Debug.LogError("Total Available Focus below maximum value.");
            return;
        }
        int delta = Mathf.Abs(priorValue - (int)changedSlider.value);
        if (availableFocus == 0) // Only thing to do is either reset a slider that is attempting to move, or add to the available focus
        {
            if (!isUpdated)
            {
                changedSlider.value = priorValue;
            }
            else if (GetTotalSlides() > stats.GetFocus()) // attempt to increase distance from prior value, so reset
            {
                if (priorValue > (int)changedSlider.value)   // if the prior value is larger than the new value, then it is sliding to the left
                    changedSlider.SetValueWithoutNotify(changedSlider.value + 1);
                else                                                    // else it's movin' to the right
                    changedSlider.SetValueWithoutNotify(changedSlider.value - 1);

                StartCoroutine(PreventSlider());
            }
            else
            {
                availableFocus++;
                availableFocus = Mathf.Clamp(availableFocus, 0, stats.GetFocus());
                availableFocusText.text = availableFocus.ToString();
                if (GetTotalSlides() == 0) // this is a reset slider
                    isUpdated = false;
            }
        }
        else if (availableFocus > 0 && GetTotalSlides() <= stats.GetFocus())
        {
            if (!isUpdated)
            {
                isUpdated = true;
                availableFocus--;
            }
            else
                availableFocus = Mathf.Abs(stats.GetFocus() - GetTotalSlides());
            
            availableFocus = Mathf.Clamp(availableFocus, 0, stats.GetFocus());
            availableFocusText.text = availableFocus.ToString();
        }
    }

    private IEnumerator PreventSlider()
    {
        input.DeactivateModule();
        yield return null;
    }

    private int GetTotalSlides()
    {
        int retVal = 0;

        if (updatedSpeedSneak) retVal += FindDelta((int)speedSneakSlider.value, priorSpeedSneakValue);
        if (updatedFightWill) retVal += FindDelta((int)fightWillSlider.value, priorFightWillValue);        
        if (updatedLoreLuck) retVal += FindDelta((int)loreLuckSlider.value, priorLoreLuckValue);

        return retVal;
    }

    private int FindDelta(int sliderValue, int priorValue)
    {
        return Mathf.Abs(priorValue - sliderValue);
    }

    public void StartUpkeep()
    {
        Reset();
    }
    public void CompleteUpkeep()
    {

    }

    public void CloseSliders()
    {
        stats.SetSpeed(stats.speedStart + (int)speedSneakSlider.value);
        stats.SetSneak(stats.sneakStart - (int)speedSneakSlider.value);
        priorSpeedSneakValue = (int)speedSneakSlider.value;
        stats.SetFight(stats.fightStart + (int)fightWillSlider.value);
        stats.SetWill(stats.willStart - (int)fightWillSlider.value);
        priorFightWillValue = (int)fightWillSlider.value;
        stats.SetLore(stats.loreStart + (int)loreLuckSlider.value);
        stats.SetLuck(stats.luckStart - (int)loreLuckSlider.value);
        priorLoreLuckValue = (int)loreLuckSlider.value;

        this.gameObject.SetActive(false);
        if (PhaseManager.instance.GetCurrentGamePhase() == GamePhase.InvestigatorSetup)
        {
            investigator.performedSetup = true;
            PhaseManager.instance.UpdateGamePhase(GamePhase.InvestigatorSetup);
        }
    }
}
