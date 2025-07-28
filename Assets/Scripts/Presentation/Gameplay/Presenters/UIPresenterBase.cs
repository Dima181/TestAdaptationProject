using Assets.Scripts.Presentation.Gameplay.Views;
using VContainer;
using VContainer.Unity;

namespace Assets.Scripts.Presentation.Gameplay.Presenters
{
    public abstract class UIPresenterBase<TView> : IStartable
        where TView : IView
    {
        [Inject] protected TView _view;

        public void Start() => 
            OnStart();

        protected abstract void OnStart();
    }
}
