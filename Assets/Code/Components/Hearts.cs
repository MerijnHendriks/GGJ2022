using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    [SerializeField]
    private GameObject[] hearts;
    private int heartCount;
    [SerializeField]
    private AudioSource hitAudio;

    private void Awake()
    {
        heartCount = hearts.Length;
    }

    public void LoseHeart()
    {
        hitAudio.Play();
        heartCount--;
        hearts[heartCount].gameObject.SetActive(false);

        if (heartCount == 0)
            GameManager.Instance.GetManager<SceneController>().LoadScene(EScenes.GameOver);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Nian")
            LoseHeart();
    }
}
