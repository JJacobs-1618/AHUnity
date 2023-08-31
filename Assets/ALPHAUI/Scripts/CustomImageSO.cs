using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomGUI
{
    [CreateAssetMenu(menuName = "CustomUI/CustomImageSO", fileName = "CustomImageSO")]
    public class CustomImageSO : ScriptableObject
    {
        public Sprite source;
        public bool IsRayCastable;
        public Vector4 rayCastPadding;
    }
}