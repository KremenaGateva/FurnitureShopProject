#pragma checksum "C:\Users\User\Documents\Visual Studio 2017\Projects\WebStoreProject\WebStore.App\Pages\Contact.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a8a9add2b7f19e167ce258f7d4242be1c595415a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebStore.App.Pages.Pages_Contact), @"mvc.1.0.razor-page", @"/Pages/Contact.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Contact.cshtml", typeof(WebStore.App.Pages.Pages_Contact), null)]
namespace WebStore.App.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\User\Documents\Visual Studio 2017\Projects\WebStoreProject\WebStore.App\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\User\Documents\Visual Studio 2017\Projects\WebStoreProject\WebStore.App\Pages\_ViewImports.cshtml"
using WebStore.App.Helpers;

#line default
#line hidden
#line 3 "C:\Users\User\Documents\Visual Studio 2017\Projects\WebStoreProject\WebStore.App\Pages\_ViewImports.cshtml"
using WebStore.Models;

#line default
#line hidden
#line 4 "C:\Users\User\Documents\Visual Studio 2017\Projects\WebStoreProject\WebStore.App\Pages\_ViewImports.cshtml"
using WebStore.Common.Anonymous.ViewModels;

#line default
#line hidden
#line 5 "C:\Users\User\Documents\Visual Studio 2017\Projects\WebStoreProject\WebStore.App\Pages\_ViewImports.cshtml"
using WebStore.App.Helpers.Messages;

#line default
#line hidden
#line 6 "C:\Users\User\Documents\Visual Studio 2017\Projects\WebStoreProject\WebStore.App\Pages\_ViewImports.cshtml"
using WebStore.App.Extensions;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8a9add2b7f19e167ce258f7d4242be1c595415a", @"/Pages/Contact.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e50d199ef5f32e89c2218c3c378d6f987394e438", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Contact : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\User\Documents\Visual Studio 2017\Projects\WebStoreProject\WebStore.App\Pages\Contact.cshtml"
  
    ViewData["Title"] = "Contact";

#line default
#line hidden
            BeginContext(71, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(73, 1954, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6bc584a69c3f417d8d3b141524c996a4", async() => {
                BeginContext(79, 114, true);
                WriteLiteral("\r\n    <section id=\"contact\">\r\n        <div class=\"container\">\r\n            <h3 class=\"text-center text-uppercase\">");
                EndContext();
                BeginContext(194, 13, false);
#line 10 "C:\Users\User\Documents\Visual Studio 2017\Projects\WebStoreProject\WebStore.App\Pages\Contact.cshtml"
                                              Write(Model.Message);

#line default
#line hidden
                EndContext();
                BeginContext(207, 1813, true);
                WriteLiteral(@"</h3>
            <p class=""text-center w-75 m-auto"">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris interdum purus at sem ornare sodales. Morbi leo nulla, pharetra vel felis nec, ullamcorper condimentum quam.</p>
            <div class=""row"">
                <div class=""col-sm-12 col-md-6 col-lg-5 my-5"">
                    <div class=""card border-0"">
                        <div class=""card-body text-center"">
                            <i class=""fa fa-phone fa-5x mb-3"" aria-hidden=""true""></i>
                            <h4 class=""text-uppercase mb-5"">call us</h4>
                            <p>+8801683615582,+8801750603409</p>
                        </div>
                    </div>
                </div>
                <div class=""col-sm-12 col-md-6 col-lg-3 my-5"">
                    <div class=""card border-0"">
                        <div class=""card-body text-center"">
                            <i class=""fa fa-map-marker fa-5x mb-3"" aria-hidden=""true""></i>
          ");
                WriteLiteral(@"                  <h4 class=""text-uppercase mb-5"">office loaction</h4>
                            <address>Suite 02, Level 12, Sahera Tropical Center </address>
                        </div>
                    </div>
                </div>
                <div class=""col-sm-12 col-md-6 col-lg-3 my-5"">
                    <div class=""card border-0"">
                        <div class=""card-body text-center"">
                            <i class=""fa fa-globe fa-5x mb-3"" aria-hidden=""true""></i>
                            <h4 class=""text-uppercase mb-5"">email</h4>
                            <p>http://al.a.noman1416@gmail.com</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ContactModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ContactModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ContactModel>)PageContext?.ViewData;
        public ContactModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
