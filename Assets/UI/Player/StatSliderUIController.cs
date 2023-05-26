using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatSliderUIController : MonoBehaviour
{
    [SerializeField] PlayerUIController playerUI;
    [SerializeField] Investigator investigator;

    [SerializeField] Slider speedSneakSlider;
    [SerializeField] Slider fightWillSlider;
    [SerializeField] Slider loreLuckSlider;

    private void Start()
    {
        investigator = playerUI.GetInvestigator();
    }
}
