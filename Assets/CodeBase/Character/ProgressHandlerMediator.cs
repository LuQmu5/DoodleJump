using System;
using UnityEngine;
using Zenject;

public class ProgressHandlerMediator : IDisposable
{
    private CharacterProgressHandler _characterProgressHandler;
    private PlatformCreator _platformCreator;
    private GameConfig _gameConfig;

    [Inject]
    public ProgressHandlerMediator(CharacterProgressHandler characterProgressHandler, PlatformCreator platformCreator, GameConfig gameConfig)
    {
        _characterProgressHandler = characterProgressHandler;
        _platformCreator = platformCreator;
        _gameConfig = gameConfig;

        _characterProgressHandler.MaxHeightChanged += OnCharacterMaxHeightChanged;
    }

    public void Dispose()
    {
        _characterProgressHandler.MaxHeightChanged -= OnCharacterMaxHeightChanged;
    }

    private void OnCharacterMaxHeightChanged(float value)
    {
        if (_platformCreator.HighestPlatformY - _gameConfig.PlatformsMarginY < (value * 2))
            _platformCreator.SpawnPlatform();
    }
}