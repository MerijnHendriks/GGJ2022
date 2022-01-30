using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    [SerializeField]
    private GameObject[] hearts;
    private int heartCount;

    private void Awake()
    {
        heartCount = hearts.Length;
    }

    public void LoseHeart()
    {

        heartCount--;
        hearts[heartCount].gameObject.SetActive(false);

        if (heartCount == 1)
        {
            print("Die");
            GameManager.Instance.GetManager<SceneController>().LoadScene(EScenes.GameOver);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.transform);
        if (other.transform.tag == "Nian")
            LoseHeart();
    }
}
