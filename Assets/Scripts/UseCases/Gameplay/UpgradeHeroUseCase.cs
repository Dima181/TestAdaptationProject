using Assets.Scripts.Domain.Gameplay.Messages;
using Assets.Scripts.Domain.Gameplay.Models;
using MessagePipe;
using System;
using VContainer.Unity;

namespace Assets.Scripts.UseCases.Gameplay
{
    public class UpgradeHeroUseCase : IStartable, IDisposable
    {
        private readonly HeroModel _hero;
        private readonly ISubscriber<UpgradeHeroDTO> _subscriber;

        private IDisposable _disposable;

        public UpgradeHeroUseCase(
            HeroModel hero, 
            ISubscriber<UpgradeHeroDTO> subscriber)
        {
            _hero = hero;
            _subscriber = subscriber;
        }

        public void Start()
        {
            var disposableBag = DisposableBag.CreateBuilder();

            _subscriber
                .Subscribe(Handle)
                .AddTo(disposableBag);

            _disposable = disposableBag.Build();
        }

        private void Handle(UpgradeHeroDTO message) => 
            _hero.Stats.Value += message.Stats;

        public void Dispose() =>
            _disposable.Dispose();
    }
}
