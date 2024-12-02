using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PatientDashboardRenderer : MonoBehaviour
{
    public TMP_Text systolicBPText;
    public TMP_Text diastolicBPText;
    public TMP_Text heartRateText;
    public TMP_Text oxygenText;

    public GameObject afibIndicator; // Light indicator for A-fib
    public Image heartRateGauge;    // Circular gauge for heart rate
    public Image oxygenBar;         // Progress bar for oxygen saturation

    private MockDashboardApi mockApi;

    private void Start()
    {
        mockApi = new MockDashboardApi();
        StartCoroutine(UpdateDashboard());
    }

    private IEnumerator UpdateDashboard()
    {
        while (true)
        {
            var vitals = mockApi.GetPatientVitals();

            // Update numeric displays
            systolicBPText.text = $"Systolic: {vitals.SystolicBP} mmHg";
            diastolicBPText.text = $"Diastolic: {vitals.DiastolicBP} mmHg";
            heartRateText.text = $"Heart Rate: {vitals.HeartRate} bpm";
            oxygenText.text = $"SpO2: {vitals.OxygenSaturation}%";

            // Update heart rate gauge
            heartRateGauge.fillAmount = Mathf.InverseLerp(50, 150, vitals.HeartRate);

            // Update oxygen progress bar
            oxygenBar.fillAmount = vitals.OxygenSaturation / 100f;

            // Update A-fib indicator
            var lightRenderer = afibIndicator.GetComponent<Renderer>();
            lightRenderer.material.color = vitals.HasAFib ? Color.red : Color.green;

            // Wait before polling again (simulate real-time polling)
            yield return new WaitForSeconds(2f);
        }
    }
}
