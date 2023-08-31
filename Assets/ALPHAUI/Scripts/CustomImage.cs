using UnityEngine.UI;

namespace CustomGUI 
{
    public class CustomImage : CustomUIComponent
{
        public Image image;
        public CustomImageSO imageData;
        public ThemeSO theme;
        public Style style;

        public override void Setup()
        {
            image = GetComponentInChildren<Image>();
        }

        public override void Configure()
        {
            image.sprite = imageData.source;
            image.color = theme.GetBackgroundColor(style);
            if (image.raycastTarget = imageData.IsRayCastable)
            {
                image.raycastPadding = imageData.rayCastPadding;
            }
        }
    }
}

