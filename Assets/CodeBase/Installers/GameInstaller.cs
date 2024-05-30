using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    private const string GameSettingsConfigPath = "StaticData/GameSettings/GameConfig";

    public override void InstallBindings()
    {
        GameConfig gameConfig = Resources.Load<GameConfig>(GameSettingsConfigPath);
        Container.BindInstance(gameConfig).AsSingle().NonLazy();

        Container.Bind<GameFactory>().AsSingle().NonLazy();
        Container.Bind<PlatformCreator>().AsSingle().NonLazy();
        Container.Bind<CharacterProgressHandler>().AsSingle().NonLazy();
        Container.Bind<ProgressHandlerMediator>().AsSingle().NonLazy();
    }
}
