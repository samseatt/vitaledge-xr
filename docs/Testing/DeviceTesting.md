### **Device Testing Document for VitalEdge XR**

---

#### **1. Purpose**
This document provides guidelines for testing **VitalEdge XR** on physical and simulated devices, including XR headsets, desktops, and mobile platforms. Device testing ensures compatibility, performance, and user experience across the target hardware environments.

---

### **2. Device Testing Objectives**

1. Validate the performance of the application on target devices (e.g., Meta Quest, macOS, Windows).
2. Ensure proper functionality of XR interactions (e.g., hand tracking, controller inputs).
3. Verify visual fidelity, including rendering quality and responsiveness.
4. Identify and address device-specific issues or limitations.

---

### **3. Target Devices**

#### **3.1 XR Devices**
- **Meta Quest (Standalone)**:
  - Tests hand/controller interactions, 3D rendering, and frame rates.
- **HoloLens (Optional)**:
  - Augmented reality overlay and head tracking (future).
- **Other OpenXR-compatible devices**:
  - Generic controller compatibility.

#### **3.2 Desktop Platforms**
- **macOS**:
  - Testing on Unity builds for macOS.
- **Windows**:
  - Focus on broader XR hardware compatibility and rendering.

#### **3.3 Mobile Devices**
- **Android** (Meta Quest runs on Android):
  - Compatibility for building `.apk` packages.
- **iOS**:
  - Future-proofing for ARKit support (optional).

---

### **4. Test Scenarios**

#### **4.1 XR-Specific Scenarios**
1. **Controller Interactions**:
   - Verify that users can:
     - Select dropdowns and buttons using the controller.
     - Manipulate 3D objects (e.g., rotate, zoom).

2. **Hand Tracking**:
   - Validate gestures for object manipulation and menu navigation.
   - Test precision in XR menus and dashboards.

3. **Rendering**:
   - Ensure models (neurons, scatter plots, etc.) are rendered at full fidelity.
   - Test transparency and shader effects.

4. **Performance**:
   - Confirm that the application runs at 60 FPS or higher.

#### **4.2 Desktop Scenarios**
1. **Mouse/Keyboard Interactions**:
   - Test all XR features adapted for desktop input devices.
   - Verify keyboard navigation for menus and dropdowns.

2. **Rendering**:
   - Ensure that visualizations scale properly to varying screen resolutions.

3. **Performance**:
   - Test for CPU/GPU load and memory usage on different hardware setups.

#### **4.3 Mobile Scenarios**
1. **Touch Interactions**:
   - Validate responsiveness of dropdowns and buttons on touchscreens.
   - Ensure compatibility with native gestures like pinch-to-zoom.

2. **Rendering**:
   - Test heatmaps, dashboards, and biological models for scalability to smaller screens.

---

### **5. Test Setup**

#### **5.1 XR Device Setup**
1. Connect the XR device to the development machine.
2. Enable Developer Mode:
   - For Meta Quest:
     - Use **Oculus Developer Hub (ODH)** to enable developer mode and sideload builds.
3. Deploy the application:
   - Build the project in Unity with **Android (OpenXR)** settings.
   - Use ADB commands to install the `.apk`:
     ```bash
     adb install -r path_to_apk_file.apk
     ```

#### **5.2 Desktop Setup**
1. Select the appropriate target platform in Unity Build Settings (macOS or Windows).
2. Build and run the standalone application on the desktop.

#### **5.3 Mobile Device Setup**
1. For Android:
   - Connect the device via USB and deploy `.apk` using ADB or Unity.
2. For iOS:
   - Export the Unity project to Xcode and deploy to a connected iOS device.

---

### **6. Testing Tools**

1. **Unity Device Simulator**:
   - Simulate mobile screen sizes and resolutions.
   - Use for preliminary testing of touch and mouse interactions.

