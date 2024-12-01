using UnityEngine;

public class DNAGenerator : MonoBehaviour
{
    public GameObject nucleotidePrefab; // Prefab for nucleotides
    public GameObject bondPrefab;       // Prefab for bonds
    public int strandLength = 20;

    void Start()
    {
        GenerateDNA();
    }

    void GenerateDNA()
    {
        float angleStep = 36f; // Degrees between each nucleotide
        float helixRadius = 0.5f; // Radius of helix
        float bondLength = 0.2f; // Distance between bases

        for (int i = 0; i < strandLength; i++)
        {
            // Calculate positions for nucleotides on both strands
            float angle = i * angleStep * Mathf.Deg2Rad;
            Vector3 pos1 = new Vector3(Mathf.Cos(angle) * helixRadius, i * bondLength, Mathf.Sin(angle) * helixRadius);
            Vector3 pos2 = new Vector3(-Mathf.Cos(angle) * helixRadius, i * bondLength, -Mathf.Sin(angle) * helixRadius);

            // Create nucleotides
            Instantiate(nucleotidePrefab, pos1, Quaternion.identity, transform);
            Instantiate(nucleotidePrefab, pos2, Quaternion.identity, transform);

            // Create bond between the nucleotides
            Vector3 bondPosition = (pos1 + pos2) / 2;
            GameObject bond = Instantiate(bondPrefab, bondPosition, Quaternion.identity, transform);

            // Set bond rotation and scale
            bond.transform.LookAt(pos1); // Align bond toward one nucleotide
            //bond.transform.Rotate(90, 0, 0); // Adjust bond to align with z-axis
            bond.transform.localScale = new Vector3(0.1f, 0.1f, Vector3.Distance(pos1, pos2)); // Adjust length
        }
    }
}
