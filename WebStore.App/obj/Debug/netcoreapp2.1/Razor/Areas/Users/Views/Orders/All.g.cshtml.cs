#pragma checksum "C:\Users\User\Documents\Visual Studio 2017\Projects\WebStoreProject\WebStore.App\Areas\Users\Views\Orders\All.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "913d366755f2a42681ee5396119fde35aa7b3ee7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebStore.App.Areas.Users.Views.Orders.Areas_Users_Views_Orders_All), @"mvc.1.0.view", @"/Areas/Users/Views/Orders/All.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Users/Views/Orders/All.cshtml", typeof(WebStore.App.Areas.Users.Views.Orders.Areas_Users_Views_Orders_All))]
namespace WebStore.App.Areas.Users.Views.Orders
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\User\Documents\Visual Studio 2017\Projects\WebStoreProject\WebStore.App\Areas\Users\Views\_ViewImports.cshtml"
using WebStore.Common.UserCommon.ViewModels;

#line default
#line hidden
#line 2 "C:\Users\User\Documents\Visual Studio 2017\Projects\WebStoreProject\WebStore.App\Areas\Users\Views\_ViewImports.cshtml"
using WebStore.App.Helpers.Messages;

#line default
#line hidden
#line 3 "C:\Users\User\Documents\Visual Studio 2017\Projects\WebStoreProject\WebStore.App\Areas\Users\Views\_ViewImports.cshtml"
using WebStore.App.Extensions;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"913d366755f2a42681ee5396119fde35aa7b3ee7", @"/Areas/Users/Views/Orders/All.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de6a040d92e75414707129fe38d0cf1ecb1435d2", @"/Areas/Users/Views/_ViewImports.cshtml")]
    public class Areas_Users_Views_Orders_All : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<OrderConciseViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(43, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\User\Documents\Visual Studio 2017\Projects\WebStoreProject\WebStore.App\Areas\Users\Views\Orders\All.cshtml"
  
    ViewData["Title"] = "My Orders";

#line default
#line hidden
            BeginContext(90, 303, true);
            WriteLiteral(@"
<h2>My Orders</h2>

<table class=""table table-striped"">
    <thead>
        <tr>
            <th>Order Number</th>
            <th>Date</th>
            <th>Products Quantity</th>
            <th>Total Price</th>
            <th>Status</th>
        </tr>
    </thead>
    <tbody>
        ");
            EndContext();
            BeginContext(394, 22, false);
#line 20 "C:\Users\User\Documents\Visual Studio 2017\Projects\WebStoreProject\WebStore.App\Areas\Users\Views\Orders\All.cshtml"
   Write(Html.DisplayForModel());

#line default
#line hidden
            EndContext();
            BeginContext(416, 26, true);
            WriteLiteral("\r\n    </tbody>\r\n</table>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<OrderConciseViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
