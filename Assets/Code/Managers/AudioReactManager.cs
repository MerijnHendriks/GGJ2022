using AudioReact;

public class AudioReactManager : Manager
{
    public override void Update()
    {
        Sampler.OnUpdate();
    }
}
