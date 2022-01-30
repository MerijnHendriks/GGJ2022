using UnityEngine;

public class MusicComponent : MonoBehaviour
{
    [SerializeField]
    private ETracks track;

    public void Start()
    {
        GameManager.Instance.GetManager<MusicManager>().Play(track);
    }
}