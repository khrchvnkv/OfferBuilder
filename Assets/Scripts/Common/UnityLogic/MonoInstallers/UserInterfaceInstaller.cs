using System.Linq;
using System.Reflection;
using Common.Infrastructure.UI;
using Common.UnityLogic.UI.LoadingScreen;
using Common.UnityLogic.UI.Offer;
using Common.UnityLogic.UI.OfferConstructor;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Common.UnityLogic.MonoInstallers
{
    public class UserInterfaceInstaller : MonoInstaller
    {
        [SerializeField, Required] private LoadingCurtain _loadingCurtain;
        [SerializeField, Required] private OfferConstructorView _offerConstructorView;
        [SerializeField, Required] private OfferView _offerView;
        
        public override void InstallBindings()
        {
            InstallCore();
            InstallScreens();
            InstallViews();
        }

        private void InstallCore()
        {
            Container.Bind<LoadingCurtain>().FromInstance(_loadingCurtain);
        }

        private void InstallScreens()
        {
            var types = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(IScreen).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);
            
            foreach (var type in types)
            {
                Container.BindInterfacesAndSelfTo(type).AsCached();
            }
        }
        
        private void InstallViews()
        {
            Container.BindInterfacesAndSelfTo<OfferConstructorView>().FromInstance(_offerConstructorView);
            Container.BindInterfacesAndSelfTo<OfferView>().FromInstance(_offerView);
        }
    }
}