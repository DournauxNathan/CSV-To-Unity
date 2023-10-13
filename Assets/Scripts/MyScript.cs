/*
 * MyScript - Created by Dournaux Nathan:
 * MyScript is designed to manage a GameObject's attributes, components, and data.
 * It includes methods for initializing the object, loading combinations of data, and retrieving component references.
 * This script is suitable for handling object properties and interactions within a Unity scene.
 * Note : You can modify it to suit your project ! Don't only forget to correctly name your variabl, chekc their accessibility.
 * And for you own CSV file, Chekc your colum, t osee if it correctly corresponding to the entry of when reading the CSV file.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;
using UnityEditor.Events;

[System.Serializable]
public class MyScript : MonoBehaviour
{
    //This section defines data-related fields and an array for the object.
    #region DATA
    [Header("DATA")]
    private bool isGenerate;  // Indicates whether this object is set to generate.

    private new string name;  // The name of the object.
    private int iD;          // The unique identifier (ID) of the object.
    private State state;     // The state of the object.
    private int totalCombination;  // The total number of combinations associated with the object.

    public Combination[] combinaisons;  // Tooltip: An array of Combination objects representing different combinations.

    [System.Serializable]
    public class Combination
    {
        public string name;
        public int influence;
        public string outcome;
    }
    #endregion
    
    // This section defines a private field to store a Component component and a public property to access it.
    #region COMPONENT

    [Header("COMPONENT")]
    private SpriteRenderer m_SpriteRenderer; // Private field to store the SpriteRenderer component.
    public SpriteRenderer spritRenderer
{
        get => m_SpriteRenderer; // Getter returns the stored SpriteRenderer component.
        set => m_SpriteRenderer = value; // Setter assigns a new SpriteRenderer component to the field.
    }

    private BoxCollider m_BoxCollider;
    public BoxCollider boxCollider { get => m_BoxCollider; set => m_BoxCollider = value; }
    #endregion

    /* This method sets the basic attributes of the GameObject, including its name, ID, state, and the total number of combinations it has. 
     * It also initializes the 'combinaisons' array with the specified 'totalCombination'.

       Parameters:
       - name: The name of the object.
       - iD: The unique identifier (ID) of the object.
       - state: The state of the object.
       - totalCombination: The total number of combinations associated with the object.
    */
    internal void Init(string[] entry)
    {
        // Load all information from a CSV file into a GameObject

        // Step 1: Initialize the basic information of the GameObject
        LoadBaseInfo(entry[1], int.Parse(entry[2]), GetStateFromEntry(entry), int.Parse(entry[4]));

        // Step 2: Load the combination data into the 'combinaisons' array
        LoadCombination(combinaisons, totalCombination, entry);

        // Step 3: Perform any additional setup or get other components
        GetComponent();
    }

    /* This method initializes the base information of the object */
    internal void LoadBaseInfo(string name, int iD, State state, int totalCombination)
    {
        // Set the object's name, ID, state, and the total number of combinations it has
        this.name = name;
        this.iD = iD;
        this.state = state;
        this.totalCombination = totalCombination;

        // Initialize the 'combinaisons' array with the specified totalCombination
        combinaisons = new Combination[totalCombination];
    }

    /* This method returns the state of the object based on the CSV file information */
    internal State GetStateFromEntry(string[] entry)
    {
        // Check the entry data to determine the object's state
        if (entry[3].Contains("State_1"))
        {
            state = State.State_1;
        }
        else if (entry[3].Contains("State_2"))
        {
            state = State.State_2;
        }

        return state;
    }

    // Summary: Loads data from the 'entry' array into an array of 'Combination' objects.
    // Populates each 'Combination' object with 'name', 'influence', and 'outcome' properties,
    // where each set of data in the 'entry' array is represented as one 'Combination' object.
    // Parameters:
    // - array: The target array of 'Combination' objects to be populated.
    // - totalCombi: The total number of combinations to load.
    // - entry: The source array containing data to be loaded into 'Combination' objects.
    internal void LoadCombination(Combination[] array, int totalCombi, string[] entry)
    {
        // Initialize a variable to keep track of the last column index
        int lastColumn = 5;

        // Loop through the totalCombi number of times
        for (int i = 0; i < totalCombi; i++)
        {
            // Create a new Combination object and populate its properties
            array[i] = new Combination
            {
                // Set the 'name' property to the value at the current 'lastColumn' index in the 'entry' array
                name = entry[lastColumn],

                // Set the 'influence' property to the integer value obtained by parsing the element in 'entry' at 'lastColumn + 1'
                influence = int.Parse(entry[lastColumn + 1]),

                // Set the 'outcome' property to the value at 'entry' index 'lastColumn + 2'
                outcome = entry[lastColumn + 2]
            };

            // Increment the 'lastColumn' index by 3 to move to the next set of columns in the 'entry' array
            lastColumn += 3;
        }
    }

    internal void GetComponent()
    {
        // Get the SpriteRenderer component from the GameObject
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        // Get the BoxCollider component from the GameObject
        m_BoxCollider = GetComponent<BoxCollider>();
    }
}

public enum State
{
    State_1,
    State_2
}
