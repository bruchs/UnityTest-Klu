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
    public InputField commentsInputField;

    public Text geographicCoordinatesOutput;
    public Text commentsOutput;
    public RawImage staticMapImage;

    public Transform postParent;
    public GameObject postGameObject;

    public string GetGeographicCordinatesInput()
    {
        return geographicCoordinatesInputField.text;
    }

    public void SetGeographicCordinatesOutput(string output)
    {
        geographicCoordinatesOutput.text = output;
    }

    public void SetStaticMapTexture(Texture2D mapTexture)
    {
        staticMapImage.texture = mapTexture;
    }

    public string GetCommentsInput()
    {
        return commentsInputField.text;
    }

    public void SetCommentsOutput(string output)
    {
        commentsOutput.text = output;
    }

    public void GeneratePost(string id, string title)
    {
        GameObject postGO = Instantiate(postGameObject);
        postGO.transform.SetParent(postParent);

        Text postText = postGO.GetComponentInChildren<Text>();
        postText.text = "ID: " + id + " - Title: " + title;
    }
}
