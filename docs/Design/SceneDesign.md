### **Scene Design Document for VitalEdge XR**

---

#### **1. Introduction**
The Scene Design document provides an overview of how the various scenes in **VitalEdge XR** are structured and designed to fulfill their intended purposes. Each scene serves as a modular portal within the XR environment, focusing on a specific use case such as patient vitals visualization, data exploration, or biological modeling.

The document details the layout, key GameObjects, UI elements, and interactions for each scene, ensuring consistency and usability across the application.

---

### **2. Scene Overview**

#### **Scenes in VitalEdge XR**
1. **DoctorPortal**
   - Purpose: Real-time vitals monitoring and patient-specific dashboards.
2. **DataPortal**
   - Purpose: 3D data visualization (scatter plots, heatmaps, etc.).
3. **SciencePortal**
   - Purpose: Exploration of biological models (e.g., neurons, DNA, receptors).
4. **AdminPortal**
   - Purpose: Patient management and authentication testing.
5. **NeuralPortal** (Future Expansion)
   - Purpose: Visualization of neural networks and their interactions.

---

### **3. Scene Layouts**

#### **3.1 DoctorPortal**
- **Purpose**: Displays real-time patient vitals and dashboards for doctors.
- **Key Elements**:
  - **Vitals Dashboard**:
    - Positioned near the user’s field of view.
    - Contains gauges and text elements for:
      - Heart rate.
      - Blood pressure (systolic/diastolic).
      - Oxygen saturation.
      - Atrial fibrillation warning (red light indicator).
  - **Patient Selection**:
    - Dropdown for selecting a patient.
    - Displays the selected patient's name and details at the top.
  - **Camera Positioning**:
    - Positioned to focus on the dashboard by default.
- **Interactions**:
  - Dropdown selection changes the displayed patient.
  - Gauges update based on real-time or mock data.

**GameObjects**:
```
DoctorPortal/
├── Canvas
│   ├── Dropdown (PatientDropdown)
│   ├── Text (Vitals Text: SystolicBP, HeartRate, etc.)
│   ├── Image (Gauge indicators for vitals)
├── Camera
├── EventSystem
```

---

#### **3.2 DataPortal**
- **Purpose**: Displays 3D graphs and visualizations for medical and genomic data.
- **Key Elements**:
  - **Graph Selection Menu**:
    - Dropdown or menu to choose between graph types (e.g., scatter plot, heatmap).
  - **Graph Renderer**:
    - Dynamically generates the selected graph using mock or real API data.
    - Positions the graph in front of the user.
  - **Patient Selector**:
    - Dropdown to select the patient whose data will be visualized.
- **Camera Positioning**:
  - Positioned to focus on the graph area.
- **Interactions**:
  - Dropdown to select graph type and patient.
  - Real-time updates of graph data based on the selected patient.

**GameObjects**:
```
DataPortal/
├── Canvas
│   ├── Dropdown (GraphTypeDropdown, PatientDropdown)
│   ├── Text (Graph Title)
├── GraphRenderer
│   ├── ScatterPlotRenderer
│   ├── HeatmapRenderer
├── Camera
├── EventSystem
```

---

#### **3.3 SciencePortal**
- **Purpose**: Provides an immersive environment to explore biological models such as neurons, DNA, and receptors.
- **Key Elements**:
  - **Biological Model Renderer**:
    - Dynamically generates and positions 3D models (e.g., neurons, DNA strands).
    - Allows interactive exploration, such as rotating and zooming.
  - **Scene Background**:
    - A neutral, immersive background (e.g., a skybox) for visual focus.
- **Camera Positioning**:
  - Positioned to focus on the biological models.
- **Interactions**:
  - Mouse or XR controllers for rotating, zooming, and exploring the models.
  - Buttons or menus to switch between different biological models.

**GameObjects**:
```
SciencePortal/
├── Canvas
│   ├── Buttons (Model Selector: Neurons, DNA, etc.)
│   ├── Text (Model Descriptions)
├── BiologicalModelRenderer
│   ├── NeuronRenderer
│   ├── DNARenderer
│   ├── ReceptorRenderer
├── Camera
├── EventSystem
```

---

#### **3.4 AdminPortal**
- **Purpose**: Allows administrators to manage patient profiles and authenticate into the VitalEdge backend.
- **Key Elements**:
  - **Authentication Section**:
    - Handles JWT-based authentication.
    - Displays login status and error messages.
  - **Patient List**:
    - Dropdown to select a patient.
    - Displays patient details (name, age, address).
  - **API Integration**:
    - Real API calls to fetch patient data.
- **Camera Positioning**:
  - Positioned to focus on the authentication and patient management UI.
- **Interactions**:
  - Dropdown to select a patient.
  - Button to trigger API authentication.

**GameObjects**:
```
AdminPortal/
├── Canvas
│   ├── Dropdown (PatientDropdown)
│   ├── Text (Patient Details)
│   ├── Button (AuthenticateButton)
├── APIManager
├── Camera
├── EventSystem
```

---

#### **3.5 NeuralPortal (Future)**
- **Purpose**: Visualizes neural networks based on user-provided data.
- **Key Elements**:
  - **Neuron Renderer**:
    - Renders neurons with dendrites, axons, and synapses.
    - Connects neurons based on API-provided data.
  - **Camera Movement**:
    - Allows zooming and panning through the neural network.
- **Camera Positioning**:
  - Positioned to show the entire network initially.
- **Interactions**:
  - Mouse or XR controllers for exploration.
  - Dropdown or menu to filter specific neurons or pathways.

**GameObjects**:
```
NeuralPortal/
├── NeuralNetworkRenderer
│   ├── NeuronPrefab
│   ├── SynapsePrefab
├── Canvas
│   ├── Dropdown (Filter Options)
│   ├── Buttons (Reset View)
├── Camera
├── EventSystem
```

---

### **4. General Design Principles**

#### **4.1 Consistent UI/UX**
- Use the same font, color schemes, and interaction patterns across all portals for a seamless experience.
- Ensure all UI elements are XR-friendly (e.g., appropriately sized, easy to interact with).

#### **4.2 Modularity**
- Design reusable prefabs for shared components, such as:
  - Dropdown menus.
  - Graph renderers.
  - Biological models.

#### **4.3 Accessibility**
- Ensure all text is readable in XR environments (e.g., use TextMeshPro for high-quality rendering).
- Provide color-blind-friendly visualizations.

#### **4.4 Optimized Performance**
- Use Level of Detail (LOD) models for complex biological structures to maintain performance.
- Batch rendering of repetitive objects (e.g., neurons, synapses).

---

### **5. Interactions**

#### **Input Methods**
- **Mouse and Keyboard**:
  - Default input for desktop testing and non-XR usage.
- **XR Controllers**:
  - Support for OpenXR-compatible devices for selecting, rotating, and zooming.
- **Gesture Control** (Future):
  - Hand tracking for AR/VR devices like HoloLens or Meta Quest.

#### **Dynamic Data Updates**
- Portals like DoctorPortal and DataPortal will periodically poll APIs for real-time updates.

---

### **6. Scene Transitions**
- Transitions between scenes will be managed by the **Portal Manager** using Unity’s Scene Management system.
- Example:
  - When a user selects the "DataPortal" button in the main menu, the `PortalManager` will load the corresponding scene asynchronously.

---

### **7. Conclusion**
This Scene Design Document outlines the structure and components of each portal within VitalEdge XR, ensuring a consistent and immersive user experience. The modular design supports flexibility and scalability, enabling future expansions like additional portals and XR interactions.
