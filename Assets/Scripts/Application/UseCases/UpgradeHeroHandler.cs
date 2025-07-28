using Assets.Scripts.Domain.Gameplay.Messages;
using Assets.Scripts.Domain.Gameplay.Models;
using MessagePipe;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Application.UseCases
{
    public class UpgradeHeroHandler : IMessageHandler<UpgradeHeroDTO>
    {
        private readonly HeroModel _hero;

        public UpgradeHeroHandler(HeroModel hero)
        {
            _hero = hero;
        }

        public void Handle(UpgradeHeroDTO message)
        {
            _hero.Level.Value += 1;
            _hero.Strength.Value += message.Strength;
            Debug.Log("UpgradeHeroHandler: обработал сообщение");
        }
    }
}
