### **Data Models Document for VitalEdge XR**

---

#### **1. Introduction**
The Data Models document describes the structure and relationships of the data used within **VitalEdge XR**. This includes models for patient information, medical records, real-time vitals, biological entities, and visualizations. These data models ensure consistency between the backend, Unity client, and XR environments.

By standardizing the data structures, this document supports the scalability and maintainability of the VitalEdge XR system.

---

### **2. Core Data Models**

#### **2.1 Patient Model**
The `Patient` model represents individual patient data and serves as the cornerstone of the application.

**Structure**:
```csharp
[System.Serializable]
public class Patient
{
    public string id;        // Unique identifier for the patient
    public string name;      // Full name of the patient
    public int age;          // Patient's age
    public string address;   // Patient's address
    public List<MedicalRecord> medicalRecords; // List of medical records
    public List<VitalSign> vitalSigns;         // List of real-time vitals
    public List<DeviceData> deviceData;        // Data from wearable/medical devices
}
```

**Sample JSON**:
```json
{
    "id": "674dd977ff5f6f584f12087f",
    "name": "James Dean",
    "age": 45,
    "address": "1040 Main Street, Madison WI",
    "medicalRecords": [],
    "vitalSigns": [],
    "deviceData": []
}
```

---

#### **2.2 MedicalRecord Model**
The `MedicalRecord` model stores patient-specific medical history.

**Structure**:
```csharp
[System.Serializable]
public class MedicalRecord
{
    public string recordId;    // Unique identifier for the record
    public string diagnosis;   // Diagnosis (e.g., Hypertension)
    public string treatment;   // Treatment plan or medication
    public DateTime date;      // Date of record creation
}
```

**Sample JSON**:
```json
{
    "recordId": "rec123",
    "diagnosis": "Hypertension",
    "treatment": "Amlodipine 10mg daily",
    "date": "2024-01-01T00:00:00Z"
}
```

---

#### **2.3 VitalSign Model**
The `VitalSign` model captures real-time vital data for patients.

**Structure**:
```csharp
[System.Serializable]
public class VitalSign
{
    public string type;    // Type of vital (e.g., HeartRate, BloodPressure)
    public float value;    // Numerical value of the vital sign
    public string unit;    // Unit of measurement (e.g., bpm, mmHg)
    public DateTime timestamp; // Timestamp of the measurement
}
```

**Sample JSON**:
```json
{
    "type": "HeartRate",
    "value": 72,
    "unit": "bpm",
    "timestamp": "2024-01-01T12:00:00Z"
}
```

---

#### **2.4 DeviceData Model**
The `DeviceData` model stores data from wearables or medical devices.

**Structure**:
```csharp
[System.Serializable]
public class DeviceData
{
    public string deviceId;    // Unique identifier for the device
    public string type;        // Device type (e.g., Fitbit, ECG Monitor)
    public Dictionary<string, float> metrics; // Key-value pairs of metrics
    public DateTime lastUpdated; // Timestamp of the last update
}
```

**Sample JSON**:
```json
{
    "deviceId": "dev001",
    "type": "ECG Monitor",
    "metrics": {
        "HeartRate": 78,
        "OxygenSaturation": 97
    },
    "lastUpdated": "2024-01-01T12:00:00Z"
}
```

---

### **3. Visualization Data Models**

#### **3.1 ScatterPlot Data Model**
The `ScatterPlot` model defines data for rendering scatter plots in the **DataPortal**.

**Structure**:
```csharp
[System.Serializable]
public class ScatterPlotData
{
    public List<Vector3> points;      // List of 3D points (x, y, z coordinates)
    public string title;             // Title of the scatter plot
    public string xLabel;            // Label for the X-axis
    public string yLabel;            // Label for the Y-axis
    public string zLabel;            // Label for the Z-axis
}
```

**Sample JSON**:
```json
{
    "points": [
        {"x": 1.2, "y": 3.4, "z": 5.6},
        {"x": 2.2, "y": 1.4, "z": 4.1}
    ],
    "title": "3D Gene Expression Scatter Plot",
    "xLabel": "Gene 1 Expression",
    "yLabel": "Gene 2 Expression",
    "zLabel": "Gene 3 Expression"
}
```

---

#### **3.2 Heatmap Data Model**
The `Heatmap` model defines data for rendering heatmaps in the **DataPortal**.

**Structure**:
```csharp
[System.Serializable]
public class HeatmapData
{
    public List<List<float>> values;  // 2D grid of heatmap values
    public string title;             // Title of the heatmap
    public string xLabel;            // Label for the X-axis
    public string yLabel;            // Label for the Y-axis
    public string legendLabel;       // Label for the color legend
}
```

**Sample JSON**:
```json
{
    "values": [
        [0.5, 0.8, 0.9],
        [0.2, 0.4, 0.7]
    ],
    "title": "Gene Expression Heatmap",
    "xLabel": "Samples",
    "yLabel": "Genes",
    "legendLabel": "Expression Level"
}
```

---

#### **3.3 Neural Network Data Model**
The `NeuralNetwork` model defines data for rendering neural networks in the **NeuralPortal**.

**Structure**:
```csharp
[System.Serializable]
public class NeuralNetwork
{
    public List<Neuron> neurons;    // List of neurons in the network
    public List<Synapse> synapses; // List of synapses connecting neurons
}
```

**Neuron Structure**:
```csharp
[System.Serializable]
public class Neuron
{
    public Vector3 position;       // 3D position of the neuron
    public int dendriteCount;      // Number of dendrites
    public float axonLength;       // Length of the axon
}
```

**Synapse Structure**:
```csharp
[System.Serializable]
public class Synapse
{
    public int preSynapticNeuron;  // Index of the pre-synaptic neuron
    public int postSynapticNeuron; // Index of the post-synaptic neuron
    public string neurotransmitter; // Neurotransmitter type
    public bool isExcitatory;      // Excitatory (true) or inhibitory (false)
}
```

**Sample JSON**:
```json
{
    "neurons": [
        {"position": {"x": 0, "y": 0, "z": 0}, "dendriteCount": 3, "axonLength": 5.0},
        {"position": {"x": 5, "y": 0, "z": 0}, "dendriteCount": 2, "axonLength": 4.0}
    ],
    "synapses": [
        {"preSynapticNeuron": 0, "postSynapticNeuron": 1, "neurotransmitter": "dopamine", "isExcitatory": true}
    ]
}
```

---

### **4. Summary**
The data models in **VitalEdge XR** are designed to handle patient data, biological visualizations, and real-time analytics. They ensure a consistent structure for API integration, visualization rendering, and XR interactions. The modular nature of these models makes them easy to extend for future features like predictive analytics or collaborative environments.
