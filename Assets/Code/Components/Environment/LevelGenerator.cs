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

    [SerializeField]
    private GameObject smallJump;
    [SerializeField]
    private GameObject bigJump;

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
                if (pixels[index].b == 1)
                    SpawnBigJump(x, y);
                if (pixels[index].g == 1)
                    SpawnSmallJump(x, y);
                index++;
            }
        }
    }

    private void SpawnPlatform(int x, int y)
    {
        Vector2 startPosition = new Vector2(-map.width * platformSize.x * 0.5f + platformSize.x * 0.5f, 0);
        Vector2 position = new Vector2(platformSize.x * x, platformSize.y * y);
        Instantiate(platform, startPosition + position, Quaternion.identity, transform);
    }

    private void SpawnSmallJump(int x, int y)
    {
        Vector2 startPosition = new Vector2(-map.width * platformSize.x * 0.5f + platformSize.x * 0.5f, 0);
        Vector2 position = new Vector2(platformSize.x * x, platformSize.y * y);
        Instantiate(smallJump, startPosition + position, Quaternion.identity, transform);
    }

    private void SpawnBigJump(int x, int y)
    {
        Vector2 startPosition = new Vector2(-map.width * platformSize.x * 0.5f + platformSize.x * 0.5f, 0);
        Vector2 position = new Vector2(platformSize.x * x + platformSize.x * 0.5f, platformSize.y * y);
        Instantiate(bigJump, startPosition + position, Quaternion.identity, transform);
    }

    private void SpawnPortals(int floors)
    {
        Portal leftPortal = null;// = Vector3.zero;
        Portal rightPortal = null;

        for (int i = floors - 1; i >= 0; i--)
        {
            if (i != floors)
            {
                rightPortal = Instantiate(portal, new Vector3(11.75f, i * 10 + 0.25f, 0), Quaternion.identity, transform);
                rightPortal.transform.rotation = Quaternion.Euler(0, 180, 0);
                rightPortal.SetNextPortal(leftPortal);
            }
            if (i != 0)
            {
                Portal instance = Instantiate(portal, new Vector3(-11.75f, i * 10 + 0.25f, 0), Quaternion.identity, transform);
                leftPortal = instance;
                leftPortal.SetLeftPortal(rightPortal);
                leftPortal.Disable();
            }
        }
    }
}
