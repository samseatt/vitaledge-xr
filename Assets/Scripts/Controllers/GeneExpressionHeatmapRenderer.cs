using UnityEngine;
using System.Collections.Generic;

public class GeneExpressionHeatmapRenderer : MonoBehaviour
{
    public GameObject cubePrefab; // Cube prefab for heatmap cells
    public Vector3 cellSize = new Vector3(1, 1, 1); // Size of each cube
    public Vector3 gridSpacing = new Vector3(1.2f, 1.2f, 1.2f); // Spacing between cubes
    public Vector3 plotSize = new Vector3(10, 10, 10); // Overall size of the heatmap

    public void RenderHeatmap(List<List<float>> data)
    {
        // Clear existing heatmap
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        int numGenes = data.Count; // Number of genes (rows)
        int numSamples = data[0].Count; // Number of patient samples (columns)

        // Render the heatmap as a grid of cubes
        for (int i = 0; i < numGenes; i++)
        {
            for (int j = 0; j < numSamples; j++)
            {
                // Calculate the position of the cube
                Vector3 position = new Vector3(
                    i * gridSpacing.x,
                    data[i][j] * cellSize.y, // Height represents expression level
                    j * gridSpacing.z
                );

                // Instantiate a cube
                var cube = Instantiate(cubePrefab, position, Quaternion.identity, transform);
                cube.transform.localScale = cellSize;

                // Set cube color based on expression level
                var renderer = cube.GetComponent<Renderer>();
                renderer.material.color = ExpressionLevelToColor(data[i][j]);
            }
        }
    }

    /// <summary>
    /// Converts a gene expression level to a color.
    /// </summary>
    private Color ExpressionLevelToColor(float expressionLevel)
    {
        // Map expression level to color gradient (low = blue, high = red)
        return Color.Lerp(Color.blue, Color.red, Mathf.InverseLerp(0, 10, expressionLevel));
    }
}
