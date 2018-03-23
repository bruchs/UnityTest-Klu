using UnityEngine;

public class GraphicsController : MonoBehaviour
{
    private WeatherController weatherController;
    private VehicleController vehicleController;
    private float desiredWidth;

    private void Start()
    {
        weatherController = GetComponent<WeatherController>();
        vehicleController = GetComponent<VehicleController>();
    }

    private void Update()
    {
        desiredWidth = Screen.width / 3;
        CheckForInput();
    }

    private void CheckForInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float mouseXPosition = Input.mousePosition.x;

            if (mouseXPosition > desiredWidth && mouseXPosition < 2 * desiredWidth)
            {
                weatherController.SetNextWeather();
            }
            else
            {
                vehicleController.SetNextVehicle();
            }
        }
    }
}
