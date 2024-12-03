using UnityEngine;
using System.Collections.Generic;

public class ScatterPlotRenderer : MonoBehaviour
{
    public GameObject pointPrefab; // Sphere prefab for data points
    public GameObject axisPrefab; // Cylinder or line prefab for axes
    public Vector3 plotSize = new Vector3(10, 10, 10); // Size of the plot

    public void RenderDataPoints(List<(float age, float bp, float cholesterol, float bmi, string gender)> data)
    {
        // Clear existing points
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Render new points
        foreach (var (age, bp, cholesterol, bmi, gender) in data)
        {
            Debug.Log(age);
            Vector3 position = new Vector3(
                Normalize(age, 20, 80, 0, plotSize.x), // Map age to X
                Normalize(bp, 100, 200, 0, plotSize.y), // Map blood pressure to Y
                Normalize(cholesterol, 150, 300, 0, plotSize.z) // Map cholesterol to Z
            );

            var point = Instantiate(pointPrefab, position, Quaternion.identity, transform);
            point.transform.localScale = Vector3.one * Normalize(bmi, 15, 40, 0.5f, 1.5f); // Scale by BMI
            point.GetComponent<Renderer>().material.color = gender == "Male" ? Color.blue : Color.magenta; // Color by gender
        }
    }

    private float Normalize(float value, float min, float max, float newMin, float newMax)
    {
        return (value - min) / (max - min) * (newMax - newMin) + newMin;
    }
}
