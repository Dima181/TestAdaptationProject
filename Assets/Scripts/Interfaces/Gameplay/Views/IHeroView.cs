using Assets.Scripts.Domain.Gameplay.Models;
using R3;
using System;

namespace Assets.Scripts.Interfaces.Gameplay.Views
{
    public interface IHeroView
    {
        void SubscribeButton(Action action);
        void UnsubscribeButton(Action action);

        /// <summary>
        /// Метод обновляет статы во View
        /// </summary>
        /// <param name="heroStatsModel">Передаем структуру со статами героя</param>
        void UpdateStats(HeroStatsModel heroStatsModel);
    }
}
