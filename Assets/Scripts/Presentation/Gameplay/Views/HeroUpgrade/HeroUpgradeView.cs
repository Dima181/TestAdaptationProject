using UnityEngine.UIElements;
using UnityEngine;

namespace Assets.Scripts.Presentation.Gameplay.Views.HeroUpgrade
{
    public class HeroUpgradeView : MonoBehaviour, IView
    {
        public Label LevelLabel => root.Q<Label>("Level_text");
        public Label StrengthLabel => root.Q<Label>("Strength_text");
        public Button UpgradeButton => root.Q<Button>("Upgrade_button");

        private VisualElement root;

        public void Show() => root.style.display = DisplayStyle.Flex;
        public void Hide() => root.style.display = DisplayStyle.None;

        private void Awake()
        {
            root = GetComponent<UIDocument>().rootVisualElement;
        }
    }
}
