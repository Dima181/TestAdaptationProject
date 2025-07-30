using Assets.Scripts.Domain.Gameplay.Models;

namespace Assets.Scripts.Interfaces.Gameplay.Repositories
{
    public interface IHeroStatsRepository
    {
        /// <summary>
        /// Метод возвращает структуру со статами из конфига
        /// </summary>
        /// <returns></returns>
        HeroStatsModel GetBaseHeroStats();
    }
}
