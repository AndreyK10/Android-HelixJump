using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int levelCount;
    public static int numberOfPlatforms { get; private set; }
    [SerializeField] private GameObject stick;

    [SerializeField] private SpawnPlatform spawnPlatform;
    [SerializeField] private FinishPlatform finishPlatform;
    [SerializeField] private Platform[] platform;

    [SerializeField] private List<Platform> platforms = new List<Platform>();

    private float startAndFinishAddSpace = 0.6f;

    [SerializeField] private float additionalScale = 0.5f;


    public float StickScaleY => levelCount / 2f + startAndFinishAddSpace + additionalScale / 2f;

    private void Awake()
    {
        levelCount = Random.Range(15, 30);
        Build();
        numberOfPlatforms = platforms.Count;
    }

    private void Build()
    {
        GameObject _stick = Instantiate(stick, transform);
        _stick.transform.localScale = new Vector3(1, StickScaleY, 1);

        Vector3 spawnPosition = _stick.transform.position;

        spawnPosition.y += _stick.transform.localScale.y - additionalScale;

        SpawnPlatform(spawnPlatform, ref spawnPosition);

        for (int i = 0; i < levelCount; i++)
        {
            SpawnPlatform(platform[Random.Range(0, platform.Length)], ref spawnPosition);
        }

        SpawnPlatform(finishPlatform, ref spawnPosition);

        foreach (Platform _platform in platforms)
        {
            _platform.gameObject.transform.SetParent(_stick.transform);
        }
    }

    private void SpawnPlatform(Platform _platform, ref Vector3 spawnPosition)
    {
        Platform pl = Instantiate(_platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0));
        platforms.Add(pl);
        spawnPosition.y -= 1f;
    }

}
