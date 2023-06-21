using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataExport : MonoBehaviour
{
    public int participant_ID;
    public string calculationMethod;

    private string activeScene;
    private string filename;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize active Scene Name
        activeScene = SceneManager.GetActiveScene().name;

        calculationMethod = calculationMethod.ToUpper();
        switch (calculationMethod)
        {
            case "A":
                DataScript.CalculationMethod = "A";
                Debug.Log("Average Eye Data is used");
                break;
            case "L":
                DataScript.CalculationMethod = "L";
                Debug.Log("Left Eye Data is used");
                break;
            case "R":
                DataScript.CalculationMethod = "R";
                Debug.Log("Right Eye Data is used");
                break;
            default:
                Debug.Log("Invalid Calculation Method selected! Please only enter 'A', 'L' or 'R'");
                break;
        }

        // Set the filename based on the participant ID
        filename = "Participant_" + participant_ID + ".csv";

        // Create the CSV file if it doesn't exist and write the headers
        if (!File.Exists(GetFilePath(filename)))
        {
            string[] headers = { "calculationMethod", "scene", "speed","phase","pupilDilation_L", "pupilDilation_R", "gazePosition" };
            AppendToCSV(filename, headers);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Change the "," in the float to a "." so it doesn't mess with the CSV
        string dilation_L = DataScript.Dilation_L.ToString().Replace(",", ".");
        string dilation_R = DataScript.Dilation_R.ToString().Replace(",", ".");

        // Create a string array with the data to append
        string[] data = {
            DataScript.CalculationMethod,
            activeScene,
            DataScript.Wpm.ToString(),
            DataScript.Phase,
            dilation_L,
            dilation_R,
            DataScript.HitPoint.ToString()
        };

        // Append the data to the CSV file
        AppendToCSV(filename, data);
    }

    private void AppendToCSV(string filename, string[] data)
    {
        // Combine the directory path and filename
        string filePath = GetFilePath(filename);

        // Append the data to the CSV file
        using (StreamWriter writer = File.AppendText(filePath))
        {
            string dataLine = string.Join(",", data);
            writer.WriteLine(dataLine);
        }
    }

    private string GetFilePath(string filename)
    {
        // Create the directory path if it doesn't exist
        string directoryPath = Path.Combine(Application.dataPath, "CSV");
        if (!Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);

        // Combine the directory path and filename
        return Path.Combine(directoryPath, filename);
    }
}
