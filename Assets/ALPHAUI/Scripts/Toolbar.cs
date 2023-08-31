using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CustomGUI
{
    public class Toolbar : CustomUIComponent
    {   
        public ToolbarSO toolbarData;
        public Style style;
        public GameObject toolbarBackgroundContainer;
        public Sprite defaultImage;

        private HorizontalLayoutGroup horizontalLayoutGroup;

        private Image toolbarBackgroundImage;
        private List<GameObject> toolbarContainers;
        private List<Image> toolbarImages;

        public override void Setup()
        {
            InitToolbar();
        }

        public override void Configure()
        {
            horizontalLayoutGroup.padding = toolbarData.autoPadAndSpace ? new RectOffset(12, 12, 12, 12) : toolbarData.padding;
            horizontalLayoutGroup.spacing = toolbarData.autoPadAndSpace ? 5 : toolbarData.spacing;

            toolbarBackgroundImage.color = toolbarData.theme.GetBackgroundColor(style);
            toolbarBackgroundImage.sprite = toolbarData.toolbarBackgroundImage;

            foreach (GameObject go in toolbarContainers)
            {
                go.GetComponent<RectTransform>().sizeDelta = toolbarData.containerSize;
            }
            if (toolbarImages.Count != toolbarData.toolbarImages.Length)
            {
                if (toolbarImages.Count > toolbarData.toolbarImages.Length)
                    Debug.LogWarning("Number of Available Containers exceeds Provided Sprites. Applying default to missing entries...");
                else
                    Debug.LogWarning("Number of Provided Sprites exceeds Available Containers. Applying Sprites...");
            }
            for(int i = 0; i < toolbarImages.Count; i++)
            {
                toolbarImages[i].sprite = toolbarData.toolbarImages.Length > i ? toolbarData.toolbarImages[i] : toolbarData.defaultImage;
            }
        }

        private void InitToolbar()
        {
            ClearContainers();
            horizontalLayoutGroup = GetComponent<HorizontalLayoutGroup>();
            toolbarBackgroundImage = toolbarBackgroundContainer.GetComponent<Image>();

            toolbarContainers = new List<GameObject>();
            toolbarImages = new List<Image>();

            GameObject container = CreateContainer();

            for (int i = 0; i < toolbarData.numberOfToolbarContainers; i++)
            {
                AddContainer(container);
            }

            DestroyContainer(container);
        }

        private void ClearContainers()
        {
            int currentContainerCount = this.transform.childCount - 1;

            for(int i = 0; i < currentContainerCount; i++)
            {
                RemoveContainer(this.transform.GetChild(i+1).gameObject);
            }
        }

        private void AddContainer(GameObject container)
        {
            toolbarContainers.Add(Instantiate(container, this.transform));
            toolbarImages.Add(toolbarContainers[toolbarContainers.Count - 1].GetComponent<Image>());
        }

        private void RemoveContainer(GameObject container)
        {
            if(toolbarContainers != null) 
                toolbarContainers.Remove(container);
            container.SetActive(false);
            DestroyContainer(container);
        }

        internal GameObject CreateContainer()
        {
            GameObject container = new GameObject("Container");
            RectTransform rect = container.AddComponent<RectTransform>();
            rect.transform.SetParent(container.transform);
            rect.localScale = Vector3.one;
            rect.sizeDelta = toolbarData.containerSize;

            container.AddComponent<Image>();

            return container;
        }

        internal void DestroyContainer(GameObject container)
        {
            UnityEditor.EditorApplication.delayCall += () =>
            {
                DestroyImmediate(container, true);                
            };
        }
    }
}