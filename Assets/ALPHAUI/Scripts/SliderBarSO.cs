using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CustomGUI
{
    [CreateAssetMenu(menuName = "CustomUI/SliderBarSO", fileName = "SliderBarSO")]
    public class SliderBarSO : ScriptableObject
    {
        public ThemeSO theme;
        public Sprite handleImage;
    } 
}
