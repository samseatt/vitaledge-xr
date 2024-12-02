using UnityEngine;

public class MockDashboardApi
{
    public struct PatientVitals
    {
        public int SystolicBP;
        public int DiastolicBP;
        public int HeartRate;
        public float OxygenSaturation;
        public bool HasAFib;
    }

    public PatientVitals GetPatientVitals()
    {
        return new PatientVitals
        {
            SystolicBP = 120,
            DiastolicBP = 80,
            HeartRate = 72,
            OxygenSaturation = 98.5f,
            HasAFib = false // Change to true to simulate A-fib
        };
    }
}
