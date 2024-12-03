### **Architecture Document for VitalEdge XR (vitaledge-xr)**

---

#### **1. Introduction**
This document provides the architectural design for the VitalEdge XR platform, outlining its core components, data flow, and system interactions. VitalEdge XR integrates immersive XR technology with personalized healthcare, enabling medical professionals and researchers to visualize and interact with complex datasets and biological models in 3D environments.

The architecture is modular and scalable to support multiple portals (DoctorPortal, DataPortal, SciencePortal, AdminPortal) and ensure seamless integration with the VitalEdge backend.

---

### **2. Architecture Overview**

VitalEdge XR employs a **client-server architecture** where Unity acts as the client and communicates with the **VitalEdge backend** for data retrieval and processing. The system is designed for flexibility and scalability, ensuring compatibility with both XR and non-XR devices.

#### **Core Components**
1. **Unity Client**:
   - Renders immersive environments and 3D models.
   - Provides user interfaces for interacting with patient data and biological simulations.
   - Implements data visualization, real-time interaction, and API communication.

2. **VitalEdge Backend**:
   - RESTful API server providing authentication, patient data, and analytics.
   - Manages secure data storage and processing.
   - Supports both mock and real data for development and production environments.

3. **XR Devices** (optional):
   - Meta Quest, HoloLens, and other OpenXR-compatible headsets for immersive experiences.
   - Desktop and mobile devices for non-XR testing and fallback functionality.

---

### **3. High-Level Architecture Diagram**

```plaintext
+----------------------------+
|        VitalEdge XR        |
|      (Unity Client)        |
+----------------------------+
    |                 |
    v                 v
+--------+        +-----------+
| XR/AR  |        |  Desktop  |
| Device |        |   Viewer  |
+--------+        +-----------+
       |
+-----------------------------------+
|       RESTful API Integration     |
| - Authenticate (POST /auth)       |
| - Get Patient Data (GET /patients)|
| - Fetch Analytics (future)        |
+-----------------------------------+
       |
+-----------------------------------+
|      VitalEdge Backend            |
| - Authentication                  |
| - Patient Management              |
| - Analytics Engine                |
+-----------------------------------+
```

---

### **4. Components and Modules**

#### **4.1 Unity Client**
The Unity client is the core application built with Unity 6.0, supporting XR and non-XR environments. It contains the following key modules:

1. **Portal Manager**:
   - Manages navigation between portals (DoctorPortal, DataPortal, SciencePortal, AdminPortal).
   - Handles scene transitions and user context.

2. **API Manager**:
   - Wrapper for RESTful API calls.
   - Implements JWT authentication and token management.
   - Provides reusable methods for fetching patient data, vitals, and analytics.

3. **Data Visualization Engine**:
   - Renders 3D graphs (e.g., scatter plots, heatmaps).
   - Provides real-time updates for dashboards and data-driven visualizations.

4. **Interaction Manager**:
   - Implements interaction logic for XR devices (e.g., hand gestures, controllers).
   - Fallback support for desktop inputs (mouse and keyboard).

5. **UI Framework**:
   - Handles XR-friendly dropdowns, text fields, and interactive elements.
   - Built with Unity's UI Toolkit and TextMeshPro for high-quality text rendering.

6. **Prefab Library**:
   - Reusable 3D models (e.g., cells, neurons, dashboards).
   - Includes configurable materials and shaders for enhanced visuals.

---

#### **4.2 VitalEdge Backend**
The backend is responsible for managing data and providing APIs for the Unity client. It consists of:
1. **Authentication Service**:
   - Provides JWT-based authentication.
   - Validates user credentials and manages token expiration.

2. **Patient Service**:
   - Retrieves patient data, including demographics, vitals, and medical history.
   - Serves real-time updates for vitals (e.g., heart rate, blood pressure).

3. **Analytics Service** (Future):
   - Processes genomic, proteomic, and other complex datasets.
   - Provides actionable insights for personalized medicine.

4. **Data Storage**:
   - Stores patient information, medical records, and analytical results securely.
   - Ensures compliance with HIPAA and other data protection regulations.

---

### **5. Data Flow**

#### **5.1 Authentication Flow**
1. **Unity Client** sends a POST request to `/authenticate` with username and password.
2. **Backend** validates the credentials and returns a JWT token.
3. **Unity Client** stores the token and uses it for subsequent API calls.

#### **5.2 Patient Data Retrieval**
1. **Unity Client** sends a GET request to `/api/patients` with the JWT token in the Authorization header.
2. **Backend** returns a list of patients as JSON.
3. **Unity Client** parses the JSON and populates the patient selector dropdown.

#### **5.3 Data Visualization**
1. **Unity Client** requests analytics or vitals data from the backend.
2. Data is processed and returned as structured JSON.
3. Unity renders the data as 3D graphs or dashboards.

---

### **6. Detailed Module Design**

#### **6.1 Portal Manager**
- **Responsibilities**:
  - Load specific portals based on user role and selection.
  - Ensure scene-specific controllers and assets are loaded efficiently.

#### **6.2 API Manager**
- **Responsibilities**:
  - Abstract API communication.
  - Handle errors and retries (e.g., token expiration).
- **Core Methods**:
  - `AuthenticateAsync()`: Performs authentication.
  - `GetPatientsAsync()`: Fetches the list of patients.
  - `GetVitalsAsync()`: Retrieves real-time vital signs for a specific patient.

#### **6.3 Data Visualization Engine**
- **Responsibilities**:
  - Render graphs and models dynamically based on backend data.
- **Key Classes**:
  - `ScatterPlotRenderer`: Renders 3D scatter plots.
  - `GeneExpressionHeatmapRenderer`: Creates heatmaps for genomic data.

---

### **7. Deployment Architecture**

#### **7.1 Non-XR Devices**
- **Platforms**: macOS, Windows.
- **Rendering**: Standard 3D environments using mouse and keyboard interaction.
- **Use Case**: Development and testing, non-XR accessibility.

#### **7.2 XR Devices**
- **Platforms**: Meta Quest, HoloLens.
- **Rendering**: Immersive XR environments with OpenXR integration.
- **Use Case**: Full-fledged XR deployment for healthcare professionals.

#### **7.3 Backend Hosting**
- **Environment**: Hosted on a secure server or cloud platform (e.g., AWS, Azure).
- **Endpoints**: Public RESTful APIs accessible over HTTPS.

---

### **8. Security**
- **Authentication**:
  - JWT tokens for secure communication.
- **Data Protection**:
  - Encrypt sensitive data during transmission.
  - Ensure compliance with HIPAA and other regulations.
- **Access Control**:
  - Implement role-based access control (RBAC).

---

### **9. Scalability**
- Modular design allows for:
  - Adding new portals (e.g., TrainingPortal, CollaborationPortal).
  - Supporting additional XR devices and platforms.
  - Scaling backend to handle large datasets and user bases.

---

### **10. Conclusion**
VitalEdge XR’s architecture is designed to be modular, secure, and scalable, supporting both immediate needs and future expansions. By combining Unity’s powerful rendering capabilities with a robust backend, the system lays the foundation for immersive and interactive personalized medicine.

---
