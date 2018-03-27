using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using Newtonsoft.Json;
using Boo.Lang;

public class CommunicationController : MonoBehaviour
{
    private const string SERVER_URL = "https://my-json-server.typicode.com/typicode/demo/db";
    private const string URL_GEOCODE = "https://maps.googleapis.com/maps/api/geocode/json?address=";
    private const string URL_STATIC_MAPS = "https://maps.googleapis.com/maps/api/staticmap?center=";

    private const string KEY_GEOCODE = "&key=AIzaSyB-5c3jTfjj9S2MYqGfOXq-zAI8fVFtqww";
    private const string KEY_STATIC_MAPS = "&key=AIzaSyAmhwlVqTmYorVOew2iTYnvV9qI9xVJVa8";

    private void Start()
    {
        StartCoroutine(WaitToGetPosts());
    }

    public void GetCommentByIndex()
    {
        string commentsInput = UICommunication.instance.GetCommentsInput();
        int index;

        if (int.TryParse(commentsInput, out index))
        {
            StartCoroutine(WaitToGetCommentByIndex(index));
        }
        else
        {
            UICommunication.instance.SetCommentsOutput("Please Use A Number");
        }
    }

    private IEnumerator WaitToGetPosts()
    {
        UnityWebRequest www = UnityWebRequest.Get(SERVER_URL);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string responseText = www.downloadHandler.text;
            DemoData demoData = JsonConvert.DeserializeObject<DemoData>(responseText);

            foreach(Post cPost in demoData.posts)
            {
                UICommunication.instance.GeneratePost(cPost.id.ToString(), cPost.title);
            }
        }
    }

    private IEnumerator WaitToGetCommentByIndex(int commentIndex)
    {
        UnityWebRequest www = UnityWebRequest.Get(SERVER_URL);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string responseText = www.downloadHandler.text;
            DemoData demoData = JsonConvert.DeserializeObject<DemoData>(responseText);

            if(commentIndex < demoData.comments.Count)
            {
                Comment currentComment = demoData.comments[commentIndex];
                UICommunication.instance.SetCommentsOutput("Comment ID: " + currentComment.id + " Post ID: " + currentComment.postId + " Body: " + currentComment.body);
            }
            else
            {
                UICommunication.instance.SetCommentsOutput("Out Of Range");
            }
        }
    }

    public void GetGeographicCoordinates()
    {
        string currentInput = UICommunication.instance.GetGeographicCordinatesInput();
        string[] wordsInInput = currentInput.Split(' ');
        string finalURL = URL_GEOCODE;

        foreach (string currentWord in wordsInInput)
        {
            finalURL += "+" + currentWord;
        }

        finalURL += "+" + KEY_GEOCODE;
        Debug.Log(finalURL);
        StartCoroutine(WaitToGetResponse(finalURL));
    }

    private IEnumerator WaitToGetResponse(string URL)
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string responseText = www.downloadHandler.text;
            ManageResponse(responseText);
        }
    }

    private void ManageResponse(string currentJson)
    {
        RootObject currentRoot = JsonConvert.DeserializeObject<RootObject>(currentJson);
        Result currentResult = currentRoot.results[0];

        Geometry geometry = currentResult.geometry;
        Location location = geometry.location;

        double latitude = location.lat;
        double longitude = location.lng;

        string result = latitude + "," + longitude;
        UICommunication.instance.SetGeographicCordinatesOutput(result);

        string finalURL = URL_STATIC_MAPS + result + "&zoom=16&size=1280x800&maptype=roadmap&markers=color:red%7Clabel:S%7C" + result + KEY_STATIC_MAPS;
        StartCoroutine(WaitToGetStaticMap(finalURL));
    }

    private IEnumerator WaitToGetStaticMap(string URL)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(URL);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture2D myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            UICommunication.instance.SetStaticMapTexture(myTexture);
        }
    }

    public class Post
    {
        public int id;
        public string title;
    }

    public class Comment
    {
        public int id;
        public string body;
        public int postId;
    }

    public class Profile
    {
        public string name;
    }

    public class DemoData
    {
        public List<Post> posts;
        public List<Comment> comments;
        public Profile profile;
    }

    public class AddressComponent
    {
        public string long_name;
        public string short_name;
        public List<string> types; 
    }

    public class Location
    {
        public double lat;
        public double lng;
    }

    public class Northeast
    {
        public double lat;
        public double lng; 
    }

    public class Southwest
    {
        public double lat;
        public double lng;
    }

    public class Viewport
    {
        public Northeast northeast;
        public Southwest southwest;
    }

    public class Geometry
    {
        public Location location; 
        public string location_type;
        public Viewport viewport;
    }

    public class Result
    {
        public List<AddressComponent> address_components;
        public string formatted_address;
        public Geometry geometry;
        public string place_id;
        public List<string> types;
    }

    public class RootObject
    {
        public List<Result> results;
        public string status;
    }

}
