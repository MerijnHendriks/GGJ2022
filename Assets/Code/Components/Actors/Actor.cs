using UnityEngine;

public class Actor : MonoBehaviour
{
    protected virtual void Start()
    {
        ActorManager.RegisterEntity(this);
    }

    public virtual void Pause(bool toggle)
    {
    }

    protected virtual void OnDestroy()
    {
        ActorManager.RemoveEntity(this);
    }
}
