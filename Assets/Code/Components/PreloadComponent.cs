using System;
using UnityEngine;

[Serializable]
public class AudioTrack
{
    public ETracks Id;
    public AudioSource Audio;
}

public class PreloadComponent : MonoBehaviour
{
    [SerializeField]
    private EScenes sceneToLoad = EScenes.MainMenu;

    [SerializeField]
    private AudioTrack[] tracks;

    private void Start()
    {
        MusicManager musicManager = GameManager.Instance.GetManager<MusicManager>();

        // add songs to musicmanager
        foreach (AudioTrack item in tracks)
        {
            musicManager.Add(item.Id, item.Audio);
        }
    }
}
