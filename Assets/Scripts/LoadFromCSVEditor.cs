/*
 * CSVConfigurationEditor - Created by Dournaux Nathan:
 * This script is an Editor script in Unity, used for customizing the inspector interface for a component of type CSVConfiguration.
 * It allows the user to set various properties and perform actions using buttons and labels in the Inspector.
 */
using UnityEditor;
using UnityEngine;

// Custom editor for the CSVConfiguration component
[CustomEditor(typeof(CSVConfiguration))]
public class CSVConfigurationEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Cast the target object to a CSVConfiguration
        CSVConfiguration config = (CSVConfiguration)target;

        // Draw the default inspector for the CSVConfiguration component
        DrawDefaultInspector();

        GUILayout.BeginHorizontal();

        // Add a label for the Separator
        GUILayout.Label("Separator", GUILayout.Width(100));

        // If "Comma" button is clicked, set the separator to a comma
        if (GUILayout.Button("Comma"))
        {
            config.separator = ',';
        }

        // If "Semicolon" button is clicked, set the separator to a semicolon
        if (GUILayout.Button("Semicolon"))
        {
            config.separator = ';';
        }

        GUILayout.EndHorizontal();

        // Button to trigger the "Generate Prefabs" action
        if (GUILayout.Button("Generate Prefabs"))
        {
            config.ProcessCSV();
        }

        // Button to trigger the "Save Prefabs" action
        if (GUILayout.Button("Save Prefabs"))
        {
            config.SaveCurrentSelectionIntoPrefabAsset();
        }
    }
}
