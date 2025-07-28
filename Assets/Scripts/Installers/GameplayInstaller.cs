using UnityEngine;
using VContainer.Unity;
using VContainer;
using Assets.Scripts.Presentation.Gameplay.Views.HeroUpgrade;
using Assets.Scripts.Presentation.Gameplay.Presenters.HeroUpgrade;
using Assets.Scripts.Domain.Gameplay.Messages;
using Assets.Scripts.Application.UseCases;
using Assets.Scripts.Domain.Gameplay.Models;
using MessagePipe;

namespace Assets.Scripts.Installers
{
    public class GameplayInstaller : LifetimeScope
    {
        [SerializeField] private HeroUpgradeView _heroUpgradeView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterMessagePipe();

            builder.RegisterInstance(_heroUpgradeView);
            builder.Register<HeroModel>(Lifetime.Singleton);

            builder.Register<UpgradeHeroHandler>(Lifetime.Singleton)
                   .As<IAsyncSubscriber<UpgradeHeroDTO>>();

            builder.RegisterEntryPoint<HeroUpgradePresenter>();
        }
    }

}
