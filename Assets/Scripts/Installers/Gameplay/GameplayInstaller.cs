using Assets.Scripts.Domain.Gameplay.Models;
using Assets.Scripts.Interfaces.Gameplay.Repositories;
using Assets.Scripts.Interfaces.Gameplay.Views;
using Assets.Scripts.Presentation.Gameplay.Presenters;
using Assets.Scripts.Presentation.Gameplay.Views;
using Assets.Scripts.Repositories.Gameplay;
using Assets.Scripts.UseCases.Gameplay;
using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Assets.Scripts.Installers
{
    public class GameplayInstaller : LifetimeScope
    {
        [SerializeField] private HeroUpgradeView _heroUpgradeView;
        [SerializeField] private HeroStatsConfigRepository _heroStatsRepository;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterMessagePipe();

            builder.RegisterInstance<IHeroView>(_heroUpgradeView);
            builder.RegisterInstance<IHeroStatsRepository>(_heroStatsRepository);
            builder.Register<HeroModel>(Lifetime.Singleton);

            builder.RegisterEntryPoint<InitializeHeroUseCase>();
            builder.RegisterEntryPoint<UpgradeHeroUseCase>();

            builder.RegisterEntryPoint<HeroUpgradePresenter>();
        }
    }

}
