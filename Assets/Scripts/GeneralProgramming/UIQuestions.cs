using UnityEngine;
using UnityEngine.UI;

public class UIQuestions : MonoBehaviour
{
    public static UIQuestions instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<UIQuestions>();

            return _instance;
        }
    }

    private static UIQuestions _instance;

    public Text description;
    public InputField userInputField;

    public void SetDescription(string newDescription)
    {
        description.text = newDescription;
    }

    public string GetUserInput()
    {
        return userInputField.text;
    }
    
    public void ClearUserInput()
    {
        userInputField.text = "";
    }
}
