using UnityEngine;

public class ButtonComponent : MonoBehaviour
{
    private SceneController sceneController;

    private void Start()
    {
        sceneController = GameManager.Instance.GetManager<SceneController>();
    }

    public void OnClickPlay()
    {
        sceneController.LoadScene(EScenes.Intro);
    }

    public void OnClickReady()
    {
        sceneController.LoadScene(EScenes.InGame);
    }

    public void OnClickCredits()
    {
        sceneController.LoadScene(EScenes.Credits);
    }

    public void OnClickReturn()
    {
        sceneController.LoadScene(EScenes.MainMenu);
    }

    public void OnClickLocale()
    {
        if (LocaleController.Locale == ELocales.English)
        {
            // switch to chinese
            LocaleController.Locale = ELocales.Chinese;
        }
        else
        {
            // switch to english
            LocaleController.Locale = ELocales.English;
        }
    }
}
