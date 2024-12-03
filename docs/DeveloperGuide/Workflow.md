### **Developer Guide: Workflow for VitalEdge XR**

---

#### **1. Purpose**
This document provides a structured workflow for developers working on **VitalEdge XR**. It outlines best practices for adding new features, creating prefabs, implementing APIs, and extending the project while maintaining consistency and scalability.

---

### **2. General Development Workflow**

1. **Understand Requirements**:
   - Review the requirements and design documents.
   - Identify the specific scene, API, or visualization being implemented.

2. **Branching Strategy**:
   - Follow Git best practices for branching:
     - Use the `main` branch for stable releases.
     - Create feature branches for new developments (e.g., `feature/scienceportal`).

3. **Testing in Play Mode**:
   - Frequently test in Unity’s **Play Mode** to ensure proper functionality and interactivity.

4. **Commit and Push**:
   - Commit changes incrementally with clear messages.
   - Push changes to remote repositories only after verifying local functionality.

---

### **3. Adding New Portals**

#### **Step 1: Create a New Scene**
1. Duplicate an existing portal scene (e.g., `DoctorPortal.unity`) from the `Assets/Scenes/` folder.
2. Rename the new scene (e.g., `NeuralPortal.unity`).
3. Open the scene and delete unnecessary objects.

#### **Step 2: Add Required Components**
1. Add a **Canvas** for UI elements.
2. Position the **Main Camera** or XR Rig to focus on the key content of the portal.
3. Import prefabs or create new ones for 3D objects and UI elements.

#### **Step 3: Implement Scene-Specific Controller**
1. Create a new controller script under `Assets/Scripts/Controllers/`.
   - For example, `NeuralPortalController.cs`.
2. Attach the script to an empty GameObject (e.g., `SceneManager`).
3. Implement logic for:
   - API calls to fetch data.
   - Interactions (e.g., dropdown selections, buttons).
   - Visualization updates (e.g., rendering neurons).

---

### **4. Creating Prefabs**

Prefabs are reusable GameObjects that save time and maintain consistency.

#### **Step 1: Design the Prefab**
1. Create a GameObject in the scene (e.g., a neuron or dashboard widget).
2. Add child objects as necessary (e.g., lights, materials, or text elements).

#### **Step 2: Configure the Prefab**
1. Set appropriate components (e.g., materials, colliders, scripts).
2. Test the GameObject in Play Mode to verify functionality.

#### **Step 3: Save as Prefab**
1. Drag the GameObject into the `Assets/Prefabs/` folder.
2. Use the prefab in other scenes by dragging it from the Prefabs folder into the scene.

---

### **5. Implementing New API Calls**

APIs provide dynamic data for Unity’s visualizations and interactions.

#### **Step 1: Define the Data Model**
1. Create a new C# class for the API response under `Assets/Scripts/API/Models/`.
   - For example, `Patient.cs` or `ScatterPlotData.cs`.

#### **Step 2: Create API Functions**
1. Add a new function in the API manager script (`VitalEdgeAPI.cs`):
   - For example, `GetScatterPlotData(string patientId)`.
2. Use Unity’s `UnityWebRequest` to fetch data from the backend.

```csharp
public async Task<ScatterPlotData> GetScatterPlotData(string patientId)
{
    string url = $"{BaseUrl}/api/analytics/scatterplot?patientId={patientId}";
    using (UnityWebRequest request = UnityWebRequest.Get(url))
    {
        request.SetRequestHeader("Authorization", $"Bearer {JwtToken}");
        await request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            return JsonUtility.FromJson<ScatterPlotData>(request.downloadHandler.text);
        }
        else
        {
            Debug.LogError($"Error: {request.error}");
            return null;
        }
    }
}
```

#### **Step 3: Integrate the API with the Scene**
1. Call the new API function from the scene controller (e.g., `DataPortalController.cs`).
2. Use the response to update visualizations.

---

### **6. Adding New UI Elements**

#### **Step 1: Add a UI Element**
1. Right-click on the **Canvas** in the Hierarchy and choose:
   - Dropdown: For selections (e.g., patient, graph type).
   - Button: For interactions (e.g., submit or refresh).
   - TextMeshPro: For high-quality text rendering.

#### **Step 2: Configure the Element**
1. Set properties such as size, position, and default text.
2. Link the element to its corresponding script:
   - For example, assign a Button’s **OnClick()** event to a function in the controller script.

---

### **7. Debugging and Testing**

#### **Step 1: Debugging REST API Calls**
1. Use logging (`Debug.Log`) to inspect API responses in Unity’s Console.
2. Test APIs independently using tools like Postman or Insomnia.

#### **Step 2: Validating Interactions**
1. Check button clicks, dropdown selections, and object manipulation in Play Mode.
2. Use Unity’s EventSystem to debug input-related issues.

#### **Step 3: Handling Exceptions**
- Implement error handling in API calls:
  ```csharp
  if (request.result != UnityWebRequest.Result.Success)
  {
      Debug.LogError($"API call failed: {request.error}");
  }
  ```

---

### **8. Deployment**

#### **Step 1: Build Settings**
1. Go to **File > Build Settings** in Unity.
2. Add all relevant scenes to the build list.
3. Choose the target platform (e.g., macOS, Windows, Android).

#### **Step 2: Configure Player Settings**
1. Go to **Edit > Project Settings > Player**.
2. Set application name, company name, and version.
3. Adjust XR settings for VR/AR builds:
   - Enable **OpenXR** under XR Plugin Management.

#### **Step 3: Test the Build**
1. Build and run the application on your local device.
2. Verify functionality in both XR and non-XR environments.

#### **Step 4: Distribute the Build**
1. For macOS or Windows:
   - Share the build folder (e.g., compress and upload).
2. For XR devices:
   - Deploy to the device using the appropriate platform tools (e.g., Oculus Developer Hub for Meta Quest).

---

### **9. Best Practices**

1. **Keep Code Modular**:
   - Separate data models, API calls, and scene logic into distinct scripts.
2. **Reuse Prefabs**:
   - Create prefabs for repeated UI elements and 3D models.
3. **Version Control**:
   - Commit changes frequently with descriptive messages.
4. **Testing**:
   - Regularly test interactions and data flow during development.

---
