using UnityEngine;

public class PlayButtonComponent : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.Instance.GetManager<SceneController>().LoadScene(EScenes.InGame);
    }
}
