using UnityEditor;
#if UNITY_2020_2_OR_NEWER
using UnityEditor.AssetImporters;
#else
using UnityEditor.Experimental.AssetImporters;
#endif
using UnityEngine;

namespace Microsoft.Build.Unity
{
    partial class MSBuildProjectImporter
    {
        [CustomEditor(typeof(MSBuildProjectImporter))]
        private sealed class MSBuildProjectImporterEditor : ScriptedImporterEditor
        {
            public override void OnInspectorGUI()
            {
                var msBuildProjectReference = (MSBuildProjectReference)this.assetTarget;

                // Build & Rebuild buttons
                GUI.enabled = !this.serializedObject.hasModifiedProperties;
                try
                {
                    msBuildProjectReference.DrawBuildButtons();
                }
                finally
                {
                    GUI.enabled = true;
                }

                Editor.DrawPropertiesExcluding(this.serializedObject, "m_Script");

                this.ApplyRevertGUI();
            }
        }
    }
}