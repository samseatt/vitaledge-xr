using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public SphereController sphereController;
    public MockApi mockApi;

    void Start()
    {
        // Fetch data from the mock API and update the sphere
        float size = mockApi.GetSizeFromApi();
        Color color = mockApi.GetColorFromApi();

        sphereController.UpdateSize(size);
        sphereController.UpdateColor(color);

        Debug.Log($"Updated Sphere - Size: {size}, Color: {color}");
    }

    void Update()
    {
        // Press 'R' to refresh sphere properties dynamically
        if (Input.GetKeyDown(KeyCode.R))
        {
            float size = mockApi.GetSizeFromApi();
            Color color = mockApi.GetColorFromApi();

            sphereController.UpdateSize(size);
            sphereController.UpdateColor(color);

            Debug.Log($"Refreshed Sphere - Size: {size}, Color: {color}");
        }
    }
}
