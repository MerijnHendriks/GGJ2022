using UnityEngine;
using UnityEngine.SceneManagement;

public enum EScenes
{
    // list your scenes here in build order!
    Prebuild = 0,
    MainMenu
}

public static class SceneController
{
    public static void LoadScene(EScenes scene)
    {
        SceneManager.LoadScene((int)scene);
    }
}