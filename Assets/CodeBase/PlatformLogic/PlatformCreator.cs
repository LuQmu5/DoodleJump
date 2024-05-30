using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class PlatformCreator
{
    private const float BaseHighestPlatformY = 4;

    private GameFactory _factory;
    private List<Platform> _platforms = new List<Platform>();

    private float _stepY;
    private float _minX;
    private float _maxX;

    public float HighestPlatformY { get; private set; } = BaseHighestPlatformY;

    [Inject]
    public PlatformCreator(GameFactory factory, GameConfig gameConfig)
    {
        _factory = factory;

        float offsetX = 1;
        _minX = Camera.main.ScreenToWorldPoint(Vector3.zero).x + offsetX;
        _minX = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x - offsetX;
        _stepY = gameConfig.PlatformsMarginY;
    }

    public void SpawnPlatform()
    {
        Platform platform = GetPlatform(RandomPlatformType());

        platform.transform.position = new Vector3(Random.Range(_minX, _maxX) * Random.Range(-1f, 1f), HighestPlatformY + _stepY);

        HighestPlatformY = platform.transform.position.y;
    }

    private PlatformType RandomPlatformType() => (PlatformType)Random.Range(0, Enum.GetValues(typeof(PlatformType)).Length);
    
    private Platform GetPlatform(PlatformType type)
    {
        Platform platform = _platforms.FirstOrDefault(i => i.Type == type && i.gameObject.activeSelf == false);

        if (platform == null)
        {
            platform = _factory.GetPlatformByType(type);
            _platforms.Add(platform);
        }

        platform.gameObject.SetActive(true);

        return platform;
    }
}
