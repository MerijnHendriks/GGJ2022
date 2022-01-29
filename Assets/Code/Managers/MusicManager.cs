using System.Collections.Generic;
using UnityEngine;
using AudioReact;

public enum ETracks
{
    MainTheme = 0
}

public class MusicManager : Manager
{
    private readonly Dictionary<ETracks, AudioSource> tracks;

    public MusicManager()
    {
        tracks = new Dictionary<ETracks, AudioSource>();
    }

    public void Add(ETracks track, AudioSource audio)
    {
        audio.loop = true;
        tracks.Add(track, audio);
    }

    public void Stop()
    {
        foreach (AudioSource item in tracks.Values)
        {
            if (item.isPlaying)
            {
                item.Stop();
            }
        }
    }

    public void Play(ETracks track)
    {
        Stop();
        tracks[track].Play();
        Sampler.AudioSource = tracks[track];
    }
}
