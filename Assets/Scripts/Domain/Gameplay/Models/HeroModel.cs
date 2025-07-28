using R3;

namespace Assets.Scripts.Domain.Gameplay.Models
{
    public class HeroModel
    {
        public ReactiveProperty<int> Level { get; set; } = new(1);
        public ReactiveProperty<int> Strength { get; set; } = new(10);
    }
}
