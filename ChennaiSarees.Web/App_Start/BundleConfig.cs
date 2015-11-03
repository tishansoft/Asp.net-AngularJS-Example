using System.Web;
using System.Web.Optimization;

namespace ChennaiSarees.Web
{
  public class BundleConfig
  {
    // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
    public static void RegisterBundles(BundleCollection bundles)
    {
            bundles.Add(new ScriptBundle("~/bundles/angular")
                .Include("~/js/angular/angular.js")
                .Include("~/js/angular-route/angular-route.js")
                .Include("~/js/angular-resource/angular-resource.js", "~/js/toastr/toastr.js")
                .Include("~/js/app/app.js")
                .Include("~/js/app/api/apiPath.js")
                .Include("~/js/app/products/productsFilter.js")
                .Include("~/js/app/products/ProductsService.js")
                .Include("~/js/app/products/ProductsCtrl.js")
                .Include("~/js/app/ShoppingCart/shoppingCartCtrl.js")
                .Include("~/js/app/ShoppingCart/shoppingCartService.js", "~/js/jquery/jquery.js", "~/js/app/api/globalObjects.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery-{version}.js"));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
				  "~/Scripts/bootstrap.js"));

      // Use the development version of Modernizr to develop with and learn from. Then, when you're
      // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
      bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                  "~/Scripts/modernizr-*"));

      bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css", "~/js/toastr/toastr.css"));

      bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                  "~/Content/bootstrap/bootstrap.css"));
    }
  }
}