using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class DataExport : MonoBehaviour
{

    public int participant_ID;

    private List<string[]> rowData = new List<string[]>();
    private string activeScene;

    // Start is called before the first frame update
    void Start()
    {
        // Add headers to the CSV file
        AddDataToRow("Participant_ID", "scene", "pupilDilation_L", "pupilDilation_R");

        // Initialize active Scene Name
        activeScene = SceneManager.GetActiveScene().name;

        // Export the data to a CSV file
        ExportToCSV("Participant_" + participant_ID + ".csv");
    }

    private void AddDataToRow(params string[] values)
    {
        rowData.Add(values);
    }

     private void ExportToCSV(string filename)
    {
        string delimiter = ",";

        // Create the directory path if it doesn't exist
        string directoryPath = Application.dataPath + "/CSV/";
        if (!Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);

        // Combine the directory path and filename
        string filePath = Path.Combine(directoryPath, filename);

        // Check if the file already exists
        bool fileExists = File.Exists(filePath);

        // Append or create a new file
        using (StreamWriter writer = new StreamWriter(filePath, append: fileExists))
        {
            // If the file doesn't exist, write headers first
            if (!fileExists)
            {
                string headerLine = string.Join(delimiter, rowData[0]);
                writer.WriteLine(headerLine);
            }

            // Write data to CSV file
            for (int i = 1; i < rowData.Count; i++)
            {
                string dataLine = string.Join(delimiter, rowData[i]);
                writer.WriteLine(dataLine);
            }
        }

        Debug.Log("CSV file exported to: " + filePath);
    }


    // Update is called once per frame
    void Update()
    {
        // Change the "," in the float to a "." so it doesn't mess with the CSV
        string dilation_L = DataScript.Dilation_L.ToString().Replace(",", ".");
        string dilation_R = DataScript.Dilation_R.ToString().Replace(",", ".");

        AddDataToRow(participant_ID.ToString(), activeScene, dilation_L, dilation_R);

        // Export the data to a CSV file
        ExportToCSV("Participant_" + participant_ID + ".csv");
    }
}
