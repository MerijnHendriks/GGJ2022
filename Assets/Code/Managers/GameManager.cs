using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool IsPaused { get; private set; }

    private static Manager[] s_managers;

    private static UnityEvent s_onPause = new UnityEvent();

    public GameManager()
    {
        // Initializes the managers.
        s_managers = new Manager[]
        {
        };
    }

    private void Awake()
    {
        foreach (Manager item in s_managers)
            item.Awake();

        IsPaused = true;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        foreach (Manager item in s_managers)
            item.Start();
    }

    private void Update()
    {
        foreach (Manager item in s_managers)
            item.Update();
    }

    public static void Pause(bool pause)
    {
        for (int i = 0; i < s_managers.Length; i++)
            s_managers[i].Pause(pause);
            
        IsPaused = pause;
        s_onPause.Invoke();
    }

    public static void SubscribeToPause(UnityAction listener) => s_onPause.AddListener(listener);

    public static void UnSubscribeFromPause(UnityAction listener) => s_onPause.RemoveListener(listener);

}
