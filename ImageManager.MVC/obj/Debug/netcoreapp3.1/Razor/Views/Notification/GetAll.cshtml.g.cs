#pragma checksum "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\GetAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e635ade0986b6ef8695c95e61f5ebb15d9680aac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Notification_GetAll), @"mvc.1.0.view", @"/Views/Notification/GetAll.cshtml")]
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
#line 1 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\_ViewImports.cshtml"
using ImageManager.MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\_ViewImports.cshtml"
using ImageManager.MVC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\GetAll.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e635ade0986b6ef8695c95e61f5ebb15d9680aac", @"/Views/Notification/GetAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5706fa34018548bef22ecc506d5e88bcea4b523a", @"/Views/_ViewImports.cshtml")]
    public class Views_Notification_GetAll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ImageManager.MVC.ViewModels.NotificationViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ShowImage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Notification", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 6 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\GetAll.cshtml"
  
    ViewBag.Title = Localizer["Notification"];

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"container body-content\">\r\n    <div class=\"col\">\r\n        <div class=\"text-center m-sm-1\">\r\n            <p class=\"display-4\">");
#nullable restore
#line 14 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\GetAll.cshtml"
                            Write(Localizer["Notification"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p>\r\n                ");
#nullable restore
#line 16 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\GetAll.cshtml"
           Write(Localizer["NotificationInstruction"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </p>\r\n        </div>\r\n        <br />\r\n        <div>\r\n");
#nullable restore
#line 21 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\GetAll.cshtml"
             foreach (var item in Model)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\GetAll.cshtml"
                 if (item.HasRead)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div");
            BeginWriteAttribute("name", " name=\"", 655, "\"", 682, 1);
#nullable restore
#line 25 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\GetAll.cshtml"
WriteAttributeValue("", 662, item.NotificationId, 662, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"text-sm-left td-notice-read p-sm-3 mb-sm-1\"");
            BeginWriteAttribute("onclick", " onclick=\"", 734, "\"", 786, 3);
            WriteAttributeValue("", 744, "notification_click(\'", 744, 20, true);
#nullable restore
#line 25 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\GetAll.cshtml"
WriteAttributeValue("", 764, item.NotificationId, 764, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 784, "\')", 784, 2, true);
            EndWriteAttribute();
            WriteLiteral(" )>\r\n                        ");
#nullable restore
#line 26 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\GetAll.cshtml"
                   Write(item.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 26 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\GetAll.cshtml"
                                   Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(") ");
#nullable restore
#line 26 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\GetAll.cshtml"
                                                Write(Localizer["NotificationText"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(".\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e635ade0986b6ef8695c95e61f5ebb15d9680aac7304", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 27 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\GetAll.cshtml"
AddHtmlAttributeValue("", 909, item.NotificationId, 909, 20, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-notificationId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 27 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\GetAll.cshtml"
                                                                                                                        WriteLiteral(item.NotificationId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["notificationId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-notificationId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["notificationId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 29 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\GetAll.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div");
            BeginWriteAttribute("name", " name=\"", 1150, "\"", 1177, 1);
#nullable restore
#line 32 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\GetAll.cshtml"
WriteAttributeValue("", 1157, item.NotificationId, 1157, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"text-sm-left td-notice-new p-sm-3 mb-sm-1\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1228, "\"", 1280, 3);
            WriteAttributeValue("", 1238, "notification_click(\'", 1238, 20, true);
#nullable restore
#line 32 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\GetAll.cshtml"
WriteAttributeValue("", 1258, item.NotificationId, 1258, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1278, "\')", 1278, 2, true);
            EndWriteAttribute();
            WriteLiteral(" )>\r\n                        ");
#nullable restore
#line 33 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\GetAll.cshtml"
                   Write(item.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 33 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\GetAll.cshtml"
                                   Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(") ");
#nullable restore
#line 33 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\GetAll.cshtml"
                                                Write(Localizer["NotificationText"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(".\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e635ade0986b6ef8695c95e61f5ebb15d9680aac12304", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 34 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\GetAll.cshtml"
AddHtmlAttributeValue("", 1403, item.NotificationId, 1403, 20, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-notificationId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 34 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\GetAll.cshtml"
                                                                                                                        WriteLiteral(item.NotificationId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["notificationId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-notificationId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["notificationId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 36 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\GetAll.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\GetAll.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IViewLocalizer Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ImageManager.MVC.ViewModels.NotificationViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
