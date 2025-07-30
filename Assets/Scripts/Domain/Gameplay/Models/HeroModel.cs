using R3;

namespace Assets.Scripts.Domain.Gameplay.Models
{
    public class HeroModel
    {
        public ReactiveProperty<HeroStatsModel> Stats { get; private set; } = new();
    }
}
