using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CustomGUI
{
    public class HorizontalView : CustomUIComponent
    {
        public ViewSO viewData;
                
        public GameObject containerLeft;
        public GameObject containerCenter;
        public GameObject containerRight;
                
        private Image imageLeft;
        private Image imageCenter;
        private Image imageRight;

        private HorizontalLayoutGroup horizontalLayoutGroup;
        private LayoutElement centerLayoutElement;

        public override void Setup()
        {
            horizontalLayoutGroup = GetComponent<HorizontalLayoutGroup>();
            centerLayoutElement = containerCenter.GetComponent<LayoutElement>();

            imageLeft = containerLeft.GetComponent<Image>();
            imageCenter = containerCenter.GetComponent<Image>();
            imageRight = containerRight.GetComponent<Image>();
        }

        public override void Configure()
        {
            horizontalLayoutGroup.padding = viewData.padding;
            horizontalLayoutGroup.spacing = viewData.spacing;
            centerLayoutElement.flexibleWidth = viewData.middleContainerFlexAmount;

            imageLeft.color = viewData.theme.primary_bg;
            imageCenter.color = viewData.theme.secondary_bg;
            imageRight.color = viewData.theme.tertiary_bg;
        }
    } 
}
