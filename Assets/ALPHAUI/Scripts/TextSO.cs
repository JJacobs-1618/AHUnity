using TMPro;
using UnityEngine;

namespace CustomGUI
{
    [CreateAssetMenu(menuName = "CustomUI/TextSO", fileName = "TextSO")]
    public class TextSO : ScriptableObject
    {
        public ThemeSO theme;

        public string displayText;
        public TMP_FontAsset font;
        public float size;

        public delegate void EditorUpdate();
        public static EditorUpdate OnEditorUpdate;

        private void OnValidate()
        {
            if (OnEditorUpdate != null)
                OnEditorUpdate();
        }
    }
}