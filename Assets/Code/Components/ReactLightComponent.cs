using UnityEngine;
using AudioReact;

public class ReactLightComponent : MonoBehaviour
{
    [SerializeField]
    private ReactBehaviour React = new ReactBehaviour()
    {
        Sensitivity = 2.0f,
        ClampMin = 0.5f,
        ClampMax = 4.0f,
        Smoothing = 0.5f
    };

    [SerializeField]
    private Light Light;

    private void Update()
    {
        Light.intensity = React.GetSample();
    }
}
