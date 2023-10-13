/* 
 *  CSVConfiguration Script - Created by Dournaux Nathan:
 *  
 * This script is a Unity asset that serves two primary functions:
 * 
 * 1. As a ScriptableObject, it stores configuration data related to processing CSV files.
 * 2. When used in the Unity Editor (UNITY_EDITOR preprocessor directive), it provides methods to process CSV data and generate GameObject prefabs based on the CSV content.
 * 
 * Functionalities:
 * - In the Editor, it can process a CSV file by parsing its content, creating or modifying GameObjects, and attaching components.
 * - It allows the user to specify the separator character used in the CSV.
 * - Provides a method to save the currently selected GameObjects as prefab assets.
 *  
 * Note: To fully utilize this script, it must be used in the Unity Editor.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Events;
#endif
using UnityEngine.Events;
using System.Linq;

[CreateAssetMenu(fileName = "CSVConfig", menuName = "CSV Configuration")]
public class CSVConfiguration : ScriptableObject
{
    [Tooltip("Reference to the CSV file in the Resources folder.")]
    public TextAsset csvFile;

    [Tooltip("Character used as a separator in the CSV.")]
    internal char separator = ',';

    [Tooltip("Path to save generated prefabs.")]
    public string prefabSavePath;

#if UNITY_EDITOR
    public void ProcessCSV()
    {
        if (csvFile == null)
        {
            Debug.LogError("CSV file is not assigned.");
            return;
        }

        string csvText = csvFile.text;
        string[] lines = csvText.Split('\n');

        // Rest of the CSV processing and prefab creation code here.
        LoadCSVToPrefab();

        // Log a message to indicate data checking
        Debug.LogWarning("Data was checked");
    }

    // Load and process CSV data and create prefabs
    private void LoadCSVToPrefab()
    {
        // Load the CSV data as a TextAsset from the Resources folder
        var csvText = csvFile.text;

        // Define line and cell separators
        string[] lineSeparators = new string[] { "\n", "\r", "\n\r", "\r\n" };
        char[] cellSeparator = new char[] { separator };

        // Split the CSV data into lines and cells
        var lines = csvText.Split(lineSeparators, System.StringSplitOptions.RemoveEmptyEntries);
        List<string[]> completeExcelFile = new List<string[]>();

        foreach (var i in lines)
        {
            completeExcelFile.Add(i.Split(cellSeparator, System.StringSplitOptions.RemoveEmptyEntries));
        }

        // Iterate through CSV data and create prefabs
        foreach (var item in completeExcelFile.Skip(1))
        {
            CreatePrefab(item);
        }
    }

    // Creates or modifies GameObjects in the scene based on the data provided in a CSV entry.
    static void CreatePrefab(string[] entry)
    {
        if (entry[0].Contains("TRUE"))
        {
            // Find or create a GameObject based on the entry
            GameObject newPrefab = GameObject.Find(entry[1]);

            if (newPrefab == null)
            {
                newPrefab = new GameObject(entry[1]);
            }

            var co = newPrefab.GetComponent<MyScript>();

            if (co == null)
            {
                co = newPrefab.AddComponent<MyScript>();
            }

            co.GetComponent();

            if (!co.spritRenderer)
            {
                co.spritRenderer = newPrefab.AddComponent<SpriteRenderer>();
            }

            if (!co.boxCollider)
            {
                co.boxCollider = newPrefab.AddComponent<BoxCollider>();
            }

            // Check the value in entry[3] and take different actions
            if (entry[3].Contains((char)State.State_1))
            {
                // Do something for State_1
            }
            else if (entry[3].Contains((char)State.State_2))
            {
                // Do something for State_2
            }

            // Initialize the component with the CSV data
            co.Init(entry);

            // Set the object to be the last sibling in the hierarchy
            co.transform.SetAsLastSibling();
        }
    }
#endif

#if UNITY_EDITOR
    // Saves the currently selected GameObjects as prefab assets.
    internal void SaveCurrentSelectionIntoPrefabAsset()
    {
        if (Selection.gameObjects != null && !EditorUtility.IsPersistent(Selection.activeGameObject))
        {
            foreach (var go in Selection.gameObjects)
            {
                // Define a local path for the new prefab
                string localPath = prefabSavePath+"/" + go.name + ".prefab";

                // Ensure the file name is unique
                localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);

                // Create a new prefab from the selected GameObject
                PrefabUtility.SaveAsPrefabAssetAndConnect(go, localPath, InteractionMode.UserAction);
            }
        }
        else
        {
            // Log a warning if the selection is null
            Debug.LogWarning("Selection is null");
        }
    }
#endif
}
