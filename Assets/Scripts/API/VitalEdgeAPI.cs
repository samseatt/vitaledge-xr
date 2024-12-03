using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;

public class VitalEdgeAPI : MonoBehaviour
{
    private const string BASE_URL = "http://localhost:8080";
    private const string AUTH_ENDPOINT = "/authenticate";
    private const string PATIENTS_ENDPOINT = "/api/patients";
    private const string TOKEN_KEY = "jwt_token"; // Key to store the token in PlayerPrefs

    /// <summary>
    /// Get username for authentication.
    /// </summary>
    private string GetUsername()
    {
        return "admin"; // Hardcoded for now
    }

    /// <summary>
    /// Get password for authentication.
    /// </summary>
    private string GetPassword()
    {
        return "password"; // Hardcoded for now
    }

    /// <summary>
    /// Perform authentication and store the JWT token.
    /// </summary>
    public async Task<bool> AuthenticateAsync()
    {
        string url = BASE_URL + AUTH_ENDPOINT;
        //var credentials = new
        //{
        //    username = GetUsername(),
        //    password = GetPassword()
        //};

        var credentials = new Credentials(GetUsername(), GetPassword());
        string jsonData = JsonUtility.ToJson(credentials);


        //string jsonData = JsonUtility.ToJson(credentials);
        Debug.Log("Got username and password");
        Debug.Log(credentials.username);
        Debug.Log(credentials.password);
        Debug.Log(jsonData);
        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            await SendWebRequestAsync(request);

            if (request.result == UnityWebRequest.Result.Success)
            {
                string token = request.downloadHandler.text;
                PlayerPrefs.SetString(TOKEN_KEY, token);
                Debug.Log("Authentication successful. Token stored.");
                return true;
            }
            else
            {
                Debug.LogError("Authentication failed: " + request.error);
                return false;
            }
        }
    }

    /// <summary>
    /// Get a list of patients from the backend.
    /// </summary>
    public async Task<List<Patient>> GetPatientsAsync()
    {
        string url = BASE_URL + PATIENTS_ENDPOINT;
        string token = PlayerPrefs.GetString(TOKEN_KEY, null);

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            request.SetRequestHeader("Authorization", "Bearer " + token);

            Debug.Log("Sending request to backend.");
            await SendWebRequestAsync(request);

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Request made to backend.");
                string jsonData = request.downloadHandler.text;
                Debug.Log(jsonData);
                string wrappedJson = "{\"patients\":" + jsonData + "}";
                Debug.Log(wrappedJson);
                List<Patient> patients = JsonUtility.FromJson<PatientList>(wrappedJson).patients;
                return patients;
            }
            else
            {
                Debug.LogError("Failed to retrieve patients: " + request.error);
                return null;
            }
        }
    }

    /// <summary>
    /// Helper method to await UnityWebRequest.
    /// </summary>
    private async Task SendWebRequestAsync(UnityWebRequest request)
    {
        var operation = request.SendWebRequest();
        while (!operation.isDone)
        {
            await Task.Yield();
        }
    }
}

[System.Serializable]
public class Patient
{
    public string id;
    public string name;
    public int age;
    public string address;
}

[System.Serializable]
public class PatientList
{
    public List<Patient> patients;
}
