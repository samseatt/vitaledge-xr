using UnityEngine;

public class SphereController : MonoBehaviour
{
    private Renderer sphereRenderer;

    void Start()
    {
        // Get the Renderer component for color manipulation
        sphereRenderer = GetComponent<Renderer>();
    }

    // Update the size of the sphere
    public void UpdateSize(float scaleFactor)
    {
        // Apply uniform scaling
        transform.localScale = Vector3.one * scaleFactor;
    }

    // Update the color of the sphere
    public void UpdateColor(Color newColor)
    {
        if (sphereRenderer != null)
        {
            sphereRenderer.material.color = newColor;
        }
    }
}
