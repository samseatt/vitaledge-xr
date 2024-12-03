### **API Specification Document for VitalEdge XR**

---

#### **1. Introduction**
The purpose of this document is to define the API specifications for the **VitalEdge XR** system, outlining the RESTful endpoints required to communicate with various VitalEdge microservices. The data retrieved and sent through these APIs will power the immersive XR environments, real-time visualizations, and user interactions.

VitalEdge XR will integrate with four primary microservices:

1. **vitaledge-security**: Handles authentication and provides JWT tokens for API authorization.
2. **vitaledge-backend**: Provides static patient data, such as demographic and medical history.
3. **vitaledge-data-aggregator**: Supplies real-time patient data, such as vital signs and device metrics.
4. **vitaledge-analytics**: Provides analytics results for complex data visualizations, such as gene expression patterns or neural network simulations.

---

### **2. API Endpoints**

#### **2.1 vitaledge-security**

**Base URL**: `https://vitaledge-security.example.com`

| **Method** | **Endpoint**               | **Description**                         |
|------------|----------------------------|-----------------------------------------|
| POST       | `/authenticate`            | Authenticates a user and returns a JWT. |
| POST       | `/refresh-token`           | Refreshes an expired JWT token.         |

##### **2.1.1 /authenticate**
- **Description**: Authenticates the user with their username and password.
- **Request Body**:
  ```json
  {
    "username": "admin",
    "password": "password"
  }
  ```
- **Response**:
  ```json
  {
    "token": "<JWT_token>",
    "expiresIn": 3600
  }
  ```

##### **2.1.2 /refresh-token**
- **Description**: Renews the JWT when it expires.
- **Request Body**:
  ```json
  {
    "token": "<expired_JWT_token>"
  }
  ```
- **Response**:
  ```json
  {
    "token": "<new_JWT_token>",
    "expiresIn": 3600
  }
  ```

---

#### **2.2 vitaledge-backend**

**Base URL**: `https://vitaledge-backend.example.com`

| **Method** | **Endpoint**        | **Description**                             |
|------------|---------------------|---------------------------------------------|
| GET        | `/api/patients`     | Retrieves a list of all patients.           |
| GET        | `/api/patients/{id}`| Retrieves detailed information for a patient.|

##### **2.2.1 /api/patients**
- **Description**: Retrieves a list of basic patient information.
- **Headers**:
  ```json
  {
    "Authorization": "Bearer <JWT_token>"
  }
  ```
- **Response**:
  ```json
  [
    {
      "id": "674dd977ff5f6f584f12087f",
      "name": "James Dean",
      "age": 45,
      "address": "1040 Main Street, Madison WI"
    },
    {
      "id": "674dd9a2ff5f6f584f120880",
      "name": "Johnny Cash",
      "age": 62,
      "address": "100 Freedom Way, Story IL"
    }
  ]
  ```

##### **2.2.2 /api/patients/{id}**
- **Description**: Retrieves detailed information about a specific patient.
- **Path Parameter**:
  - `id` (string): Unique identifier of the patient.
- **Headers**:
  ```json
  {
    "Authorization": "Bearer <JWT_token>"
  }
  ```
- **Response**:
  ```json
  {
    "id": "674dd977ff5f6f584f12087f",
    "name": "James Dean",
    "age": 45,
    "address": "1040 Main Street, Madison WI",
    "medicalRecords": [
      {
        "recordId": "rec123",
        "diagnosis": "Hypertension",
        "treatment": "Amlodipine 10mg daily",
        "date": "2024-01-01T00:00:00Z"
      }
    ],
    "vitalSigns": [],
    "deviceData": []
  }
  ```

---

#### **2.3 vitaledge-data-aggregator**

**Base URL**: `https://vitaledge-aggregator.example.com`

| **Method** | **Endpoint**                   | **Description**                          |
|------------|--------------------------------|------------------------------------------|
| GET        | `/api/vitals/{patientId}`      | Retrieves real-time vital signs.         |
| GET        | `/api/device-data/{patientId}` | Retrieves real-time device data.         |

##### **2.3.1 /api/vitals/{patientId}**
- **Description**: Fetches real-time vital signs for a patient.
- **Path Parameter**:
  - `patientId` (string): Unique identifier of the patient.
- **Headers**:
  ```json
  {
    "Authorization": "Bearer <JWT_token>"
  }
  ```
- **Response**:
  ```json
  [
    {
      "type": "HeartRate",
      "value": 72,
      "unit": "bpm",
      "timestamp": "2024-01-01T12:00:00Z"
    },
    {
      "type": "BloodPressure",
      "value": "120/80",
      "unit": "mmHg",
      "timestamp": "2024-01-01T12:00:00Z"
    }
  ]
  ```

##### **2.3.2 /api/device-data/{patientId}**
- **Description**: Fetches real-time data from medical devices for a patient.
- **Response**:
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

#### **2.4 vitaledge-analytics**

