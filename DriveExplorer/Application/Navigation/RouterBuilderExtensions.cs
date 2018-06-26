using Neutronium.Core.Navigation.Routing;

namespace DriveExplorer.Application.Navigation {
    public static class RouterBuilderExtensions {
        public static IConventionRouter GetTemplateConvention(this IRouterBuilder routerBuilder, string template) {
            return new ConventionRouter(routerBuilder, template);
        }
    }
}
