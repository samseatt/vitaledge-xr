### **Developer Reference (Cookbook): Setup Instructions for VitalEdge XR**

---

#### **1. Purpose**
This document provides a step-by-step guide for setting up the VitalEdge XR project, including installation of required tools, configuring Unity, and initializing the project structure. Follow these instructions to ensure the development environment is correctly configured for building and extending the XR application.

---

### **2. Prerequisites**

1. **Hardware**:
   - A macOS or Windows machine with at least:
     - 8 GB RAM (16 GB recommended).
     - GPU with OpenGL 3.3+ or equivalent support.
     - 10 GB free disk space.

2. **Software**:
   - **Unity Hub**: Version 3.10.0 or later.
   - **Unity Editor**: Version 6.0 or later.
   - **Visual Studio**: Community Edition with Unity workload installed.
   - **Git**: Installed and configured for version control.
   - A REST API testing tool (e.g., Postman or Insomnia).

---

### **3. Project Initialization**

#### **Step 1: Clone the Repository**
1. Open your terminal or Git client.
2. Clone the VitalEdge XR repository:
   ```bash
   git clone https://github.com/your-organization/vitaledge-xr.git
   cd vitaledge-xr
   ```

#### **Step 2: Open the Project in Unity Hub**
1. Launch **Unity Hub**.
2. Click **Open** and navigate to the `vitaledge-xr` folder.
3. Select the folder and open the project in Unity Editor (ensure Unity 6.0 or later is installed).

---

### **4. Install Required Packages**

#### **Step 1: Open the Package Manager**
1. In Unity, go to **Window > Package Manager**.
2. Verify that the following packages are installed:
   - **TextMeshPro**
   - **XR Plugin Management**
   - **OpenXR** (add it under XR Plugin Management if missing).

#### **Step 2: Configure XR Plugin Management**
1. Go to **Edit > Project Settings > XR Plugin Management**.
2. Enable **OpenXR** for your target platform (e.g., Mac or Windows).
3. Configure the OpenXR settings:
   - Add interaction profiles, such as **Meta Quest Touch Controller** or **Khronos Simple Controller**.

---

### **5. Install Project Dependencies**

#### **Step 1: Setup TextMeshPro**
1. If prompted by Unity, import **TextMeshPro Essentials**.
2. Verify that **TextMeshPro** assets are installed under `Assets/TextMesh Pro/`.

#### **Step 2: Install Other Plugins (Optional)**
- For advanced visuals:
  - Add **Cinemachine** for camera management.
  - Add **ProBuilder** for quick 3D modeling (via Package Manager).

---

### **6. Project Structure**

The project follows a modular structure:

```
vitaledge-xr/
├── Assets/
│   ├── Scenes/                # Unity scenes for each portal
│   ├── Scripts/               # All C# scripts
│   │   ├── API/               # Mock and real API classes
│   │   ├── Controllers/       # Scene-specific controllers
│   │   ├── Utilities/         # Helper classes and utilities
│   ├── Prefabs/               # Prefab objects (e.g., neurons, graphs)
│   ├── Materials/             # Materials for 3D models and UI elements
│   ├── Textures/              # Texture assets (e.g., backgrounds, UI)
│   └── Fonts/                 # Fonts for TextMeshPro
├── Packages/                  # Unity package dependencies
├── ProjectSettings/           # Unity project settings
└── README.md                  # Project overview
```

---

### **7. Configuring Unity Scenes**

#### **Step 1: Load an Existing Scene**
1. Navigate to the `Assets/Scenes/` folder in the Unity Project tab.
2. Double-click on a scene (e.g., `DoctorPortal.unity`) to open it.

#### **Step 2: Configure Canvas and Camera**
1. Ensure the **Canvas** is set to `Screen Space - Overlay` or `World Space` (depending on use case).
2. Position the **Main Camera** to focus on the primary UI or 3D objects.

#### **Step 3: Verify Prefabs**
1. Check that prefabs (e.g., neurons, graphs, dashboards) are correctly linked in the scene hierarchy.
2. If a prefab is missing, re-add it from the `Assets/Prefabs/` folder.

---

### **8. Git Setup**

#### **Step 1: Initialize Git**
If Git is not already initialized, run:
```bash
git init
```

#### **Step 2: Use the .gitignore File**
Ensure the `.gitignore` file excludes unnecessary files such as:
- `Library/`
- `Temp/`
- `Logs/`
- `Build/`

#### **Step 3: Commit Your Work**
```bash
git add .
git commit -m "Initial setup of VitalEdge XR"
```

---

### **9. Next Steps**
Once the setup is complete, proceed with the following:
1. **Add New Portals**: Start creating new Unity scenes (e.g., AdminPortal).
2. **Implement Mock APIs**: Set up mock API responses for testing.
3. **Build and Test**: Use Unity Play Mode to test functionality.
