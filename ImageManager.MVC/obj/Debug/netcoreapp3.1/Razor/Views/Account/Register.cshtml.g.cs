#pragma checksum "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Account\Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "023154576c284775785be5226ccfdbb119773f22"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Register), @"mvc.1.0.view", @"/Views/Account/Register.cshtml")]
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
#line 3 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Account\Register.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"023154576c284775785be5226ccfdbb119773f22", @"/Views/Account/Register.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5706fa34018548bef22ecc506d5e88bcea4b523a", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Register : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ImageManager.MVC.ViewModels.RegisterViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "email", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "email", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("data-input"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 6 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Account\Register.cshtml"
  
    ViewBag.Title = Localizer["Register"];

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row justify-content-center\">\r\n    <div class=\"text-center pt-md-5 mt-md-2\">\r\n        <div class=\"mb-4\">\r\n            <h2>");
#nullable restore
#line 13 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Account\Register.cshtml"
           Write(Localizer["Register"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n        </div>\r\n        <div class=\"border border-secondary rounded bg-white\">\r\n");
#nullable restore
#line 16 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Account\Register.cshtml"
             using (@Html.BeginForm())
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Account\Register.cshtml"
           Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"form-group pl-md-5 pr-md-5 pt-md-3 pb-sm-1 text-md-left\">\r\n                    <div class=\"pt-md-4\">\r\n                        ");
#nullable restore
#line 21 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Account\Register.cshtml"
                   Write(Html.TextBoxFor(model => model.LastName, null, new { @class = "data-input", placeholder = Localizer["Surname"].Value }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                        ");
#nullable restore
#line 22 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Account\Register.cshtml"
                   Write(Html.ValidationMessageFor(model => model.LastName, null, new { @class = "text-danger small" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"pt-md-3\">\r\n                        ");
#nullable restore
#line 25 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Account\Register.cshtml"
                   Write(Html.TextBoxFor(model => model.FirstName, null, new { @class = "data-input", placeholder = Localizer["FirstName"].Value }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                        ");
#nullable restore
#line 26 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Account\Register.cshtml"
                   Write(Html.ValidationMessageFor(model => model.FirstName, null, new { @class = "text-danger small" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"pt-md-3\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "023154576c284775785be5226ccfdbb119773f227211", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 29 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Account\Register.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Email);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "placeholder", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 29 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Account\Register.cshtml"
AddHtmlAttributeValue("", 1457, Localizer["Email"].Value, 1457, 25, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("<br />\r\n                        ");
#nullable restore
#line 30 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Account\Register.cshtml"
                   Write(Html.ValidationMessageFor(model => model.Email, null, new { @class = "text-danger small" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"pt-md-3\">\r\n                        ");
#nullable restore
#line 33 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Account\Register.cshtml"
                   Write(Html.PasswordFor(model => model.Password, new { @class = "data-input", placeholder = Localizer["Password"].Value }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                        ");
#nullable restore
#line 34 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Account\Register.cshtml"
                   Write(Html.ValidationMessageFor(model => model.Password, null, new { @class = "text-danger small" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"pt-md-3\">\r\n                        ");
#nullable restore
#line 37 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Account\Register.cshtml"
                   Write(Html.PasswordFor(model => model.ConfirmPassword, new { @class = "data-input", placeholder = Localizer["ConfirmPassword"].Value }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                        ");
#nullable restore
#line 38 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Account\Register.cshtml"
                   Write(Html.ValidationMessageFor(model => model.ConfirmPassword, null, new { @class = "text-danger small" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    ");
#nullable restore
#line 40 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Account\Register.cshtml"
               Write(Html.ValidationSummary(true, null, new { @class = "small mt-sm-3 p-sm-2 rounded my-validation" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"pt-md-3 text-center\">\r\n                        <input type=\"submit\" class=\"btn btn-success data-input-btn\"");
            BeginWriteAttribute("value", " value=\"", 2598, "\"", 2634, 1);
#nullable restore
#line 42 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Account\Register.cshtml"
WriteAttributeValue("", 2606, Localizer["RegisterButton"], 2606, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" \\>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 45 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Account\Register.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n        <br />\r\n        <br />\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ImageManager.MVC.ViewModels.RegisterViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
