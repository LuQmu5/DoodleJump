using System;
using UnityEngine;
using Zenject;

public class ProgressHandlerMediator : IDisposable
{
    private CharacterProgressHandler _characterProgressHandler;
    private PlatformCreator _platformCreator;

    [Inject]
    public ProgressHandlerMediator(CharacterProgressHandler characterProgressHandler, PlatformCreator platformCreator)
    {
        Debug.Log(GetType());

        _characterProgressHandler = characterProgressHandler;
        _platformCreator = platformCreator;

        _characterProgressHandler.MaxHeightChanged += OnCharacterMaxHeightChanged;
    }

    public void Dispose()
    {
        _characterProgressHandler.MaxHeightChanged -= OnCharacterMaxHeightChanged;
    }

    private void OnCharacterMaxHeightChanged(float value)
    {
        if (value > _platformCreator.HighestPlatformY - 4)
        {
            _platformCreator.SpawnPlatform();
        }
    }
}