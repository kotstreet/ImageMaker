#pragma checksum "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\ShowImage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93da82d62c737f14f379f1b55f2780b219f7b98c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Notification_ShowImage), @"mvc.1.0.view", @"/Views/Notification/ShowImage.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93da82d62c737f14f379f1b55f2780b219f7b98c", @"/Views/Notification/ShowImage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5706fa34018548bef22ecc506d5e88bcea4b523a", @"/Views/_ViewImports.cshtml")]
    public class Views_Notification_ShowImage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ImageManager.MVC.ViewModels.ImageViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\ShowImage.cshtml"
  
    ViewData["Title"] = "Новое изобраажение";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"justify-content-center\">\r\n    <div class=\"col\">\r\n        <div class=\"text-center m-sm-4\">\r\n            <h4>Новое изображение пользователя ");
#nullable restore
#line 10 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\ShowImage.cshtml"
                                          Write(Model.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 10 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\ShowImage.cshtml"
                                                           Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</h4>\r\n        </div>\r\n        <div class=\"justify-content-center row\">\r\n            <img class=\"img-notice\"");
            BeginWriteAttribute("src", " src=\"", 397, "\"", 414, 1);
#nullable restore
#line 13 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Notification\ShowImage.cshtml"
WriteAttributeValue("", 403, Model.Path, 403, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/>\r\n        </div>\r\n        <div class=\"text-sm-center m-sm-3\">\r\n            <button class=\"btn btn-outline-info\" onclick=\"backOrClose();\">Назад</button>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ImageManager.MVC.ViewModels.ImageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591