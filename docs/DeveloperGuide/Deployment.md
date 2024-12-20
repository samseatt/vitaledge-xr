### **Developer Guide: Deployment for VitalEdge XR**

---

#### **1. Purpose**
This document outlines the steps to package, build, and deploy the VitalEdge XR application for various platforms, including macOS, Windows, and XR devices. It ensures the application is properly configured, tested, and distributed to end users.

---

### **2. Pre-Deployment Checklist**

1. **Verify Unity Project Settings**:
   - Ensure the correct target platform is set in **File > Build Settings**.
   - Add all required scenes to the build (e.g., `DoctorPortal`, `DataPortal`, `SciencePortal`, etc.).
   - Configure **Player Settings** (e.g., application name, company name, version).

2. **Check API Configuration**:
   - Replace mock API endpoints with production-ready URLs, if applicable.
   - Ensure correct handling of authentication tokens (JWT) for live APIs.

3. **Test the Application**:
   - Test all scenes in **Play Mode** to verify functionality.
   - Validate API integrations using test credentials and endpoints.

4. **Prepare Assets**:
   - Optimize 3D models, textures, and materials to reduce build size.
   - Remove unnecessary files (e.g., `Examples & Extras` from TextMeshPro).

---

### **3. Build Configuration**

#### **3.1 General Settings**
1. Open **File > Build Settings** in Unity.
2. Choose the target platform (e.g., macOS, Windows, Android).
3. Add the necessary scenes to the **Scenes in Build** list by clicking **Add Open Scenes**.

#### **3.2 Player Settings**
1. Navigate to **Edit > Project Settings > Player**.
2. Update the following fields:
   - **Company Name**: `VitalEdge`
   - **Product Name**: `VitalEdge XR`
   - **Version**: `1.0.0` (or current version).
3. Configure the **Resolution and Presentation** settings:
   - Ensure the default screen width and height are appropriate for your target devices.
4. Set **XR Settings**:
   - Enable **OpenXR** for XR devices.
   - Configure interaction profiles (e.g., Meta Quest Touch Controller).

---

### **4. Deployment Targets**

#### **4.1 macOS and Windows**
1. **Build Process**:
   - Select the target platform (macOS or Windows) in **Build Settings**.
   - Click **Build** to generate an executable.
   - For macOS:
     - A `.app` bundle will be created.
   - For Windows:
     - A `.exe` file will be generated in the build folder.

2. **Post-Build Steps**:
   - Test the build on the target platform.
   - Compress the build folder (e.g., ZIP) for easy distribution.

3. **Distribution**:
   - Share the compressed file via cloud storage or internal distribution channels.
   - Optionally, use installers or deployment tools for formal releases.

---

#### **4.2 XR Devices (e.g., Meta Quest)**
1. **Build Process**:
   - Select **Android** in **Build Settings** (Meta Quest runs on Android).
   - Ensure the following in **Player Settings**:
     - Enable **XR Plugin Management** with **OpenXR**.
     - Set the minimum API level to match the device requirements.
   - Click **Build and Run** to deploy directly to the connected device.

2. **Post-Build Steps**:
   - Test the build on the XR device using hand controllers or other interaction mechanisms.
   - Optimize performance if necessary (e.g., reduce model complexity).

3. **Distribution**:
   - Use tools like **Oculus Developer Hub (ODH)** for Meta Quest to package and distribute the application.
   - For internal testing, sideload the `.apk` using ADB:
     ```bash
     adb install path_to_apk_file.apk
     ```

---

#### **4.3 Mobile Devices**
1. **Build Process**:
   - Select **Android** or **iOS** in **Build Settings**.
   - Configure platform-specific settings:
     - For iOS, set the provisioning profile and signing certificate.
     - For Android, set the keystore for signing the application.
   - Build and export the project.

2. **Post-Build Steps**:
   - For iOS:
     - Open the Xcode project generated by Unity.
     - Compile and deploy to a connected device.
   - For Android:
     - Sideload the `.apk` using ADB or upload it to the Google Play Console.

---

### **5. Testing the Build**

1. **Desktop Testing**:
   - Run the `.app` or `.exe` file on a macOS or Windows machine.
   - Verify all scenes load correctly and interactions are functional.

2. **XR Testing**:
   - Test on the target XR device (e.g., Meta Quest) to ensure:
     - Controller inputs are correctly mapped.
     - Performance meets expectations (no lag or dropped frames).

3. **API Testing**:
   - Use live API endpoints to validate data retrieval and visualization.
   - Monitor logs for any errors or exceptions.

4. **Error Logging**:
   - Enable error logging in Unity:
     - **Edit > Project Settings > Player > Other Settings > Logging**.
   - Capture logs for debugging purposes during testing.

---

### **6. Optimization**

1. **Reduce Build Size**:
   - Remove unused assets and scripts.
   - Compress textures and models.

2. **Improve Performance**:
   - Use Level of Detail (LOD) for 3D models.
   - Optimize physics calculations by simplifying colliders.
   - Enable GPU instancing for repeated objects.

3. **Streamline API Calls**:
   - Minimize the frequency of polling API endpoints.
   - Use asynchronous requests to prevent UI freezes.

---

### **7. Deployment and Updates**

1. **Version Control**:
   - Maintain a versioning system (e.g., `1.0.0`, `1.1.0`) to track releases.
   - Use GitHub or another repository for release management.

2. **User Distribution**:
   - For internal users:
     - Share build files directly or via a shared drive.
   - For external users:
     - Publish the application on a platform-specific store (e.g., Oculus Store, App Store).

3. **Updating Builds**:
   - Increment the version number in **Player Settings**.
   - Replace the old build with the new version in the distribution channel.

---

### **8. Troubleshooting Deployment Issues**

| **Issue**                               | **Possible Cause**                             | **Solution**                                    |
|-----------------------------------------|-----------------------------------------------|------------------------------------------------|
| Build fails for XR devices              | XR Plugin Management is misconfigured         | Verify that OpenXR is enabled in Player Settings. |
| Missing textures or pink materials      | Shader incompatibility or missing materials   | Reassign materials and use compatible shaders. |
| API calls fail in production            | Incorrect base URL or expired token           | Update the API URL and verify token handling.  |
| Performance lags on XR devices          | High model complexity or unoptimized rendering| Reduce model details and enable GPU instancing. |

---

### **9. Conclusion**
This deployment guide ensures that the VitalEdge XR application is properly configured and packaged for different platforms. By following these steps, developers can efficiently test, distribute, and maintain the application, paving the way for future updates and improvements.
