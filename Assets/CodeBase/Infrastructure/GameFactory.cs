using System;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

public class GameFactory
{
    private const string PlatformConfigsPath = "StaticData/Platforms";

    private PlatformData[] _platformData;

    public GameFactory()
    {
        _platformData = Resources.LoadAll<PlatformData>(PlatformConfigsPath);
    }

    public Platform GetPlatformByType(PlatformType type)
    {
        PlatformData data = _platformData.FirstOrDefault(i => i.Type == type);

        if (data == null)
            throw new ArgumentException($"Can't find {type} type platform");

        Platform platform = Object.Instantiate(data.PlatformPrefab);
        platform.Init(data.Type, data.PushPower);

        return platform;
    }
}
