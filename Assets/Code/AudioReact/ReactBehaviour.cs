using System;
using UnityEngine;

namespace AudioReact
{
    [Serializable]
    public class ReactBehaviour
    {
        public FrequencyRange Range = FrequencyRange.Decibel;
        public float Sensitivity = 1;
        public float Smoothing = 1.0f;
        public float ClampMin = 0.0f;
        public float ClampMax = 1.0f;

        public ReactBehaviour()
        {
            if (ClampMax < ClampMin)
            {
                throw new Exception("AudioReact.ReactBehaviour: clamp max cannot be lower than clamp min");
            }
        }

        public float GetSample()
        {
            float sample = Sampler.GetSample(Range) * Sensitivity;
            return Mathf.Lerp(ClampMin, ClampMax, sample);
        }
    }
}
