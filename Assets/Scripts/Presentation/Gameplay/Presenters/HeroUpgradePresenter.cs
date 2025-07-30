using Assets.Scripts.Domain.Gameplay.Messages;
using Assets.Scripts.Domain.Gameplay.Models;
using Assets.Scripts.Interfaces.Gameplay.Repositories;
using Assets.Scripts.Interfaces.Gameplay.Views;
using Cysharp.Threading.Tasks;
using MessagePipe;
using R3;
using System;
using VContainer.Unity;

namespace Assets.Scripts.Presentation.Gameplay.Presenters
{
    public class HeroUpgradePresenter : IStartable, IDisposable
    {
        private readonly IHeroView _view;
        private readonly IHeroStatsRepository _heroStats;
        private readonly IPublisher<UpgradeHeroDTO> _publisher;
        private readonly HeroModel _heroModel;

        private IDisposable _disposable;

        public HeroUpgradePresenter(
            IHeroView view, 
            IHeroStatsRepository heroStats, 
            HeroModel heroModel, 
            IPublisher<UpgradeHeroDTO> publisher)
        {
            _view = view;
            _heroStats = heroStats;
            _heroModel = heroModel;
            _publisher = publisher;
        }

        public void Start()
        {
            _view.UpdateStats(_heroStats.GetBaseHeroStats());

            _view.SubscribeButton(OnUpgradeClicked);

            var disposableBag = MessagePipe.DisposableBag.CreateBuilder();

            _heroModel.Stats
                .Subscribe(_view.UpdateStats)
                .AddTo(disposableBag);

            _disposable = disposableBag.Build();
        }

        private void OnUpgradeClicked()
        {
            _publisher.Publish(new UpgradeHeroDTO
            {
                Stats = new HeroStatsModel(level: 1, strength: 10)
            });
        }

        public void Dispose()
        {
            _disposable?.Dispose();
            _view.UnsubscribeButton(OnUpgradeClicked);
        }
    }
}
