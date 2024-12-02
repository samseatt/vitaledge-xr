using System.Collections.Generic;

namespace API
{
    public class MockDataApi
    {
        /// <summary>
        /// Simulates a GET request for scatter plot data based on patient.
        /// </summary>
        public List<(float age, float bp, float cholesterol, float bmi, string gender)> GetScatterPlotData(string patient)
        {
            if (patient == "Patient A")
            {
                return new List<(float, float, float, float, string)>
                {
                    (30, 115, 190, 22, "Male"),
                    (40, 130, 210, 26, "Female"),
                    (50, 145, 230, 29, "Male"),
                    (60, 160, 250, 32, "Female"),
                };
            }
            else if (patient == "Patient B")
            {
                return new List<(float, float, float, float, string)>
                {
                    (25, 110, 185, 21, "Female"),
                    (35, 125, 200, 24, "Male"),
                    (45, 140, 220, 27, "Female"),
                    (55, 155, 240, 30, "Male"),
                };
            }

            // Default data
            return new List<(float, float, float, float, string)>
            {
                (35, 120, 200, 25, "Male"),
                (42, 135, 220, 28, "Female"),
                (50, 140, 250, 30, "Male"),
                (60, 160, 270, 35, "Female"),
            };
        }

        public List<List<float>> GetGeneExpressionHeatmapData(string patient)
        {
            // Mock gene expression data (5 genes x 5 samples)
            if (patient == "Patient A")
            {
                return new List<List<float>>
                {
                    new List<float> { 2.5f, 3.0f, 4.5f, 2.0f, 5.0f }, // Gene 1
                    new List<float> { 1.0f, 2.5f, 2.0f, 3.5f, 1.5f }, // Gene 2
                    new List<float> { 4.0f, 4.5f, 3.0f, 4.0f, 5.0f }, // Gene 3
                    new List<float> { 3.0f, 3.5f, 2.0f, 3.5f, 2.5f }, // Gene 4
                    new List<float> { 5.0f, 5.5f, 6.0f, 5.0f, 6.5f }, // Gene 5
                };
            }
            else if (patient == "Patient B")
            {
                return new List<List<float>>
                {
                    new List<float> { 3.5f, 4.0f, 5.5f, 3.0f, 6.0f },
                    new List<float> { 1.5f, 2.5f, 3.0f, 2.5f, 1.0f },
                    new List<float> { 4.5f, 4.0f, 4.0f, 5.0f, 4.5f },
                    new List<float> { 2.0f, 3.0f, 2.5f, 3.5f, 3.0f },
                    new List<float> { 6.0f, 6.5f, 7.0f, 5.5f, 7.5f },
                };
            }

            // Default data
            return new List<List<float>>
            {
                new List<float> { 2.0f, 3.0f, 4.0f, 2.5f, 5.5f },
                new List<float> { 1.5f, 2.0f, 2.5f, 3.0f, 1.0f },
                new List<float> { 4.5f, 4.0f, 3.5f, 5.0f, 4.0f },
                new List<float> { 3.0f, 3.5f, 2.5f, 3.0f, 3.5f },
                new List<float> { 5.5f, 6.0f, 5.5f, 6.0f, 6.5f },
            };
        }
    }
}
