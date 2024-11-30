using UnityEngine;

public class MockApi : MonoBehaviour
{
    // Simulate fetching size data (e.g., dosage level)
    public float GetSizeFromApi()
    {
        // Mock size value between 0.5 and 3.0
        return Random.Range(0.5f, 3.0f);
    }

    // Simulate fetching color data (e.g., RGB based on patient status)
    public Color GetColorFromApi()
    {
        // Mock random RGB color
        return new Color(Random.value, Random.value, Random.value);
    }
}
