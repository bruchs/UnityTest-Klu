using UnityEngine;
using UnityEngine.UI;

public class UICommunication : MonoBehaviour
{
    public static UICommunication instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<UICommunication>();

            return _instance;
        }
    }

    private static UICommunication _instance;

    public InputField geographicCoordinatesInputField;
    public Text geographicCoordinatesOutput;

    public string GetGeographicCordinatesInput()
    {
        return geographicCoordinatesInputField.text;
    }

    public void SetGeographicCordinatesOutput(string output)
    {
        geographicCoordinatesOutput.text = output;
    }
}
