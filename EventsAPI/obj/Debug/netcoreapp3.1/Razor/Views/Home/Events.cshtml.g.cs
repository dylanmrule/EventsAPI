#pragma checksum "C:\Users\grand\source\EventsAPI\EventsAPI\Views\Home\Events.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c196b6e28dde45fb7918ae7c9451c86d094f1be8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Events), @"mvc.1.0.view", @"/Views/Home/Events.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\grand\source\EventsAPI\EventsAPI\Views\_ViewImports.cshtml"
using EventsAPI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\grand\source\EventsAPI\EventsAPI\Views\_ViewImports.cshtml"
using EventsAPI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c196b6e28dde45fb7918ae7c9451c86d094f1be8", @"/Views/Home/Events.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"72d58bf7beff1409b0abdf2384bf120f5b8a4f34", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Events : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EventsResponse>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\grand\source\EventsAPI\EventsAPI\Views\Home\Events.cshtml"
 if (Model.Events != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1>Number of results: ");
#nullable restore
#line 5 "C:\Users\grand\source\EventsAPI\EventsAPI\Views\Home\Events.cshtml"
                      Write(Model.Events.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
#nullable restore
#line 6 "C:\Users\grand\source\EventsAPI\EventsAPI\Views\Home\Events.cshtml"
     for (int i = 0; i < Model.Events.Count; i++)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h3>");
#nullable restore
#line 8 "C:\Users\grand\source\EventsAPI\EventsAPI\Views\Home\Events.cshtml"
       Write(Model.Events[i].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n        <p> ");
#nullable restore
#line 9 "C:\Users\grand\source\EventsAPI\EventsAPI\Views\Home\Events.cshtml"
       Write(Model.Events[i].Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p>Ticket Prices: $");
#nullable restore
#line 10 "C:\Users\grand\source\EventsAPI\EventsAPI\Views\Home\Events.cshtml"
                      Write(Model.Events[i].PriceRanges[0].Min);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - $");
#nullable restore
#line 10 "C:\Users\grand\source\EventsAPI\EventsAPI\Views\Home\Events.cshtml"
                                                             Write(Model.Events[i].PriceRanges[0].Max);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p>");
#nullable restore
#line 11 "C:\Users\grand\source\EventsAPI\EventsAPI\Views\Home\Events.cshtml"
      Write(Model.Events[i].Dates.Status.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 12 "C:\Users\grand\source\EventsAPI\EventsAPI\Views\Home\Events.cshtml"
         if (Model.Events[i].Info != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p>Description: ");
#nullable restore
#line 14 "C:\Users\grand\source\EventsAPI\EventsAPI\Views\Home\Events.cshtml"
                       Write(Model.Events[i].Info);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 15 "C:\Users\grand\source\EventsAPI\EventsAPI\Views\Home\Events.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>Type of Event: ");
#nullable restore
#line 17 "C:\Users\grand\source\EventsAPI\EventsAPI\Views\Home\Events.cshtml"
                     Write(Model.Events[i].Classifications[0].Segment.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 18 "C:\Users\grand\source\EventsAPI\EventsAPI\Views\Home\Events.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\grand\source\EventsAPI\EventsAPI\Views\Home\Events.cshtml"
     
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Those parameters are not compatible with the API.</p>\r\n");
#nullable restore
#line 23 "C:\Users\grand\source\EventsAPI\EventsAPI\Views\Home\Events.cshtml"
}

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c196b6e28dde45fb7918ae7c9451c86d094f1be86881", async() => {
                WriteLiteral("Try again");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EventsResponse> Html { get; private set; }
    }
}
#pragma warning restore 1591
