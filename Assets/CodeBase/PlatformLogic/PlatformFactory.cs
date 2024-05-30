using System;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

public class PlatformFactory
{
    private const string PlatformConfigsPath = "StaticData/Platforms";

    private PlatformData[] _data;

    public PlatformFactory()
    {
        Debug.Log(GetType());

        _data = Resources.LoadAll<PlatformData>(PlatformConfigsPath);
    }

    public Platform Get(PlatformType type)
    {
        PlatformData data = _data.FirstOrDefault(i => i.Type == type);

        if (data == null)
            throw new ArgumentException($"Can't find {type} type platform");

        Platform platform = Object.Instantiate(data.PlatformPrefab);
        platform.Init(data.Type, data.PushPower);

        return platform;
    }
}
