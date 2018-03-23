using UnityEngine;
using UnityEngine.UI;

public class UIGraphics : MonoBehaviour
{
    public static UIGraphics instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<UIGraphics>();

            return _instance;
        }
    }

    private static UIGraphics _instance;

    public Text weatherDescription;
    public Text vehicleName;

    public void SetWeatherDescription(string newWeatherDescription)
    {
        weatherDescription.text = newWeatherDescription;
    }

    public void SetVehicleName(string newVehicleName)
    {
        vehicleName.text = newVehicleName;
    }
}
