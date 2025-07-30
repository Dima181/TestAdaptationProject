using Assets.Scripts.Domain.Gameplay.Models;
using Assets.Scripts.Interfaces.Gameplay.Repositories;
using UnityEngine;

namespace Assets.Scripts.Repositories.Gameplay
{
    public class HeroStatsConfigRepository : MonoBehaviour, IHeroStatsRepository
    {
        [field: SerializeField] public HeroStatsConfig Config { get; private set; }

        public HeroStatsModel GetBaseHeroStats() =>
            Config.BaseHeroStats;
    }
}
