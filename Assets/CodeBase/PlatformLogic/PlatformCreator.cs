using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class PlatformCreator
{
    private PlatformFactory _factory;
    private List<Platform> _platforms = new List<Platform>();

    private float _stepY = 2;

    public float HighestPlatformY { get; private set; } = 4;

    [Inject]
    public PlatformCreator(PlatformFactory factory)
    {
        Debug.Log(GetType());

        _factory = factory;
    }

    public void SpawnPlatform()
    {
        Platform platform = GetPlatform(RandomPlatformType());

        platform.transform.position = new Vector3(Random.Range(-2f, 2f), HighestPlatformY + _stepY);

        HighestPlatformY = platform.transform.position.y;
    }

    private PlatformType RandomPlatformType() => (PlatformType)Random.Range(0, Enum.GetValues(typeof(PlatformType)).Length);
    
    private Platform GetPlatform(PlatformType type)
    {
        Platform platform = _platforms.FirstOrDefault(i => i.Type == type && i.gameObject.activeSelf == false);

        if (platform == null)
        {
            platform = _factory.Get(type);
            _platforms.Add(platform);
        }

        platform.gameObject.SetActive(true);

        return platform;
    }
}
