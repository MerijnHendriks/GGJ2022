using UnityEngine;

public class PreloadComponent : MonoBehaviour
{
    [SerializeField]
    private EScenes SceneToLoad;

    private void Start()
    {
        GameManager.Instance.GetManager<SceneController>().LoadScene(SceneToLoad);
    }
}
