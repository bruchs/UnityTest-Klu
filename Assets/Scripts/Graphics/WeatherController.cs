using UnityEngine;
using UnityEngine.PostProcessing;

public class WeatherController : MonoBehaviour
{
    [System.Serializable]
    public struct Weather
    {
        public string description;
        public float fogDensity;
        public Color ambientLightColor;
        public Color fogColor;
        public PostProcessingProfile postProcessing;  
    }

    public Weather[] weathers;
    private Weather currentWeather;
    private int weatherIndex;

    private PostProcessingBehaviour cameraPostProcessing;

    private void Start()
    {
        cameraPostProcessing = Camera.main.GetComponent<PostProcessingBehaviour>();
        SetNextWeather();
    }

    public void SetNextWeather()
    {
        currentWeather = weathers[weatherIndex];

        RenderSettings.fogDensity = currentWeather.fogDensity;
        RenderSettings.sun.color = currentWeather.ambientLightColor;
        RenderSettings.fogColor = currentWeather.fogColor;

        cameraPostProcessing.profile = currentWeather.postProcessing;
        ++weatherIndex;

        UIGraphics.instance.SetWeatherDescription(currentWeather.description);
        if (weatherIndex >= weathers.Length)
        {
            weatherIndex = 0;
        }
    }
}
