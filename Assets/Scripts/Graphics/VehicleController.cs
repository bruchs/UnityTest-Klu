using UnityEngine;

public class VehicleController : MonoBehaviour
{
    public Transform vehicleTransform;
    public GameObject[] vehicleGameObjects;
    private GameObject currentVehicle;
    private int vehicleIndex;

    private void Start()
    {
        SetNextVehicle();
    }

    public void SetNextVehicle()
    {
        if(currentVehicle != null)
        {
            currentVehicle.SetActive(false);
        }

        currentVehicle = vehicleGameObjects[vehicleIndex];
        currentVehicle.transform.parent = vehicleTransform;
        currentVehicle.transform.position = vehicleTransform.transform.position;

        currentVehicle.SetActive(true);
        ++vehicleIndex;

        UIGraphics.instance.SetVehicleName(currentVehicle.name);

        if (vehicleIndex >= vehicleGameObjects.Length)
        {
            vehicleIndex = 0;
        }
    }
}
