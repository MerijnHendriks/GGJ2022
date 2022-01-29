using System;
using System.Collections.Generic;
using UnityEngine;

namespace AudioReact
{
    public static class Sampler
    {
        private const int samplesAmount = 1024;
        private static readonly float frequencyMax;
        private static readonly Dictionary<FrequencyRange, float[]> FrequencyRanges;
        public static float[] FrequencySamples { get; private set; }
        public static AudioSource AudioSource;

        static Sampler()
        {
            frequencyMax = (float)AudioSettings.outputSampleRate / 2;
            FrequencySamples = new float[Enum.GetNames(typeof(FrequencyRange)).Length];
            FrequencyRanges = new Dictionary<FrequencyRange, float[]>()
            {
                { FrequencyRange.SubBase,       new float[2] { 0,    60    } },
                { FrequencyRange.Bass,          new float[2] { 60,   250   } },
                { FrequencyRange.LowMidrange,   new float[2] { 250,  500   } },
                { FrequencyRange.Midrange,      new float[2] { 500,  2000  } },
                { FrequencyRange.UpperMidrange, new float[2] { 2000, 4000  } },
                { FrequencyRange.High,          new float[2] { 4000, 6000  } },
                { FrequencyRange.VeryHigh,      new float[2] { 6000, 20000 } },
                { FrequencyRange.Decibel,       new float[2] { 0,    20000 } }
            };
        }

        public static void Update()
        {
            if (AudioSource == null || AudioSource.mute)
            {
                return;
            }

            float[] frequencyData = new float[samplesAmount];
            float[] outputData = new float[samplesAmount];

            AudioSource.GetSpectrumData(frequencyData, 0, FFTWindow.BlackmanHarris);
            AudioSource.GetOutputData(outputData, 0);

            for (int i = 0; i < FrequencySamples.Length; i++)
            {
                if ((FrequencyRange)i != FrequencyRange.Decibel)
                {
                    FrequencySamples[i] = GetFrequencyVolume(AudioSource.volume, frequencyData, (FrequencyRange)i);
                }
                else
                {
                    FrequencySamples[i] = GetRMS(AudioSource.volume, outputData);
                }
            }
        }

        public static float GetSample(FrequencyRange range)
        {
            return FrequencySamples[(int)range];
        }

        private static float GetFrequencyVolume(float volume, float[] frequencyData, FrequencyRange range)
        {
            float sum = 0;
            int n1 = (int)Mathf.Floor(FrequencyRanges[range][0] * samplesAmount / frequencyMax);
            int n2 = (int)Mathf.Floor(FrequencyRanges[range][1] * samplesAmount / frequencyMax);

            for (int i = n1; i <= n2; i++)
            {
                if (i < frequencyData.Length && i >= 0)
                {
                    sum += Mathf.Abs(frequencyData[i]);
                }
            }

            return (sum * volume) / (n2 - n1 + 1);
        }

        private static float GetRMS(float volume, float[] outputData)
        {
            float sum = 0;

            for (int i = 0; i < outputData.Length; i++)
            {
                sum += outputData[i] * outputData[i];
            }

            return Mathf.Sqrt(sum / samplesAmount) * volume;
        }
    }
}
