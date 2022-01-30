using UnityEngine;

public class Actor : MonoBehaviour
{
    protected MoveDirection moveDirection;

    protected enum MoveDirection
    {
        MoveRight = 1, MoveLeft = -1
    }

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
