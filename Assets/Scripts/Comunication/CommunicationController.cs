using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CommunicationController : MonoBehaviour
{
    private const string URL_GEOCODE = "https://maps.googleapis.com/maps/api/geocode/json?address=1600";
    private const string API_KEY = "&key=AIzaSyB-5c3jTfjj9S2MYqGfOXq-zAI8fVFtqww";

    public void GetGeographicCoordinates()
    {
        string currentInput = UICommunication.instance.GetGeographicCordinatesInput();
        string[] wordsInInput = currentInput.Split(' ');
        string finalURL = URL_GEOCODE;

        foreach (string currentWord in wordsInInput)
        {
            finalURL += "+" + currentWord;
        }

        finalURL += "+" + API_KEY;
        Debug.Log(finalURL);
        StartCoroutine(WaitToGetCoordinates(finalURL));
    }

    IEnumerator WaitToGetCoordinates(string URL)
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }
}
