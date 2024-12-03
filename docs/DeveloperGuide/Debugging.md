### **Developer Guide: Debugging and Testing for VitalEdge XR**

---

#### **1. Purpose**
This document provides a systematic approach to debugging and testing **VitalEdge XR**. By following these guidelines, developers can efficiently identify and resolve issues related to Unity components, API integrations, and XR interactions.

---

### **2. Debugging Unity Components**

#### **2.1 Scene and GameObject Issues**

1. **Check Hierarchy and Structure**:
   - Ensure all required GameObjects are present in the scene.
   - Verify the parent-child relationships in the Hierarchy tab.

2. **Missing Components**:
   - If a GameObject is not functioning correctly, check its components in the Inspector.
   - Add missing components (e.g., scripts, colliders, renderers) as necessary.

3. **Visibility Issues**:
   - Verify the position, rotation, and scale of the GameObject.
   - Ensure the camera is correctly aligned with the objects of interest.

4. **Material or Texture Problems**:
   - Pink materials often indicate missing shaders or textures.
   - Assign the correct material in the Inspector.

---

#### **2.2 UI Issues**

1. **UI Elements Not Visible**:
   - Ensure the Canvas render mode is set appropriately (e.g., **Screen Space - Overlay** or **World Space**).
   - Check the layer settings and ensure UI elements are within the camera's view.

2. **Buttons or Dropdowns Not Responding**:
   - Ensure the EventSystem is present in the scene.
   - Check the **OnClick()** or similar event bindings in the Inspector.

3. **TextMeshPro Issues**:
   - Verify that TextMeshPro assets are installed and the required fonts are assigned.
   - If missing assets cause errors, reimport **TextMeshPro Essentials**.

---

### **3. Debugging API Calls**

#### **3.1 Validating Requests**

1. **Log API Requests and Responses**:
   - Use `Debug.Log()` to print API endpoints and request parameters.
   - Example:
     ```csharp
     Debug.Log($"Making API call to: {url}");
     ```

2. **Test with External Tools**:
   - Use Postman or Insomnia to test API endpoints independently.
   - Ensure the backend API is functional and accessible from the Unity development machine.

#### **3.2 Handling Errors**

1. **UnityWebRequest Errors**:
   - Log error messages from `UnityWebRequest` responses:
     ```csharp
     if (request.result != UnityWebRequest.Result.Success)
     {
         Debug.LogError($"API Error: {request.error}");
     }
     ```

2. **JWT Token Expiration**:
   - If `401 Unauthorized` errors occur, verify the token and implement token refresh logic.

3. **Malformed JSON**:
   - Validate the JSON response structure using tools like [JSONLint](https://jsonlint.com).
   - Ensure data models in Unity match the backend response schema.

#### **3.3 Mock API Testing**
- Use the Mock API to test endpoints without relying on the backend.
- Verify that mock data matches the expected structure of real API responses.

---

### **4. Debugging XR Features**

#### **4.1 Interaction Issues**

1. **Controller Inputs Not Detected**:
   - Ensure the XR Interaction Toolkit and OpenXR are properly configured.
   - Check that the correct controller profile is assigned (e.g., Meta Quest Touch).

2. **Hand Tracking or Raycast Issues**:
   - Verify that the **XR Ray Interactor** is enabled on the controller.
   - Check raycasting settings in the **Interaction Manager**.

#### **4.2 Performance Optimization**
1. **Lagging or Dropped Frames**:
   - Reduce the complexity of 3D models (use Level of Detail, LOD).
   - Limit the number of active GameObjects in the scene.

2. **Device-Specific Issues**:
   - Test on multiple XR devices to identify compatibility issues.
   - Use Unity’s **Device Simulator** for preliminary testing.

---

### **5. Common Errors and Resolutions**

#### **5.1 Missing Scripts**
- Error: `The referenced script on this Behaviour is missing!`
- Cause: A script was removed or renamed without updating the GameObject.
- Solution: Reassign the correct script in the Inspector.

#### **5.2 NullReferenceException**
- Error: `Object reference not set to an instance of an object.`
- Cause: A variable was not initialized or assigned.
- Solution:
  - Check that all required objects are assigned in the Inspector.
  - Add null checks in the code:
    ```csharp
    if (myObject == null)
    {
        Debug.LogError("myObject is not assigned!");
    }
    ```

#### **5.3 Pink Materials**
- Error: Objects appear pink in the scene.
- Cause: Missing or incompatible shaders.
- Solution: Assign a compatible shader or reimport materials.

#### **5.4 API Connection Error**
- Error: `Unable to connect to the server.`
- Cause: Incorrect API URL or server not running.
- Solution: Verify the URL and test the server endpoint with an external tool.

---

### **6. Testing Strategies**

#### **6.1 Unit Testing**
- Write unit tests for reusable methods, especially for:
  - Data model serialization/deserialization.
  - API helper functions (e.g., authentication, data fetching).

#### **6.2 Integration Testing**
- Test API calls integrated with scene controllers.
- Use mock data to simulate real API responses.

#### **6.3 Play Mode Testing**
- Regularly test scenes in Play Mode:
  - Interactions (e.g., dropdowns, buttons).
  - Visualizations (e.g., 3D graphs, dashboards).

#### **6.4 Device Testing**
- Deploy the application to target devices (e.g., Meta Quest) and verify:
  - Controller inputs and hand tracking.
  - Performance and rendering quality.

---

### **7. Debugging Tools**

#### **Unity Console**
- Use the Console window to view logs, warnings, and errors.
- Filter messages by type (e.g., errors, warnings).

#### **Debug.Log**:
- Insert `Debug.Log()` statements to inspect variable states and flow:
  ```csharp
  Debug.Log($"Current value: {myValue}");
  ```

#### **Unity Profiler**
- Analyze performance issues, such as high CPU/GPU usage.
- Access via **Window > Analysis > Profiler**.

#### **Breakpoints in Visual Studio**
- Use breakpoints to pause code execution and inspect variable values.
- Attach Visual Studio to Unity for live debugging:
  - In Visual Studio, go to **Debug > Attach Unity Debugger**.

---

### **8. Performance Optimization**

#### **8.1 Reduce Draw Calls**
- Combine static objects into a single mesh where possible.
- Use object pooling for frequently created/destroyed objects.

#### **8.2 Optimize Textures**
- Use compressed texture formats (e.g., PNG, JPEG).
- Limit the resolution of background textures and materials.

#### **8.3 Minimize Physics Calculations**
- Reduce the number of rigidbodies and colliders in the scene.
- Use simpler collider shapes (e.g., box or sphere).

---

### **9. Conclusion**
This debugging guide provides practical solutions to common issues encountered in VitalEdge XR development. By following these guidelines and leveraging Unity's debugging tools, developers can maintain high-quality, bug-free code while ensuring optimal performance and user experience.
