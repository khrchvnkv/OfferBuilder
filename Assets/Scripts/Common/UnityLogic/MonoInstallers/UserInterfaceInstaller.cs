using Common.UnityLogic.UI.LoadingScreen;
using UnityEngine;
using Zenject;

namespace Common.UnityLogic.MonoInstallers
{
    public class UserInterfaceInstaller : MonoInstaller
    {
        [SerializeField] private LoadingCurtain _loadingCurtain;
        
        public override void InstallBindings()
        {
            InstallCore();
        }

        private void InstallCore()
        {
            Container.Bind<LoadingCurtain>().FromInstance(_loadingCurtain);
        }
    }
}