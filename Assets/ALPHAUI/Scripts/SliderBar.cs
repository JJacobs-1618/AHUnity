using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CustomGUI
{

    public class SliderBar : CustomUIComponent
    {        
        public SliderBarSO sliderData;
        public Style style;

        public GameObject sliderContainer;
        public GameObject sliderBackground;
        public GameObject fillArea;
        public GameObject handleArea;

        private Slider slider;
        private Image backgroundImage;
        private Image fillImage;
        private Image handleImage;

        public override void Setup()
        {
            slider = sliderContainer.GetComponent<Slider>();
            //slider.value = Reset;
            backgroundImage = sliderBackground.GetComponent<Image>();
            fillImage = fillArea.GetComponentInChildren<Image>();
            handleImage = handleArea.GetComponentInChildren<Image>();
        }
        public override void Configure()
        {
            ColorBlock cb = slider.colors;
            cb.normalColor = sliderData.theme.GetBackgroundColor(Style.Tertiary);
            slider.colors = cb;
            backgroundImage.color = sliderData.theme.GetBackgroundColor(Style.Primary);
            fillImage.color = sliderData.theme.GetBackgroundColor(Style.Secondary);
            handleImage.sprite = sliderData.handleImage;
        }
    } 
}
