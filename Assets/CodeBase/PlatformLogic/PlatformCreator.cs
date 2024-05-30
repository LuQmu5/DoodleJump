using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

public class PlatformCreator
{
    private const float StepY = 2;
    private const float BaseHighestPlatformY = 4;

    private PlatformFactory _factory;
    private List<Platform> _platforms = new List<Platform>();

    public float HighestPlatformY { get; private set; } = BaseHighestPlatformY;

    public void SpawnPlatform()
    {
        Platform platform = GetPlatform(RandomPlatformType());

        platform.transform.position.SetY(HighestPlatformY + StepY);
        platform.transform.position.SetRandomXOnScreen();

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
