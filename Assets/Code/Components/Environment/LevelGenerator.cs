using System.Collections;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private Texture2D map;

    [SerializeField]
    private Portal portal;
    [SerializeField]
    private GameObject platform;
    private Vector2 platformSize = new Vector2(2.5f, 2.5f);

    private void Awake()
    {
        Generate();
        SpawnPortals(10);
    }

    private void Generate()
    {
        Color[] pixels = map.GetPixels();
        int index = 0;
        for (int y = 0; y < map.height; y++)
        {
            for (int x = 0; x < map.width; x++)
            {
                if (pixels[index].r == 1)
                    SpawnPlatform(x, y);
                index++;
            }
        }
    }

    private void SpawnPlatform(int x, int y)
    {
        Vector2 startPosition = new Vector2(-map.width * platformSize.x * 0.5f + platformSize.x * 0.5f, 0);
        Vector2 position = new Vector2(platformSize.x * x, platformSize.y * y);
        Instantiate(platform, startPosition + position, Quaternion.identity);
    }

    private void SpawnPortals(int floors)
    {
        Vector3 leftPortalPosition = Vector3.zero;
        Portal rightPortal;

        for (int i = floors - 1; i >= 0; i--)
        {
            if (i != floors)
            {
                rightPortal = Instantiate(portal, new Vector3(11.75f, i * 10 + 0.25f, 0), Quaternion.identity);
                rightPortal.SetNextPortal(leftPortalPosition);
            }
            if (i != 0)
            {
                Portal leftPortal = Instantiate(portal, new Vector3(-11.75f, i * 10 + 0.25f, 0), Quaternion.identity);
                leftPortalPosition = leftPortal.transform.position;
                leftPortal.Disable();
            }
        }
    }
}