**Base URL**: `

`https://vitaledge-analytics.example.com`

| **Method** | **Endpoint**                    | **Description**                           |
|------------|---------------------------------|-------------------------------------------|
| GET        | `/api/analytics/scatterplot`    | Retrieves data for 3D scatter plots.      |
| GET        | `/api/analytics/heatmap`        | Retrieves data for heatmap visualizations.|
| POST       | `/api/analytics/neural-network` | Generates a neural network visualization. |

##### **2.4.1 /api/analytics/scatterplot**
- **Description**: Fetches data points for rendering a 3D scatter plot.
- **Query Parameters**:
  - `patientId` (string): Unique identifier of the patient.
- **Headers**:
  ```json
  {
    "Authorization": "Bearer <JWT_token>"
  }
  ```
- **Response**:
  ```json
  {
    "title": "Gene Expression Correlation",
    "xLabel": "Gene 1 Expression",
    "yLabel": "Gene 2 Expression",
    "zLabel": "Gene 3 Expression",
    "points": [
      {"x": 1.2, "y": 3.4, "z": 5.6},
      {"x": 2.2, "y": 1.4, "z": 4.1}
    ]
  }
  ```

##### **2.4.2 /api/analytics/heatmap**
- **Description**: Retrieves heatmap data for gene expression analysis.
- **Query Parameters**:
  - `patientId` (string): Unique identifier of the patient.
- **Headers**:
  ```json
  {
    "Authorization": "Bearer <JWT_token>"
  }
  ```
- **Response**:
  ```json
  {
    "title": "Gene Expression Heatmap",
    "xLabel": "Samples",
    "yLabel": "Genes",
    "legendLabel": "Expression Level",
    "values": [
      [0.5, 0.8, 0.9],
      [0.2, 0.4, 0.7]
    ]
  }
  ```

##### **2.4.3 /api/analytics/neural-network**
- **Description**: Generates a neural network model for visualization.
- **Request Body**:
  ```json
  {
    "neuronCount": 3,
    "synapseCount": 2,
    "neuronDetails": [
      {"dendriteCount": 3, "axonLength": 5.0},
      {"dendriteCount": 2, "axonLength": 4.5}
    ]
  }
  ```
- **Headers**:
  ```json
  {
    "Authorization": "Bearer <JWT_token>"
  }
  ```
- **Response**:
  ```json
  {
    "neurons": [
      {"position": {"x": 0, "y": 0, "z": 0}, "dendriteCount": 3, "axonLength": 5.0},
      {"position": {"x": 5, "y": 0, "z": 0}, "dendriteCount": 2, "axonLength": 4.5}
    ],
    "synapses": [
      {"preSynapticNeuron": 0, "postSynapticNeuron": 1, "isExcitatory": true}
    ]
  }
  ```

---

### **3. Common Headers**
All APIs require the following headers:
- **Authorization**:
  ```json
  {
    "Authorization": "Bearer <JWT_token>"
  }
  ```
- **Content-Type**:
  ```json
  {
    "Content-Type": "application/json"
  }
  ```

---

### **4. Error Handling**

| **Error Code** | **Description**                         |
|----------------|-----------------------------------------|
| 400            | Bad request (e.g., missing parameters).|
| 401            | Unauthorized (e.g., invalid JWT token).|
| 403            | Forbidden (e.g., insufficient access). |
| 404            | Not found (e.g., invalid endpoint).    |
| 500            | Internal server error.                 |

**Error Response**:
```json
{
  "error": "Unauthorized",
  "message": "Invalid or expired JWT token."
}
```

---

### **5. API Usage Patterns**

1. **Authentication Flow**:
   - Use `/authenticate` in `vitaledge-security` to get a JWT token.
   - Pass the token in all subsequent API calls.

2. **Patient Data Retrieval**:
   - Retrieve patient list from `/api/patients` in `vitaledge-backend`.
   - Use the selected patient’s ID for further data requests.

3. **Real-Time Data Retrieval**:
   - Fetch vital signs from `vitaledge-data-aggregator` using `/api/vitals/{patientId}`.

4. **Analytics Data**:
   - Query the `vitaledge-analytics` endpoints for visualizations like scatter plots and heatmaps.

---

### **6. Future Enhancements**

1. **vitaledge-crypt**:
   - Encrypt sensitive patient data before transmission.
   - Decrypt data for visualization in Unity.

2. **Streaming Data**:
   - Add WebSocket support for real-time streaming of vital signs.

3. **Predictive Analytics**:
   - Extend `vitaledge-analytics` to include AI-based prediction APIs (e.g., risk scores, treatment outcomes).

---

### **7. Conclusion**
This API specification provides a robust framework for integrating VitalEdge XR with backend services, ensuring scalability, security, and flexibility. By defining modular endpoints across four microservices, the architecture supports both current and future use cases, including real-time data updates, interactive visualizations, and predictive analytics.
