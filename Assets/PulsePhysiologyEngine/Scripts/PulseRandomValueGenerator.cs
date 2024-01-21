/* Distributed under the Apache License, Version 2.0.
   See accompanying NOTICE file for details.*/

using System.Collections.Generic;
using UnityEngine;

// Component used to generate random values and broadcast them as pulse data
[ExecuteInEditMode]
public class PulseRandomValueGenerator : PulseDataSource
{

    [SerializeField] private GameObject Character;

    private CharacterHeartRate Heart;

    private float minValue;      // Minimum value
    private float maxValue;    // Maximum value
    [Range(0f, 1f)]
    public float variability = .1f; // How similar to the previous value we are
    [Range(0f, 120f)]
    public float frequency = 0;     // How fast do we generate a new value

    [SerializeField, HideInInspector]
    float previousValue;            // Used with variability to get new value
    float previousTime = 0;         // Used to match the requested frequency


    // MARK: Monobehavior methods

    // Called when application or editor opens
    void Awake()
    {
        // Create our data container
        data = ScriptableObject.CreateInstance<PulseData>();

        // Store data field names
        data.fields = new StringList();
        data.fields.Add("Random");

        // Allocate space for data times and values
        data.timeStampList = new DoubleList();
        data.valuesTable = new List<DoubleList> { new DoubleList() };
    }

    // Called at the first frame when the component is enabled
    void Start()
    {
        Heart = Character.GetComponent<CharacterHeartRate>();
        minValue = Heart.GetHeartRate() - 10.0f;
        maxValue = Heart.GetHeartRate() + 10.0f;
        // Ensure we only generate data if the application is playing
        if (!Application.isPlaying)
        return;

        // Compute initial random value
        previousValue = Random.Range(minValue, maxValue);
    }

    // Called before every frame
    void Update()
    {
        // Ensure we only generate data if the application is playing
        if (Heart.GetHeartRate() > 0)
        {
            minValue = Heart.GetHeartRate() - 10.0f;
            if (minValue <= 0) minValue = 0;
            maxValue = Heart.GetHeartRate() + 10.0f;
            if (!Application.isPlaying)
                return;

            previousValue = Random.Range(minValue, maxValue);
            // Clear PulseData container
            data.timeStampList.Clear();
            data.valuesTable[0].Clear();

            // Only generate data at a certain frequency
            var time = Time.time;
            if (frequency > 0 && time < previousTime + 1 / frequency)
                return;

            // Update time and compute data value
            previousTime = time;
            previousValue = GenerateRandomValue();

            // Broadcast data
            data.timeStampList.Add(previousTime);
            data.valuesTable[0].Add(previousValue);
        }
        else {
            minValue = 0;
            maxValue = 0;
            if (!Application.isPlaying)
                return;

            previousValue = Random.Range(minValue, maxValue);
            // Clear PulseData container
            data.timeStampList.Clear();
            data.valuesTable[0].Clear();

            // Only generate data at a certain frequency
            var time = Time.time;
            if (frequency > 0 && time < previousTime + 1 / frequency)
                return;

            // Update time and compute data value
            previousTime = time;
            previousValue = GenerateRandomValue();

            // Broadcast data
            data.timeStampList.Add(previousTime);
            data.valuesTable[0].Add(previousValue);
        }
        
    }


    // MARK: Custom methods

    // Generate a random value
    float GenerateRandomValue()
    {
        var val = Random.Range(minValue, maxValue);
        val = variability * val + (1 - variability) * previousValue;
        previousValue = val;
        return val;
    }
}
