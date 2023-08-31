using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CustomGUI
{
    [CreateAssetMenu(menuName = "CustomUI/ToolbarSO", fileName = "ToolbarSO")]
    public class ToolbarSO : ScriptableObject
    {
        [Tooltip("Number of Toolbar Containers. Cannot be Negative. Supported up to 15 Containers")]
        public int numberOfToolbarContainers;
        public bool autoPadAndSpace;
        public RectOffset padding;
        public float spacing;
        public Vector2 containerSize;
        public ThemeSO theme;
        public Sprite toolbarBackgroundImage;
        public Sprite[] toolbarImages;
        public Sprite defaultImage;

        private void OnValidate()
        {
            if (containerSize.x < 5 || containerSize.y < 5)
                containerSize = new Vector2(10, 10);
        }
    } 
}