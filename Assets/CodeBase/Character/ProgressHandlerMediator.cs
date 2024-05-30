using System;

public class ProgressHandlerMediator : IDisposable
{
    private CharacterProgressHandler _characterProgressHandler;
    private PlatformCreator _platformCreator;

    public ProgressHandlerMediator(CharacterProgressHandler characterProgressHandler, PlatformCreator platformCreator)
    {
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