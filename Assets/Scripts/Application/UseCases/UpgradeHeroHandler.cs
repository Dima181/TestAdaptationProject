using Assets.Scripts.Domain.Gameplay.Messages;
using Assets.Scripts.Domain.Gameplay.Models;
using MessagePipe;
using R3;
using System;
using VContainer.Unity;

namespace Assets.Scripts.Application.UseCases
{
    public class UpgradeHeroHandler : IStartable, IDisposable
    {
        private readonly HeroModel _hero;
        private readonly ISubscriber<UpgradeHeroDTO> _subscriber;
        private readonly CompositeDisposable _disposables = new();

        public UpgradeHeroHandler(HeroModel hero, ISubscriber<UpgradeHeroDTO> subscriber)
        {
            _hero = hero;
            _subscriber = subscriber;
        }

        public void Start()
        {
            _subscriber
                .Subscribe(Handle)
                .AddTo(_disposables);
        }

        private void Handle(UpgradeHeroDTO message)
        {
            _hero.Level.Value += 1;
            _hero.Strength.Value += message.Strength;
        }

        public void Dispose() => 
            _disposables.Dispose();
    }
}
