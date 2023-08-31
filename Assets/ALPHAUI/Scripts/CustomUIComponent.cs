using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomGUI
{    public abstract class CustomUIComponent : MonoBehaviour
    {
        public float ResetInspector;
        protected void Awake() { Init(); }

        private void Init()
        {
            if (!this.gameObject.activeInHierarchy) return;
            Setup();
            Configure();
        }

        public abstract void Setup();
        public abstract void Configure();

        private void OnValidate()
        {
            Init();
        }
        public void OnUpdateConfiguration() 
        { 
            if (!this.gameObject.activeInHierarchy) 
                return;
            Init();
        }
    }
}