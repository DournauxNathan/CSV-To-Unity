/* 
 * This script is designed for use within the Unity game development environment and is primarily intended for editor-time operations. It facilitates the generation of prefabs and the saving of selected GameObjects as prefab assets
 * Details:
 * 1. "Generate Prefab" Menu Item:
      - This menu item allows the user to create prefabs based on data from a CSV file.
      - It loads a CSV file from the Resources folder, processes the data, and generates prefabs.
      - The CSV data is split into lines and cells, and the method 'CreatePrefab' is called for each line of data.
      - Depending on the content of the data, it either creates new GameObjects or modifies existing ones, adding custom components like 'MyScript,' 'SpriteRenderer,' and '
 * 2. "Save Current Selection" Menu Item:
      - This menu item enables users to save the currently selected GameObjects as prefab assets.
      - It checks if the selected GameObjects are not null and are not already assets in the project.
      - For each selected GameObject, it defines a local path for a new prefab, ensuring the name is unique.
      - It then creates a new prefab asset from the selected GameObject in the Unity project.

 * Note: This script is conditionally compiled with '#if UNITY_EDITOR,' ensuring it is only active during Unity editor sessions and won't be included in the final build of the game.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor.Events;
#endif
using UnityEngine.Events;
using UnityEditor;
using System.Linq;

[System.Serializable]
public class LoadFromCsv
{
#if UNITY_EDITOR

    // Static fields for configuration (only accessible within this script)

    internal static string fileName; //Specify the CSV file name.
    internal static string localPath = "SHEET_1"; // Specify the local path to the CSV file in the Resources folder.
    internal static char separator = ','; // Specify the separator character used in the CSV file."

    // Menu item to generate prefabs from CSV data
    [MenuItem("CSV/Generate Prefab", priority = 1)]
    public static void GeneratePrefab()
    {
        // Get the path from localPath and call LoadCSVToPrefab
        string path = localPath;
        LoadCSVToPrefab(path);
    }

    // Load and process CSV data and create prefabs
    private static void LoadCSVToPrefab(string _path)
    {
        string path = _path;

        // Load the CSV data as a TextAsset from the Resources folder
        var csvText = Resources.Load<TextAsset>(path).text;

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

        // Log a message to indicate data checking
        Debug.LogWarning("Data was checked");
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

    // Menu item to save the current selection as a prefab asset
    [MenuItem("CSV/Save Current Selection", priority = 1)]
    // Saves the currently selected GameObjects as prefab assets.
    static void SaveCurrentSelectionIntoPrefabAsset()
    {
        if (Selection.gameObjects != null && !EditorUtility.IsPersistent(Selection.activeGameObject))
        {
            foreach (var go in Selection.gameObjects)
            {
                // Define a local path for the new prefab
                string localPath = "Assets/Prefabs/Combinables/" + go.name + ".prefab";

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
