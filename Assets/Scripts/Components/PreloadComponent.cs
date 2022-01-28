using UnityEngine;

public class PreloadComponent : MonoBehaviour
{
    [SerializeField]
    private EScenes SceneToLoad;

    private void Start()
    {
        SceneController.LoadScene(SceneToLoad);
    }
}
