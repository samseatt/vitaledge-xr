using System.Collections.Generic;
using UnityEngine;

public class NeuralNetworkRenderer : MonoBehaviour
{
    public GameObject neuronPrefab;
    public GameObject dendritePrefab;
    public GameObject axonPrefab;
    public GameObject synapsePrefab;

    private MockNeuralApi mockApi;

    void Start()
    {
        // Initialize the Mock API
        mockApi = new MockNeuralApi();

        // Get the neural network data from the Mock API
        NeuralNetwork network = mockApi.GetNeuralNetwork();

        // Render the neural network
        RenderNeuralNetwork(network);
    }

    //public void RenderNeuralNetwork(NeuralNetwork network)
    //{
    //    foreach (var neuron in network.neurons)
    //    {
    //        // Instantiate the neuron (soma)
    //        var neuronObject = Instantiate(neuronPrefab, neuron.position, Quaternion.identity);

    //        // Generate dendrites
    //        for (int i = 0; i < neuron.nd; i++)
    //        {
    //            Vector3 direction = Random.onUnitSphere; // Random direction
    //            Vector3 dendriteEnd = neuron.position + direction * neuron.ld;
    //            var dendrite = Instantiate(dendritePrefab, neuron.position, Quaternion.LookRotation(direction));
    //            dendrite.transform.localScale = new Vector3(0.1f, 0.1f, neuron.ld);
    //        }

    //        // Generate axon
    //        Vector3 axonDirection = Vector3.forward; // Default direction
    //        Vector3 axonEnd = neuron.position + axonDirection * neuron.la;
    //        var axon = Instantiate(axonPrefab, neuron.position, Quaternion.LookRotation(axonDirection));
    //        axon.transform.localScale = new Vector3(0.1f, 0.1f, neuron.la);
    //    }

    //    foreach (var synapse in network.synapses)
    //    {
    //        var axonalNeuron = network.neurons[synapse.axonalNeuronId];
    //        var dendriticNeuron = network.neurons[synapse.dendriticNeuronId];

    //        Vector3 synapsePosition = axonalNeuron.position + Vector3.forward * axonalNeuron.la; // End of axon
    //        Instantiate(synapsePrefab, synapsePosition, Quaternion.identity);
    //    }
    //}

    public void RenderNeuralNetwork(NeuralNetwork network)
    {
        float spacing = 5.0f; // Distance between neurons

        // Calculate positions for neurons
        for (int i = 0; i < network.neurons.Count; i++)
        {
            network.neurons[i].position = CalculateNeuronPosition(i, network.neurons.Count, spacing);

            // Instantiate the neuron (soma)
            Instantiate(neuronPrefab, network.neurons[i].position, Quaternion.identity);
        }

        // Create axons and dendrites
        foreach (var synapse in network.synapses)
        {
            Neuron axonalNeuron = network.neurons[synapse.axonalNeuronId];
            Neuron dendriticNeuron = network.neurons[synapse.dendriticNeuronId];

            // Create axon
            CreateAxon(axonalNeuron, dendriticNeuron);

            // Place synapse
            PlaceSynapse(axonalNeuron, dendriticNeuron);
        }
    }

    private Vector3 CalculateNeuronPosition(int neuronIndex, int totalNeurons, float spacing)
    {
        return new Vector3(neuronIndex * spacing, 0, 0);
    }

    private void CreateAxon(Neuron axonalNeuron, Neuron dendriticNeuron)
    {
        Vector3 start = axonalNeuron.position;
        Vector3 end = dendriticNeuron.position;

        // Create a thick line (instead of a cylinder)
        var line = new GameObject("Axon");
        var lineRenderer = line.AddComponent<LineRenderer>();

        lineRenderer.positionCount = 2;
        lineRenderer.SetPositions(new Vector3[] { start, end });

        lineRenderer.startWidth = 0.1f; // Thickness of the axon
        lineRenderer.endWidth = 0.1f;

        lineRenderer.material = new Material(Shader.Find("Standard"));
        lineRenderer.material.color = Color.yellow; // Axon color
    }

    //void CreateAxon(Neuron axonalNeuron, Neuron dendriticNeuron)
    //{
    //    Vector3 start = axonalNeuron.position;
    //    Vector3 end = dendriticNeuron.position;

    //    // Create a GameObject for the line
    //    var line = new GameObject("Axon");
    //    var lineRenderer = line.AddComponent<LineRenderer>();

    //    // Set positions
    //    lineRenderer.positionCount = 2;
    //    lineRenderer.SetPositions(new Vector3[] { start, end });

    //    // Set width
    //    lineRenderer.startWidth = 0.1f;
    //    lineRenderer.endWidth = 0.1f;

    //    // Assign a valid material
    //    var lineMaterial = Resources.Load<Material>("LineMaterial");
    //    if (lineMaterial != null)
    //    {
    //        lineRenderer.material = lineMaterial;
    //    }
    //    else
    //    {
    //        Debug.LogError("LineMaterial not found in Resources folder");
    //    }
    //}


    private void PlaceSynapse(Neuron axonalNeuron, Neuron dendriticNeuron)
    {
        // Synapse position: halfway between axon and dendrite
        Vector3 synapsePosition = (axonalNeuron.position + dendriticNeuron.position) / 2;

        // Instantiate the synapse prefab at this position
        Instantiate(synapsePrefab, synapsePosition, Quaternion.identity);
    }

}
