# CSV-to-Unity

## Description

This Unity project is designed to help you manage and process CSV data in a Unity scene by creating GameObjects and associating data with them. The project includes three key scripts: `CSVConfiguration`, `MyScript`, and `CSVConfigurationEditor`. 
These scripts work together to facilitate the loading and creation of GameObjects based on CSV data and enable customization of the Inspector interface for the CSV configuration.

## Table of Contents

1. [Getting Started](#getting-started)
2. [Functionality](#functionality)
3. [Scripts](#scripts)
   1. [CSVConfiguration](#csvconfiguration)
   2. [MyScript](#myscript)
   3. [CSVConfigurationEditor](#csvconfigurationeditor)
4. [Usage](#usage)
5. [Contributing](#contributing)
6. [License](#license)

## Getting Started

To get started with this project, follow these steps:

1. Clone or download the project repository.
2. Open the project in Unity.
### OR
1. Download the [CSV-to-Unity.unitypack][(URL)](https://github.com/DournauxNathan/CSV-to-Unity/releases/download/unityPackage/CSV-to-Unity.unitypackage)
## Functionality

This project offers the following key functionalities:

1. **CSV Data Processing:** It can process CSV data, read the content, and create or modify GameObjects in your Unity scene. The processing is customizable, allowing you to specify the separator character used in the CSV.

2. **Prefab Generation:** You can generate GameObject prefabs based on the CSV content.

3. **CSV Configuration:** You can create and configure a `CSVConfiguration` ScriptableObject to specify the CSV file to be processed, the separator character, and the save path for generated prefabs.

4. **Inspector Customization:** The custom editor script, `CSVConfigurationEditor`, enhances the Inspector interface for `CSVConfiguration` objects. It provides options for setting the separator character and buttons to trigger the CSV processing and prefab generation.

## Scripts

### CSVConfiguration

`CSVConfiguration` is a ScriptableObject used to store configuration data related to processing CSV files. It has the following fields:

- `csvFile`: A reference to the CSV file in the Resources folder.
- `separator`: The character used as a separator in the CSV.
- `prefabSavePath`: The path to save generated prefabs.

It provides the following methods:

- `ProcessCSV`: Processes the CSV data, creates GameObjects, and attaches components.
- `SaveCurrentSelectionIntoPrefabAsset`: Saves the currently selected GameObjects as prefab assets.

### MyScript

`MyScript` is a MonoBehaviour script for managing a GameObject's attributes, components, and data. It includes the following features:

- Fields for managing the object's data, such as name, ID, state, and combinations.
- Fields for storing references to `SpriteRenderer` and `BoxCollider` components.
- Methods for initializing the object, loading combinations of data, and retrieving component references.

### CSVConfigurationEditor

`CSVConfigurationEditor` is a custom editor script that enhances the Inspector interface for `CSVConfiguration` objects. It provides options to set the separator character and buttons to trigger CSV processing and prefab generation.

## Usage

To use this project, follow these steps:

1. Create a `CSVConfiguration` asset:
   - Right-click in your Unity project.
   - Select "Create" -> "CSV Configuration" to create a new configuration asset.
   - Assign a CSV file, separator character, and prefab save path in the Inspector.

2. Customize your CSV file:
   - Ensure your CSV file is in the Resources folder.
   - Modify the CSV data as needed, following the format expected by the project.

3. Set up your GameObjects:
   - Create GameObjects in your scene to correspond with the data in your CSV file.
   - Attach the `MyScript` component to these GameObjects.

4. Trigger CSV Processing:
   - Select a `CSVConfiguration` asset in the Project window.
   - Click the "Generate Prefabs" button to process the CSV data and generate GameObjects based on it.

5. Customize Inspector (Optional):
   - Use the `CSVConfigurationEditor` script to customize the Inspector for `CSVConfiguration` assets. You can set the separator character and trigger CSV processing.

6. Save Prefabs (Optional):
   - After generating GameObjects, you can save them as prefab assets by selecting them in the Hierarchy and clicking the "Save Prefabs" button in the Inspector.
