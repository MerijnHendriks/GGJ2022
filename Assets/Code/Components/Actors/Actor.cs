using System.Collections;
using System.Collections.Generic;
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
