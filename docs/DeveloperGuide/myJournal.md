### **VitalEdge XR Developer's Journal**

---

#### **Introduction**
This journal captures the experiences, lessons, and problem-solving strategies employed during the initial development of **VitalEdge XR**. It documents specific challenges encountered and solutions applied, serving as a practical reference for developers working on similar Unity and C# projects.

---

### **Getting Started**

1. **Setting Up the Development Environment**:
   - **Challenge**: Deciding on the correct Unity version and packages to install.
   - **Solution**: Installed Unity Hub 3.10.0 and Unity 6.0. Added necessary packages such as **TextMeshPro**, **XR Plugin Management**, and **OpenXR**. Ensured compatibility with macOS for development.

2. **Initializing the Project**:
   - Created a clear folder structure:
     - `Assets/Scenes` for Unity scenes.
     - `Assets/Scripts` with subfolders for `API`, `Controllers`, and `Utilities`.
     - `Assets/Prefabs` for reusable 3D objects.
     - `Assets/Materials` for custom shaders and textures.
   - Connected the project to GitHub for version control.

---

### **Scene Development**

#### **DoctorPortal: Vitals Dashboard**
1. **Adding a Dashboard**:
   - **Challenge**: Properly positioning the dashboard elements in the camera’s view.
   - **Solution**: Used `Canvas` in **Screen Space - Overlay** mode and scaled down UI elements to fit within the viewport.

2. **Making the Dashboard Interactive**:
   - Used TextMeshPro for high-quality text rendering.
   - Added dropdowns and buttons for patient selection and data updates.
   - Ensured the **EventSystem** was present to handle interactions.

3. **Data Binding**:
   - **Challenge**: Displaying real-time vitals from mock API.
   - **Solution**: Wrote a `VitalsDashboardController` script that fetched mock data and updated UI elements via `OnValueChanged` and `OnClick()` handlers.

---

#### **DataPortal: 3D Graphs**
1. **Creating a Scatter Plot**:
   - **Challenge**: Dynamically rendering 3D data points in Unity.
   - **Solution**: Created a `ScatterPlotRenderer` script to instantiate sphere prefabs for each data point. Adjusted scaling and positions based on the data model.

2. **Switching Between Graph Types**:
   - Implemented a dropdown menu for graph type selection.
   - Designed reusable graph-rendering classes (`ScatterPlotRenderer`, `HeatmapRenderer`) for flexibility.

3. **Debugging API Data**:
   - **Challenge**: JSON responses weren’t deserializing correctly.
   - **Solution**: Made data model classes `[Serializable]` and validated JSON structures using [JSONLint](https://jsonlint.com).

---

#### **SciencePortal: Biological Models**
1. **Rendering Neurons**:
   - Created a `NeuronPrefab` with cylindrical dendrites, axons, and synapses.
   - Wrote a `NeuralNetworkRenderer` script to calculate and position neuron connections dynamically.

2. **Improving Visual Appeal**:
   - Added transparency and smooth lighting using Unity materials.
   - Used Unity’s built-in **Skybox** for an immersive background.

3. **Interactive Exploration**:
   - Enabled rotation and zoom using mouse and keyboard inputs.
   - Planned to extend this functionality for XR controllers.

---

#### **AdminPortal: Authentication and Patient Management**
1. **Implementing Authentication**:
   - **Challenge**: Unity's `JsonUtility.ToJson()` was returning empty JSON for the login payload.
   - **Solution**: Ensured the `Credentials` class was `[Serializable]` and had public fields.

2. **Fetching Patients**:
   - **Challenge**: JSON response for patients was failing deserialization due to array format.
   - **Solution**: Wrapped the array response in a container object or parsed it manually.

3. **Dropdown Interaction**:
   - **Challenge**: Patient dropdown wasn’t displaying options.
   - **Solution**: Adjusted the dropdown's positioning and render mode. Ensured data-binding was functional.

---

### **Problem-Solving Strategies**

1. **Debugging Missing or Misaligned Objects**:
   - Used Unity’s **Inspector** to verify object properties.
   - Ensured the camera was correctly positioned to view all scene elements.
   - Applied consistent scaling for 3D objects and UI components.

2. **Fixing Pink Materials**:
   - Identified missing or incompatible shaders.
   - Assigned Unity’s Standard shader or reimported missing textures.

3. **Testing API Integration**:
   - Logged all API calls and responses using `Debug.Log()`.
   - Tested endpoints independently with Postman to confirm backend functionality.

4. **Event Handling**:
   - Used Unity’s **EventSystem** to track interactions.
   - Double-checked `OnClick()` and dropdown event bindings in the Inspector.

5. **Scaling UI for Different Devices**:
   - Standardized element placement within the `Canvas`.
   - Used Unity’s **Device Simulator** to test different screen sizes and aspect ratios.

---

### **Recurring Challenges**

1. **Positioning and Scaling**:
   - **Issue**: 3D objects or UI elements often appeared misaligned or out of view.
   - **Resolution**: Experimented with different placement strategies, such as relative to the origin (0, 0, 0) or based on camera positioning.

2. **Material Transparency**:
   - **Issue**: Materials didn’t render transparency as expected.
   - **Resolution**: Used **Standard Shader** with transparency settings and adjusted the alpha channel in the color property.

3. **Handling Null References**:
   - **Issue**: Frequent `NullReferenceException` errors when objects weren’t assigned.
   - **Resolution**: Added checks for null values and ensured objects were properly assigned in the Inspector.

4. **JSON Parsing**:
   - **Issue**: Misaligned data models caused deserialization errors.
   - **Resolution**: Serialized all data model classes and matched field names to JSON keys exactly.

---

### **Lessons Learned**

1. **Consistency in Naming and Structure**:
   - Organizing scripts, prefabs, and materials into separate folders saved significant time during development.

2. **Iterative Development**:
   - Testing functionality incrementally in **Play Mode** helped catch errors early.

3. **Debugging API Calls**:
   - Logging API responses at every step prevented time-consuming investigations.

4. **Importance of Prefabs**:
   - Creating and reusing prefabs streamlined scene building and ensured consistency.

5. **UI Positioning**:
   - Keeping UI elements under the `Canvas` hierarchy and using relative placement simplified scaling for different devices.

---

### **Future Considerations**

1. **Improved Visualization**:
   - Add animations and more realistic biological models.
   - Experiment with custom shaders for advanced effects.

2. **Scalability**:
   - Modularize code further to handle more complex scenes and larger datasets.

3. **Enhanced XR Support**:
   - Test extensively on XR devices for interaction fidelity.
   - Add gesture controls for AR environments.

4. **Collaborative Features**:
   - Explore multi-user interactions for shared XR environments.

---

### **Conclusion**
This journal reflects the practical challenges and solutions encountered during the development of VitalEdge XR. By documenting these experiences, it serves as a valuable reference for future development and highlights the importance of an iterative, structured approach to problem-solving.