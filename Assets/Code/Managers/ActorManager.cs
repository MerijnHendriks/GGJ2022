using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorManager : Manager
{
    public static Player GetPlayer { get; private set; }
    private static Dictionary<int, Actor> actors = new Dictionary<int, Actor>();

    public override void Awake()
    {
        base.Awake();
    }

    public override void Pause(bool toggle)
    {
        base.Pause(toggle);
        foreach (Actor actor in actors.Values)
            actor.Pause(toggle);
    }

    public static Actor GetEntity(int identifier)
    {
        if (!actors.ContainsKey(identifier))
            return null;

        return actors[identifier];
    }

    public static T GetEntity<T>(int identifier) where T : class
    {
        if (!actors.ContainsKey(identifier))
            return null;

        return actors[identifier] as T;
    }

    public static void RegisterEntity(Actor actor)
    {
        if (actor == null || actors.ContainsKey(actor.gameObject.GetInstanceID()))
            return;

        if (actor.gameObject.tag == "Player")
            GetPlayer = (Player)actor;

        actors.Add(actor.gameObject.GetInstanceID(), actor);
    }

    public static void RemoveEntity(Actor actor)
    {
        if (actor == null || !actors.ContainsKey(actor.gameObject.GetInstanceID()))
            return;

        if (actor.gameObject.tag == "Player")
            GetPlayer = null;

        actors.Remove(actor.gameObject.GetInstanceID());
    }
}

