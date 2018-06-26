using Neutronium.Core.Navigation.Routing;
using DriveExplorer.Application.Navigation;

namespace DriveExplorer {
    public class RoutingConfiguration {
        public static IRouterSolver Register() {
            var router = new Router();
            BuildRoutes(router);
            return router;
        }

        private static void BuildRoutes(IRouterBuilder routeBuilder) {
            var convention = routeBuilder.GetTemplateConvention("{vm}");
            typeof(RoutingConfiguration).GetTypesFromSameAssembly()
                .InNamespace("DriveExplorer.ViewModel.Pages")
                .Register(convention);
        }
    }
}
