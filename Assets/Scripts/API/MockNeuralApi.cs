using System.Collections.Generic;
using UnityEngine;

public class MockNeuralApi
{
    public NeuralNetwork GetNeuralNetwork()
    {
        // Define neurons
        var neurons = new List<Neuron>
        {
            new Neuron { id = 0, nd = 3, ld = 1.0f, la = 2.0f, position = new Vector3(0, 0, 0) },
            new Neuron { id = 1, nd = 4, ld = 1.5f, la = 2.5f, position = new Vector3(3, 0, 0) },
            new Neuron { id = 2, nd = 2, ld = 1.2f, la = 1.8f, position = new Vector3(6, 0, 0) },
        };

        // Define synapses
        var synapses = new List<Synapse>
        {
            new Synapse { axonalNeuronId = 0, dendriticNeuronId = 1 },
            new Synapse { axonalNeuronId = 1, dendriticNeuronId = 2 },
        };

        return new NeuralNetwork { neurons = neurons, synapses = synapses };
    }
}
