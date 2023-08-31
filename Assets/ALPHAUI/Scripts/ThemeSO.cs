using UnityEngine;

namespace CustomGUI
{

    [CreateAssetMenu(menuName = "CustomUI/ThemeSO", fileName = "ThemeSO")]
    public class ThemeSO : ScriptableObject
    {
        [Header("Primary")]
        public Color primary_bg;
        public Color primary_text;
        [Header("Secondary")]
        public Color secondary_bg;
        public Color secondary_text;
        [Header("Tertiary")]
        public Color tertiary_bg;
        public Color tertiary_text;
        [Header("Other")]
        public Color disable;

        public delegate void EditorUpdate();
        public static EditorUpdate OnEditorUpdate;

        public ThemeSO()
        {
            primary_bg.a = 1;
            primary_text.a = 1;
            secondary_bg.a = 1;
            secondary_text.a = 1;
            tertiary_bg.a = 1;
            tertiary_text.a = 1;
            disable.a = 1;
        }

        public Color GetBackgroundColor(Style style)
        {
            Color textColor = Color.clear;
            switch (style)
            {
                case Style.Primary:
                    textColor = primary_bg;
                    break;
                case Style.Secondary:
                    textColor = secondary_bg;
                    break;
                case Style.Tertiary:
                    textColor = tertiary_bg;
                    break;
                case Style.Default:
                    textColor = disable;
                    break;
                default:
                    Debug.LogWarning("BackGroundColor Style unset. Returning clear");
                    break;
            }
            return textColor;
        }

        public Color GetTextColor(Style style)
        {
            Color textColor = Color.clear;
            switch (style)
            {
                case Style.Primary:
                    textColor = primary_text;
                    break;
                case Style.Secondary:
                    textColor = secondary_text;
                    break;
                case Style.Tertiary:
                    textColor = tertiary_text;
                    break;
                case Style.Default:
                    textColor = disable;
                    break;
                default:
                    Debug.LogWarning("TextColor Style unset. Returning clear");
                    break;
            }
            return textColor;
        }

        private void OnValidate()
        {
            OnEditorUpdate?.Invoke();
        }
    }
}
