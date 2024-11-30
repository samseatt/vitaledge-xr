# VitalEdge XR

VitalEdge XR is an immersive healthcare application designed to enhance the visualization and interpretation of complex medical, genomic, and physiological data. Built with Unity, it leverages cutting-edge XR (eXtended Reality) technologies to provide interactive 3D environments tailored for healthcare professionals, including physicians, geneticists, and researchers.

This project integrates real-time patient metrics, bioinformatics data, and advanced analytics to create a dynamic, personalized healthcare visualization platform. The application uses Unity’s XR capabilities for VR/AR environments and connects seamlessly to a robust backend API for data aggregation and insights.

---

## **Project Vision**

VitalEdge XR aims to bridge the gap between raw healthcare data and actionable insights by providing:
1. **Immersive Data Visualization**: Explore patient-specific genomic and physiological data in 3D interactive environments.
2. **Intelligent Insights**: Integrate real-time analytics powered by AI/LLM to interpret and contextualize complex medical information.
3. **Customizable Workflows**: Support different healthcare domains through role-specific portals (e.g., MedPortal for doctors, SciencePortal for geneticists).
4. **Scalable Infrastructure**: Enable deployment on cloud platforms, with seamless delivery to VR headsets (Meta Quest) or AR devices (HoloLens).

---

## **Core Features**

### 1. **Role-Specific Portals**
- **MedPortal**:
  - Focused on clinical use cases.
  - Displays real-time patient metrics such as heart rate, oxygen levels, and medications.
  - Includes immersive environments for comparing normal vs. pathophysiological cellular states.
- **SciencePortal**:
  - Tailored for researchers and geneticists.
  - Visualizes genomic data, such as amino acid changes in proteins caused by SNPs.
  - Integrates interactive 3D models of proteins, cells, and molecular pathways.

### 2. **Dynamic 3D Visualizations**
- **Real-Time Data Display**:
  - Render real-time sensor data (e.g., heart rate, blood pressure) onto interactive dashboards.
- **Interactive Models**:
  - Explore transparent 3D cellular environments and manipulate objects (e.g., proteins, receptors) to observe molecular changes.
- **3D Graphs and Overlays**:
  - Visualize patient trends and predictions through 3D interactive charts and overlays.

### 3. **Advanced API Integration**
The application connects to a backend API infrastructure, enabling dynamic data retrieval and analysis:
- **Data Aggregator API**:
  - Fetch real-time data from sensors and patient monitoring devices.
- **Analytics API**:
  - Access LLM-generated insights, genomic annotations, and bioinformatics analyses.
  - Example outputs:
    - Suggested therapeutic interventions.
    - Genomic differences mapped to protein changes.
    - Speech synthesis of patient reports for accessibility.

### 4. **XR Interactions**
- Fully immersive VR environments (Meta Quest).
- AR-enabled visualizations for HoloLens or iPhones (via ARKit).
- Interaction mechanisms:
  - Gaze- and hand-based control.
  - Object manipulation, resizing, and dynamic context overlays.

---

## **Technical Architecture**

### **1. Unity XR Framework**
- **Template**: Universal 3D (Core) with OpenXR support.
- **Key Tools**:
  - XR Interaction Toolkit for VR/AR interactions.
  - Unity WebRequest for REST API communication.
  - Universal Render Pipeline (URP) for optimized rendering.

### **2. Backend API**
A facade API simplifies Unity’s interaction with complex data systems:
- **Endpoints**:
  1. `/api/data`: Aggregated real-time patient metrics.
  2. `/api/analytics`: Insights derived from LLMs and bioinformatics pipelines.
- **Data Formats**:
  - JSON for structured data exchange.
  - Secure HTTPS communication with token-based authentication.

### **3. Deployment**
- **Local**: Runs on Meta Quest for fully immersive VR or HoloLens for AR.
- **Cloud**: Deploy WebGL builds for browser-based access (e.g., for demonstrations).
- **Infrastructure**:
  - Backend API hosted on AWS.
  - Static WebGL content hosted on AWS S3 with a CDN.

---

## **Folder Structure**

```plaintext
vitaledge-xr/
├── Assets/
│   ├── Models/             # 3D models (e.g., cells, proteins)
│   ├── Scenes/             # Unity scenes (MedPortal, SciencePortal)
│   ├── Scripts/            # C# scripts
│   │   ├── API/            # REST API communication
│   │   ├── Controllers/    # Scene and object controllers
│   │   ├── Utilities/      # Reusable helpers (e.g., data parsing)
│   ├── Prefabs/            # Reusable game objects
│   ├── Textures/           # Visual materials and textures
│   ├── UI/                 # UI elements (e.g., dashboards, HUDs)
│   ├── XR/                 # XR interaction components
├── Documentation/          # Guides and usage instructions
├── ProjectSettings/        # Unity project settings
├── Packages/               # Unity package dependencies
├── REST-Endpoints/         # Mock API specifications
├── Builds/                 # Exported builds for WebGL/Meta Quest
└── README.md               # Project overview and instructions
```

---

## **Usage**

### **1. Clone the Repository**
```bash
git clone https://github.com/your-username/vitaledge-xr.git
cd vitaledge-xr
```

### **2. Open in Unity**
- Open Unity Hub and add the project folder.
- Ensure Unity is set to use the **Universal 3D (Core)** template.

### **3. Run the Application**
- Play Mode: Test portals on your desktop.
- Build and Deploy:
  - Meta Quest: Build for Android.
  - HoloLens/iPhone: Build for UWP/iOS.

---

## **Roadmap**
- [x] Set up XR interaction with placeholder scenes.
- [x] Integrate REST API for mock patient data.
- [ ] Add MedPortal and SciencePortal scenes.
- [ ] Implement real-time 3D graphs and overlays.
- [ ] Deploy cloud-hosted WebGL demo.

---

## **Contributing**
We welcome contributions! Please fork the repository, create a feature branch, and submit a pull request.

---

## **License**
This project is licensed under the MIT License.

---
