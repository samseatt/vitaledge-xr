using UnityEngine;

public class ReceptorPlacer : MonoBehaviour
{
    public GameObject receptorPrefab;
    public int receptorCount = 10;

    void Start()
    {
        PlaceReceptors();
    }

    void PlaceReceptors()
    {
        for (int i = 0; i < receptorCount; i++)
        {
            // Generate random point on sphere surface
            Vector3 randomPoint = Random.onUnitSphere * 0.5f; // Adjust scale for receptor placement
            GameObject receptor = Instantiate(receptorPrefab, transform);
            receptor.transform.localPosition = randomPoint;
        }
    }
}
