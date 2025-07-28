using Assets.Scripts.Domain.Gameplay.Messages;
using Assets.Scripts.Domain.Gameplay.Models;
using Assets.Scripts.Presentation.Gameplay.Views.HeroUpgrade;
using MessagePipe;
using R3;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.Presentation.Gameplay.Presenters.HeroUpgrade
{
    public class HeroUpgradePresenter : UIPresenterBase<HeroUpgradeView>
    {
        private readonly HeroModel _heroModel;
        private readonly IPublisher<UpgradeHeroDTO> _publisher;
        private readonly CompositeDisposable _disposables = new();

        [Inject]
        public HeroUpgradePresenter(HeroModel heroModel, IPublisher<UpgradeHeroDTO> publisher)
        {
            _heroModel = heroModel;
            _publisher = publisher;
        }

        protected override void OnStart()
        {
            _view.UpgradeButton.clicked += OnUpgradeClicked;

            _heroModel.Level
                .Subscribe(level => _view.LevelLabel.text = $"Level: {level}")
                .AddTo(_disposables);

            _heroModel.Strength
                .Subscribe(str => _view.StrengthLabel.text = $"Strength: {str}")
                .AddTo(_disposables);
        }

        private void OnUpgradeClicked()
        {
            _publisher.Publish(new UpgradeHeroDTO { Strength = 5 });
        }
    }
}
