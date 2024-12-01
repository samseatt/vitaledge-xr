using System.Collections.Generic;

namespace Data
{
    public static class NeuronMorphologies
    {
        // Morphology dictionary: Neuron type to (nd, ld, la)
        public static readonly Dictionary<string, (int nd, float ld, float la)> MorphologyDictionary = new Dictionary<string, (int, float, float)>
        {
            { "pyramidal", (4, 1.5f, 3.0f) },
            { "motor", (6, 1.2f, 2.5f) },
            { "interneuron", (3, 1.0f, 1.8f) },
        };

        /// <summary>
        /// Gets morphology parameters for a given neuron type.
        /// </summary>
        public static (int nd, float ld, float la) GetMorphology(string neuronType)
        {
            return MorphologyDictionary.TryGetValue(neuronType, out var parameters)
                ? parameters
                : (3, 1.0f, 1.0f); // Default morphology
        }
    }
}
