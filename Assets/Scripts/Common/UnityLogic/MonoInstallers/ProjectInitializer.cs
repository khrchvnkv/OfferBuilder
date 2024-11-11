using Common.Infrastructure;
using Common.Infrastructure.UI;
using UnityEngine;
using Zenject;

namespace Common.UnityLogic.MonoInstallers
{
    public class ProjectInitializer : MonoInstaller, IInitializable
    {
        [SerializeField] private GameBootstrapper _gameBootstrapper;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo(GetType()).FromInstance(this);
        }

        void IInitializable.Initialize()
        {
            SetupUI();
            RunGame();
        }

        private void SetupUI() => 
            Container.Resolve<IScreenManager>().Resolve(Container);

        private void RunGame()
        {
            Container.Inject(_gameBootstrapper);
            _gameBootstrapper.RunGame();
        }
    }
}