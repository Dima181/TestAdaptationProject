using Assets.Scripts.Domain.Gameplay.Models;
using Assets.Scripts.Interfaces.Gameplay.Repositories;
using VContainer.Unity;

namespace Assets.Scripts.UseCases.Gameplay
{
    public class InitializeHeroUseCase : IStartable
    {
        private readonly HeroModel _heroModel;
        private readonly IHeroStatsRepository _heroCharacteristicsRepository;

        public InitializeHeroUseCase(
            HeroModel heroModel, 
            IHeroStatsRepository heroCharacteristicsRepository)
        {
            _heroModel = heroModel;
            _heroCharacteristicsRepository = heroCharacteristicsRepository;
        }

        public void Start() => 
            _heroModel.Stats.Value = _heroCharacteristicsRepository.GetBaseHeroStats();
    }
}
