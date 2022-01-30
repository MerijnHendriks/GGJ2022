using UnityEngine.SceneManagement;

public enum EScenes
{
    // list your scenes here in build order!
    Prebuild = 0,
    MainMenu,
    Intro,
    InGame,
    GameWon,
    GameOver,
    Credits
}

public class SceneController : Manager
{
    public void LoadScene(EScenes scene)
    {
        SceneManager.LoadScene((int)scene);
    }
}