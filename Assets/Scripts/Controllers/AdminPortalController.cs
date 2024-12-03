using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AdminPortalController : MonoBehaviour
{
    public TMP_Dropdown patientDropdown; // Assign in Inspector
    public TMP_Text patientDetailsText; // Assign in Inspector
    private VitalEdgeAPI vitalEdgeAPI;

    private void Start()
    {
        vitalEdgeAPI = GetComponent<VitalEdgeAPI>();
        InitializePortal();
    }

    private async void InitializePortal()
    {
        bool isAuthenticated = await vitalEdgeAPI.AuthenticateAsync();
         if (isAuthenticated)
        {
            Debug.Log("Authenticated");
            List<Patient> patients = await vitalEdgeAPI.GetPatientsAsync();
            Debug.Log("Read patients");
            if (patients != null)
            {
                PopulatePatientDropdown(patients);
            }
        }
        else
        {
            Debug.LogError("Failed to authenticate. Cannot load AdminPortal.");
        }
    }

    private void PopulatePatientDropdown(List<Patient> patients)
    {
        patientDropdown.ClearOptions();
        List<string> patientNames = new List<string>();
        Debug.Log("Adding patient names to the dropdown options ...");
        foreach (var patient in patients)
        {
            Debug.Log(patient.name);
            patientNames.Add(patient.name);
        }
        patientDropdown.AddOptions(patientNames);

        // Set default patient and display details
        patientDropdown.onValueChanged.AddListener(delegate { DisplayPatientDetails(patients); });
        DisplayPatientDetails(patients); // Show first patient details initially
    }

    private void DisplayPatientDetails(List<Patient> patients)
    {
        int index = patientDropdown.value;
        Patient selectedPatient = patients[index];

        patientDetailsText.text = $"Name: {selectedPatient.name}\n" +
                                  $"Age: {selectedPatient.age}\n" +
                                  $"Address: {selectedPatient.address}";
    }
}
