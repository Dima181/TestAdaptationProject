using System;
using UnityEngine;

namespace Assets.Scripts.Domain.Gameplay.Models
{
    /// <summary>
    /// Статы героя
    /// </summary>
    [Serializable]
    public struct HeroStatsModel
    {
        [field: SerializeField] public int Level { get; set; }
        [field: SerializeField] public int Strength { get; set; }

        public HeroStatsModel(
            int level, 
            int strength)
        {
            Level = level;
            Strength = strength;
        }

        /// <summary>
        /// Добавляет возможность "складывать" статы из 2-х структур
        /// </summary>
        /// <param name="stats1">Статы на игроке</param>
        /// <param name="stats2">Статы, которые нужно добавить</param>
        /// <returns></returns>
        public static HeroStatsModel operator + (
            HeroStatsModel stats1, 
            HeroStatsModel stats2)
        {
            return new HeroStatsModel(
                stats1.Level += stats2.Level,
                stats1.Strength += stats2.Strength);
        }
    }
}
