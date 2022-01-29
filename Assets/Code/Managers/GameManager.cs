using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool IsPaused { get; private set; }
    private static Manager[] managers;
    private static UnityEvent onPause = new UnityEvent();

    public GameManager()
    {
        // Initializes the managers.
        managers = new Manager[]
        {
            new ActorManager(),
            new AudioReactManager()
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

    public static void Pause(bool pause)
    {
        for (int i = 0; i < managers.Length; i++)
        {
            managers[i].Pause(pause);
        }

        IsPaused = pause;
        onPause.Invoke();
    }

    public static void SubscribeToPause(UnityAction listener) 
    {
        onPause.AddListener(listener);
    }

    public static void UnSubscribeFromPause(UnityAction listener)
    {
        onPause.RemoveListener(listener);
    }
}
