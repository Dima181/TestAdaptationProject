using Assets.Scripts.Domain.Gameplay.Models;
using Assets.Scripts.Interfaces.Gameplay.Views;
using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Presentation.Gameplay.Views
{
    public class HeroUpgradeView : MonoBehaviour, IHeroView
    {
        private Label _levelLabel;
        private Label _strengthLabel;
        private Button _upgradeButton;

        private VisualElement _root;

        public void Show() => 
            _root.style.display = DisplayStyle.Flex;

        public void Hide() => 
            _root.style.display = DisplayStyle.None;

        private void Awake()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;
            _levelLabel = _root.Q<Label>("Level_text");
            _strengthLabel = _root.Q<Label>("Strength_text");
            _upgradeButton = _root.Q<Button>("Upgrade_button");
        }

        public void SubscribeButton(Action action) => 
            _upgradeButton.clicked += action;

        public void UnsubscribeButton(Action action) => 
            _upgradeButton.clicked -= action;

        public void UpdateStats(HeroStatsModel heroStatsModel)
        {
            _levelLabel.text = $"Level: {heroStatsModel.Level}";
            _strengthLabel.text = $"Strength: {heroStatsModel.Strength}";
        }
    }
}
