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
        _data = Resources.LoadAll<PlatformData>(PlatformConfigsPath);
    }

    public Platform Get(PlatformType type)
    {
        Platform platform = _data.FirstOrDefault(i => i.Type == type).PlatformPrefab;

        if (platform == null)
            throw new ArgumentException($"Can't find {type} type platform");

        return Object.Instantiate(platform);
    }
}

public class PlatformCreator
{

}
