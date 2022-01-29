using UnityEngine;
using AudioReact;

public class ReactTrackComponent : MonoBehaviour
{
    [SerializeField]
    private AudioSource Track;

    private void Awake()
    {
        Sampler.Instance.AudioSource = Track;
    }
}
