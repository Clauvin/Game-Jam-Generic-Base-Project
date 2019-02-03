using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightController : MonoBehaviour
{

    public Light sun;
    public float secondsInFullDay = 120f;
    [Range(0, 1)]
    public float currentTimeOfDay = 0.5f;

    public float[] light_sunrise_times;
    public float[] light_sunset_times;

    [HideInInspector]
    public float timeMultiplier = 1f;

    float sunInitialIntensity;

    void Start()
    {
        sunInitialIntensity = sun.intensity;
    }

    void Update()
    {
        UpdateSun();

        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;

        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
        }
    }

    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        float intensityMultiplier = 1;
        float sunrise_time_adjuster = (1.0f / (light_sunrise_times[1] - light_sunrise_times[0]));
        float sunset_time_adjuster = (1.0f / (light_sunset_times[1] - light_sunset_times[0]));
        if (currentTimeOfDay <= light_sunrise_times[0] || currentTimeOfDay >= light_sunset_times[1])
        {
            intensityMultiplier = 0;
        }
        else if (currentTimeOfDay <= light_sunrise_times[1])
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - light_sunrise_times[0]) * sunrise_time_adjuster);
        }
        else if (currentTimeOfDay >= light_sunset_times[0])
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - light_sunset_times[0]) * sunset_time_adjuster));
        }

        sun.intensity = sunInitialIntensity * intensityMultiplier;
    }
}
