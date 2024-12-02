using UnityEngine;

public class AlignCameraToDashboard : MonoBehaviour
{
    public Transform dashboard; // Assign the dashboard GameObject in the Inspector
    public float distance = 100f; // Distance between the camera and the dashboard

    void Start()
    {
        if (dashboard != null)
        {
            // Position the camera in front of the dashboard
            transform.position = dashboard.position - dashboard.forward * distance;

            // Make the camera look at the dashboard
            transform.LookAt(dashboard);
        }
    }
}
