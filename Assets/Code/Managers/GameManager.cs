using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public bool IsPaused { get; private set; }
    private Manager[] managers;
    private UnityEvent onPause = new UnityEvent();

    // singleton
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }

            if (instance == null)
            {
                throw new Exception($"GameManager could not be found");
            }

            return instance;
        }
    }

    public GameManager()
    {
        managers = new Manager[]
        {
            new ActorManager(),
            new AudioReactManager(),
            new MusicManager(),
            new SceneController()
        };
    }

    private void Awake()
    {
        foreach (Manager item in managers)
        {
            item.Awake();
        }

        IsPaused = true;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        foreach (Manager item in managers)
        {
            item.Start();
        }
    }

    private void Update()
    {
        foreach (Manager item in managers)
        {
            item.Update();
        }
    }

    public T GetManager<T>() where T : Manager
    {
        foreach (Manager item in managers)
        {
            if (item.GetType() == typeof(T))
            {
                return (T)item;
            }
        }

        return null;
    }

    public void Pause(bool pause)
    {
        for (int i = 0; i < managers.Length; i++)
        {
            managers[i].Pause(pause);
        }

        IsPaused = pause;
        onPause.Invoke();
    }

    public void SubscribeToPause(UnityAction listener) 
    {
        onPause.AddListener(listener);
    }

    public void UnSubscribeFromPause(UnityAction listener)
    {
        onPause.RemoveListener(listener);
    }
}