2. **Meta Quest Developer Hub (ODH)**:
   - Monitor frame rates, CPU/GPU performance, and logs for Meta Quest devices.
   - Sideload `.apk` files for quick deployment.

3. **Profiler Tools**:
   - **Unity Profiler**: Analyze performance bottlenecks in the XR application.
   - **GPU Profiler**: Test rendering load on specific devices.

4. **Visual Debugging**:
   - Use Unity's **Scene View** to visualize controller inputs and raycasting.

---

### **7. Test Cases**

#### **7.1 XR Device Test Cases**
| **Test ID** | **Test Scenario**               | **Expected Outcome**                          |
|-------------|---------------------------------|-----------------------------------------------|
| XR001       | Select menu items via controllers| Accurate and responsive selections.           |
| XR002       | Rotate and zoom 3D objects      | Smooth and intuitive interactions.            |
| XR003       | Measure frame rates             | Consistent 60 FPS or higher.                  |
| XR004       | Gaze-based selection            | Correct selection and feedback.               |

---

#### **7.2 Desktop Test Cases**
| **Test ID** | **Test Scenario**                | **Expected Outcome**                          |
|-------------|----------------------------------|-----------------------------------------------|
| DT001       | Mouse-based dropdown navigation | Seamless interaction with dropdowns.          |
| DT002       | Dashboard rendering             | Proper scaling and alignment of all UI widgets.|

---

#### **7.3 Mobile Test Cases**
| **Test ID** | **Test Scenario**                | **Expected Outcome**                          |
|-------------|----------------------------------|-----------------------------------------------|
| MB001       | Touch gestures for navigation   | Smooth scrolling, selection, and zooming.     |
| MB002       | Rendering on small screens      | Properly scaled heatmaps and graphs.          |

---

### **8. Debugging Device Issues**

#### **8.1 Common Issues and Solutions**
| **Issue**                           | **Cause**                                   | **Solution**                                 |
|-------------------------------------|---------------------------------------------|---------------------------------------------|
| Frame rate drops                    | High model complexity or excessive draw calls| Simplify models; reduce draw calls with LOD.|
| Controllers not recognized          | Missing or misconfigured input profiles     | Add and configure profiles in OpenXR.       |
| UI elements unresponsive            | EventSystem missing or incorrectly set      | Verify EventSystem is present in the scene. |

#### **8.2 Error Logging**
- Enable error logging in Unity settings:
  - **Edit > Project Settings > Player > Other Settings > Logging**.
- Retrieve logs from XR devices using ODH or ADB:
  ```bash
  adb logcat
  ```

---

### **9. Performance Metrics**

#### **9.1 Target Metrics**
| **Metric**              | **XR Devices** | **Desktop** | **Mobile** |
|--------------------------|----------------|-------------|------------|
| Frame Rate (FPS)         | ≥ 60          | ≥ 60        | ≥ 30       |
| Memory Usage             | < 1.5 GB      | < 1 GB      | < 512 MB   |
| Input Latency            | < 20 ms       | < 20 ms     | < 30 ms    |

#### **9.2 Tools for Measurement**
- Use **Unity Profiler** for frame rates and memory usage.
- ODH for GPU/CPU performance on Meta Quest.

---

### **10. Best Practices**

1. **Optimize for Target Devices**:
   - Test frequently on physical devices to identify performance bottlenecks early.

2. **Keep Builds Modular**:
   - Ensure scenes and assets are easily removable or replaceable for different deployment targets.

3. **Leverage Mock APIs for Testing**:
   - Use mock APIs to simulate backend responses when testing locally.

4. **Test Across Platforms**:
   - Verify functionality and performance on all target platforms (XR, desktop, mobile).

---

### **11. Conclusion**
Device testing is a critical phase in the development of VitalEdge XR. By following this document, developers can ensure compatibility, performance, and usability across the diverse range of supported devices. Regular testing on physical devices will help identify and resolve platform-specific issues, ensuring a seamless experience for all users.
