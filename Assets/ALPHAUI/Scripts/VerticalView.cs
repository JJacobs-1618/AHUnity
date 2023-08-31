using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CustomGUI
{
    public class VerticalView : CustomUIComponent
    {
        public ViewSO viewData;

        public GameObject containerTop;
        public GameObject containerCenter;
        public GameObject containerBottom;

        private Image imageTop;
        private Image imageCenter;
        private Image imageBottom;

        private VerticalLayoutGroup verticalLayoutGroup;
        private LayoutElement centerLayoutElement;

        public override void Setup()
        {
            verticalLayoutGroup = GetComponent<VerticalLayoutGroup>();
            centerLayoutElement = containerCenter.GetComponent<LayoutElement>();

            imageTop = containerTop.GetComponent<Image>();
            imageCenter = containerCenter.GetComponent<Image>();
            imageBottom = containerBottom.GetComponent<Image>();
        }

        public override void Configure()
        {
            verticalLayoutGroup.padding = viewData.padding;
            verticalLayoutGroup.spacing = viewData.spacing;

            centerLayoutElement.flexibleHeight = viewData.middleContainerFlexAmount;

            imageTop.color = viewData.theme.primary_bg;
            imageCenter.color = viewData.theme.secondary_bg;
            imageBottom.color = viewData.theme.tertiary_bg;
        }
    }
}