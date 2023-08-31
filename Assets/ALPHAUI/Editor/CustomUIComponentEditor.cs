using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace CustomGUI
{
	[CustomEditor(typeof(Toolbar))]
	public class CustomUIComponentEditor : Editor
	{        
        public override void OnInspectorGUI()
        {
            Toolbar toolbar = (Toolbar)target;

            toolbar.toolbarData = (ToolbarSO)EditorGUILayout.ObjectField("Toolbar Data", toolbar.toolbarData, typeof(ToolbarSO), false);
            toolbar.toolbarBackgroundContainer = (GameObject)EditorGUILayout.ObjectField("Toolbar BG Container", toolbar.toolbarBackgroundContainer, typeof(GameObject), false);
            toolbar.style = (Style)EditorGUILayout.EnumPopup("Style", toolbar.style);

            toolbar.toolbarData.numberOfToolbarContainers = EditorGUILayout.IntField("Number of Toolbar Containers", toolbar.toolbarData.numberOfToolbarContainers);


            if(GUILayout.Button("Update Configuration"))
            {
                toolbar.OnUpdateConfiguration();
            }
        }
    } 
}
