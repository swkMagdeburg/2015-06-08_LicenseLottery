using Microsoft.Practices.Unity;

namespace LicenseLottery.UI.Wpf
{
    internal static class Bootstrapper
    {
        public static IUnityContainer GenerateContainer()
        {
            var container = new UnityContainer();
            container.RegisterTypes(AllClasses.FromAssembliesInBasePath(), WithMappings.FromMatchingInterface);
            return container;
        }
    }
}
