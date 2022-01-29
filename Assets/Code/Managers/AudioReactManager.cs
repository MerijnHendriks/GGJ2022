using System.Collections.Generic;
using UnityEngine;
using AudioReact;

public class AudioReactManager : Manager
{
    public override void Awake()
    {
        Sampler.Instance.OnInitialize();
    }

    public override void Update()
    {
        Sampler.Instance.OnUpdate();
    }
}
