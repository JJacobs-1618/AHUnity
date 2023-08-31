using System;
using UnityEngine;

namespace CustomGUI
{
    [CreateAssetMenu(menuName = "CustomUI/ViewSO", fileName = "ViewSO")]
    public class ViewSO : ScriptableObject
    {
        public ThemeSO theme;
        public RectOffset padding;
        public float spacing;
        public float middleContainerFlexAmount;

        public delegate void EditorUpdate();
        public static EditorUpdate OnEditorUpdate;

        private void OnValidate()
        {
            if (OnEditorUpdate != null)
                OnEditorUpdate();
        }
    }
}


