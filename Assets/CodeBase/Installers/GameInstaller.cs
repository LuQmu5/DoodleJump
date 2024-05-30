using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlatformFactory>().AsSingle().NonLazy();
        Container.Bind<PlatformCreator>().AsSingle().NonLazy();
        Container.Bind<CharacterProgressHandler>().AsSingle().NonLazy();
        Container.Bind<ProgressHandlerMediator>().AsSingle().NonLazy();
    }
}