#pragma checksum "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\User\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "abb0d2838fa073e40f13012c9280df9b629858ec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Edit), @"mvc.1.0.view", @"/Views/User/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"abb0d2838fa073e40f13012c9280df9b629858ec", @"/Views/User/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5706fa34018548bef22ecc506d5e88bcea4b523a", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ImageManager.MVC.ViewModels.EditUserViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\User\Edit.cshtml"
  
    ViewBag.Title = "Редактирование пользователя";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row justify-content-center\">\r\n    <div class=\"text-center pt-md-2 mt-md-2\">\r\n        <div class=\"mb-3\">\r\n            <h2>Создание пользователя</h2>\r\n        </div>\r\n        <div class=\"border border-secondary rounded bg-white\">\r\n");
#nullable restore
#line 13 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\User\Edit.cshtml"
             using (@Html.BeginForm())
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\User\Edit.cshtml"
           Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\User\Edit.cshtml"
           Write(Html.ValidationSummary(true, null, new { @class = "text-danger small" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"form-group pl-md-5 pr-md-5 pt-md-3 pb-md-2 text-md-left\">\r\n                    <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 673, "\"", 690, 1);
#nullable restore
#line 18 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\User\Edit.cshtml"
WriteAttributeValue("", 681, Model.Id, 681, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"Id\" />\r\n                    <div class=\"pt-md-1\">\r\n                        ");
#nullable restore
#line 20 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\User\Edit.cshtml"
                   Write(Html.LabelFor(model => model.LastName, "Фамилия", new { @class = "small" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                        ");
#nullable restore
#line 21 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\User\Edit.cshtml"
                   Write(Html.TextBoxFor(model => model.LastName, null, new { style = "width: 320px;" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                        ");
#nullable restore
#line 22 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\User\Edit.cshtml"
                   Write(Html.ValidationMessageFor(model => model.LastName, null, new { @class = "text-danger small" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"pt-md-2\">\r\n                        ");
#nullable restore
#line 25 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\User\Edit.cshtml"
                   Write(Html.LabelFor(model => model.FirstName, "Имя", new { @class = "small" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                        ");
#nullable restore
#line 26 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\User\Edit.cshtml"
                   Write(Html.TextBoxFor(model => model.FirstName, null, new { style = "width: 320px;" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                        ");
#nullable restore
#line 27 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\User\Edit.cshtml"
                   Write(Html.ValidationMessageFor(model => model.FirstName, null, new { @class = "text-danger small" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"pt-md-2\">\r\n                        ");
#nullable restore
#line 30 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\User\Edit.cshtml"
                   Write(Html.LabelFor(model => model.Email, "Почта", new { @class = "small" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                        ");
#nullable restore
#line 31 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\User\Edit.cshtml"
                   Write(Html.TextBoxFor(model => model.Email, null, new { style = "width: 320px;" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                        ");
#nullable restore
#line 32 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\User\Edit.cshtml"
                   Write(Html.ValidationMessageFor(model => model.Email, null, new { @class = "text-danger small" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"row pt-md-2 mt-2 justify-content-around\">\r\n                        ");
#nullable restore
#line 35 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\User\Edit.cshtml"
                   Write(Html.LabelFor(model => model.IsAdmin, "Администратор", new { @class = "small pl-3 mr-4" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 36 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\User\Edit.cshtml"
                   Write(Html.CheckBoxFor(model => model.IsAdmin, new { @class = "form-control pr-3 mr-4", style = "width:20px; height:20px;" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"row pt-md-2 justify-content-around\">\r\n                        ");
#nullable restore
#line 39 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\User\Edit.cshtml"
                   Write(Html.LabelFor(model => model.IsUser, "Пользователь", new { @class = "small pl-3 mr-4" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 40 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\User\Edit.cshtml"
                   Write(Html.CheckBoxFor(model => model.IsUser, new { @class = "form-control pr-3 mr-4", style = "width:20px; height:20px;"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"pt-md-4 text-center\">\r\n                        <input type=\"submit\" class=\"btn btn-success\" value=\"Изменить\" \\>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 46 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\User\Edit.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n        <br />\r\n        <br />\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ImageManager.MVC.ViewModels.EditUserViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591