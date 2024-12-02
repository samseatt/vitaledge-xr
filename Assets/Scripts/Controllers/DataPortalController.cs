using System.Collections.Generic;
using UnityEngine;
using TMPro;
using API;

public class DataPortalController : MonoBehaviour
{
    public TMP_Dropdown graphTypeDropdown; // TMP Dropdown for graph type
    public TMP_Dropdown patientDropdown;   // TMP Dropdown for patient selection
    public ScatterPlotRenderer scatterPlotRenderer; // Reference to the scatter plot renderer
    public GeneExpressionHeatmapRenderer geneExpressionHeatmapRenderer; // Reference to the heatmap renderer

    private MockDataApi mockApi;

    private void Start()
    {
        // Initialize Mock API
        mockApi = new MockDataApi();

        // Populate dropdowns
        PopulateGraphTypeDropdown();
        PopulatePatientDropdown();
    }

    private void PopulateGraphTypeDropdown()
    {
        graphTypeDropdown.ClearOptions();
        graphTypeDropdown.AddOptions(new List<string> { "Scatter Plot", "Kaplan-Meier Curve", "3D Bar Chart", "3D Heat Map", "Flowmap Streamlines" });
    }

    private void PopulatePatientDropdown()
    {
        patientDropdown.ClearOptions();
        patientDropdown.AddOptions(new List<string> { "Patient A", "Patient B", "Patient C", "Patient D" });
    }

    public void OnSubmit()
    {
        Debug.Log("Submit button clicked!");
        string selectedGraphType = graphTypeDropdown.options[graphTypeDropdown.value].text;
        string selectedPatient = patientDropdown.options[patientDropdown.value].text;
        Debug.Log(selectedPatient);

        if (selectedGraphType == "Scatter Plot")
        {
            Debug.Log(selectedGraphType);
            var data = mockApi.GetScatterPlotData(selectedPatient);
            scatterPlotRenderer.RenderDataPoints(data);
            Debug.Log("RenderDataPoints called.");
        }
        else if (selectedGraphType == "3D Heat Map")
        {
            Debug.Log(selectedGraphType);
            var data = mockApi.GetGeneExpressionHeatmapData(selectedPatient);
            geneExpressionHeatmapRenderer.RenderHeatmap(data);
            Debug.Log("RenderHeatmap called.");
        }
        else
        {
            Debug.LogWarning("Graph type not implemented yet: " + selectedGraphType);
        }
    }
}
