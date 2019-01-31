using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SupportV4Jam
{

public class MaterialRandomizer : MonoBehaviour
{
    public Material[] list_of_materials;
    public float[] list_of_frequencies;

    // Use this for initialization
    void Start()
    {
        float[] list_of_summed_frequencies = new float[list_of_frequencies.Length];

        if ((list_of_materials.GetLength(0) == list_of_frequencies.GetLength(0)) &&
                (list_of_frequencies.Length > 1))
        {

            list_of_summed_frequencies[0] = list_of_frequencies[0];

            for (int i = 1; i < list_of_frequencies.Length; i++)
            {
                float sum = list_of_frequencies[i - 1] + list_of_frequencies[i];
                list_of_summed_frequencies[i] = sum;
            }

            float random_result = Random.Range(0.0f, list_of_summed_frequencies[list_of_summed_frequencies.Length - 1]);

            for (int i = 0; i < list_of_summed_frequencies.Length; i++)
            {
                if (random_result <= list_of_summed_frequencies[i])
                {
                    GetComponent<MeshRenderer>().material = list_of_materials[i];
                    break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

}

