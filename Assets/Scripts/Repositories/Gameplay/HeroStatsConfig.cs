using Assets.Scripts.Domain.Gameplay.Models;
using UnityEngine;

namespace Assets.Scripts.Repositories.Gameplay
{
    [CreateAssetMenu(fileName = "HeroStatsConfig", menuName = "Configs/Hero Stats")]
    public class HeroStatsConfig : ScriptableObject
    {
        public HeroStatsModel BaseHeroStats;
    }
}
