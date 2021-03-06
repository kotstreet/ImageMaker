#pragma checksum "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e87fd2dc414dbf270f53707c5592ec73dc90daf0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 3 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e87fd2dc414dbf270f53707c5592ec73dc90daf0", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5706fa34018548bef22ecc506d5e88bcea4b523a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ImageManager.MVC.ViewModels.IndexViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 6 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
  
    ViewBag.Title = Localizer["Title"];

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container body-content"">
    <div class=""col-sm-12"">
        <br />
        <div class=""row pt-sm-3 pb-sm-3"">
            <input type=""hidden"" id=""imageUrl"" />
            <input type=""file"" accept="".jpg, .jpeg, .png"" hidden id=""fileInputItem"" onchange=""inputFile_changed(this.files)"" />
            <a id=""downloadLnk"" download=""File from online editor.jpg"" hidden></a>

            <button id=""openButton"" class=""btn btn-menu btn-menu-open ml-0"" onclick=""open_click();"">");
#nullable restore
#line 18 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
                                                                                               Write(Localizer["OpenButton"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n            <button id=\"saveButtton\" class=\"btn btn-menu btn-menu-save mr-sm-5\" disabled");
            BeginWriteAttribute("title", " title=\"", 800, "\"", 841, 1);
#nullable restore
#line 19 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 808, Localizer["ElementDisableTitle"], 808, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" \r\n                    onclick=\"save_click();\">");
#nullable restore
#line 20 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
                                       Write(Localizer["SaveButton"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n            <button id=\"canselAllButtton\" class=\"btn btn-menu btn-menu-cancel\" disabled");
            BeginWriteAttribute("title", " title=\"", 1011, "\"", 1052, 1);
#nullable restore
#line 21 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 1019, Localizer["ElementDisableTitle"], 1019, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" \r\n                    onclick=\"canselAll_click();\">");
#nullable restore
#line 22 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
                                            Write(Localizer["RollBackButton"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n        </div>\r\n\r\n        <div class=\"row work-div\">\r\n            <div id=\"imageActionDiv\" class=\"pl-sm-4 pr-sm-4 border rounded tool-div\">\r\n                <b>");
#nullable restore
#line 27 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
              Write(Localizer["ModeratorsText"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b><br />\r\n                <button id=\"resizeAction\" class=\"btn btn-filter\" disabled onclick=\"resizeAction_click();\"");
            BeginWriteAttribute("title", " \r\n                        title=\"", 1449, "\"", 1516, 1);
#nullable restore
#line 29 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 1483, Localizer["ElementDisableTitle"], 1483, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 29 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
                                                             Write(Localizer["ChangeSizeButton"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</button><br />

                <div id=""changeSizeDiv"" class=""change-size-div col-11 ml-2 mr-2"">
                    <div class=""row justify-content-around"">
                        <div class=""m-1 p-1"" id=""changeSizeHDiv"">
                            <label>");
#nullable restore
#line 34 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
                              Write(Localizer["HeightText"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label><br />
                            <input type=""number"" id=""changeSizeH"" class=""change-size-input"" value=""0"" min=""0"" onchange=""changeSizeH_change();"" />
                        </div>
                        <div class=""m-1 p-1"" id=""changeSizeWDiv"">
                            <label>");
#nullable restore
#line 38 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
                              Write(Localizer["WidthText"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label><br />
                            <input type=""number"" id=""changeSizeW"" class=""change-size-input"" value=""0"" min=""0"" onchange=""changeSizeW_change();"" />
                        </div>
                    </div>
                    <div class=""text-center p-2"">
                        <div>
                            <button id=""changeSizeBtn"" class=""btn change-size-btn"" onclick=""changeSizeBtn_click();"">");
#nullable restore
#line 44 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
                                                                                                               Write(Localizer["SaveSizeButton"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                <br />\r\n\r\n                <b>");
#nullable restore
#line 50 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
              Write(Localizer["RotatesText"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b><br />\r\n                <button id=\"rightRotate\" class=\"btn btn-filter\" disabled onclick=\"rotateRight_click()\"");
            BeginWriteAttribute("title", " \r\n                        title=\"", 2886, "\"", 2953, 1);
#nullable restore
#line 52 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 2920, Localizer["ElementDisableTitle"], 2920, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 52 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
                                                             Write(Localizer["RotateRightButton"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button><br />\r\n                <button id=\"leftRotate\" class=\"btn btn-filter\" disabled onclick=\"rotateLeft_click()\"");
            BeginWriteAttribute("title", " \r\n                        title=\"", 3103, "\"", 3170, 1);
#nullable restore
#line 54 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 3137, Localizer["ElementDisableTitle"], 3137, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 54 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
                                                             Write(Localizer["RotateRightLeftButton"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button><br />\r\n                <br />\r\n\r\n                <b>");
#nullable restore
#line 57 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
              Write(Localizer["FiltersText"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b><br />\r\n                <button id=\"blurFilter\" class=\"btn btn-filter\" disabled onclick=\"blurFiltrButton_click()\"");
            BeginWriteAttribute("title", " \r\n                        title=\"", 3411, "\"", 3478, 1);
#nullable restore
#line 59 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 3445, Localizer["ElementDisableTitle"], 3445, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 59 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
                                                             Write(Localizer["BlurButton"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button><br />\r\n                <button id=\"brightnessFilter\" class=\"btn btn-filter\" disabled onclick=\"brightnessFiltrButton_click()\"");
            BeginWriteAttribute("title", " \r\n                        title=\"", 3638, "\"", 3705, 1);
#nullable restore
#line 61 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 3672, Localizer["ElementDisableTitle"], 3672, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 61 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
                                                             Write(Localizer["BrightButton"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button><br />\r\n                <button id=\"notBrightnessFilter\" class=\"btn btn-filter\" disabled onclick=\"notBrightnessFiltrButton_click()\"");
            BeginWriteAttribute("title", " \r\n                        title=\"", 3873, "\"", 3940, 1);
#nullable restore
#line 63 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 3907, Localizer["ElementDisableTitle"], 3907, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 63 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
                                                             Write(Localizer["DarkButton"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button><br />\r\n\r\n                <button id=\"contrastFilter\" class=\"btn btn-filter\" disabled onclick=\"contrastFiltrButton_click()\"");
            BeginWriteAttribute("title", " \r\n                        title=\"", 4098, "\"", 4165, 1);
#nullable restore
#line 66 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 4132, Localizer["ElementDisableTitle"], 4132, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 66 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
                                                             Write(Localizer["ContrastButton"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button><br />\r\n                <button id=\"shadowFilter\" class=\"btn btn-filter\" disabled onclick=\"shadowFiltrButton_click()\"");
            BeginWriteAttribute("title", " \r\n                        title=\"", 4321, "\"", 4388, 1);
#nullable restore
#line 68 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 4355, Localizer["ElementDisableTitle"], 4355, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 68 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
                                                             Write(Localizer["ShadowButton"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button><br />\r\n                <button id=\"grayscaleFilter\" class=\"btn btn-filter\" disabled onclick=\"grayscaleButton_click()\"");
            BeginWriteAttribute("title", " \r\n                        title=\"", 4543, "\"", 4610, 1);
#nullable restore
#line 70 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 4577, Localizer["ElementDisableTitle"], 4577, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 70 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
                                                             Write(Localizer["BlackAndWhiteButton"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button><br />\r\n\r\n                <button id=\"hueRotate1Filter\" class=\"btn btn-filter\" disabled onclick=\"hueRotate1Button_click()\"");
            BeginWriteAttribute("title", " \r\n                        title=\"", 4776, "\"", 4843, 1);
#nullable restore
#line 73 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 4810, Localizer["ElementDisableTitle"], 4810, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 73 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
                                                             Write(Localizer["ColorChange1Button"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button><br />\r\n                <button id=\"hueRotate2Filter\" class=\"btn btn-filter\" disabled onclick=\"hueRotate2Button_click()\"");
            BeginWriteAttribute("title", " \r\n                        title=\"", 5006, "\"", 5073, 1);
#nullable restore
#line 75 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 5040, Localizer["ElementDisableTitle"], 5040, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 75 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
                                                             Write(Localizer["ColorChange2Button"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button><br />\r\n                <button id=\"hueRotate3Filter\" class=\"btn btn-filter\" disabled onclick=\"hueRotate3Button_click()\"");
            BeginWriteAttribute("title", " \r\n                        title=\"", 5236, "\"", 5303, 1);
#nullable restore
#line 77 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 5270, Localizer["ElementDisableTitle"], 5270, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 77 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
                                                             Write(Localizer["ColorChange3Button"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button><br />\r\n\r\n                <button id=\"invertFilter\" class=\"btn btn-filter\" disabled onclick=\"invertButton_click()\"");
            BeginWriteAttribute("title", " \r\n                        title=\"", 5460, "\"", 5527, 1);
#nullable restore
#line 80 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 5494, Localizer["ElementDisableTitle"], 5494, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 80 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
                                                             Write(Localizer["NegativeButton"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button><br />\r\n                <button id=\"sepiaFilter\" class=\"btn btn-filter\" disabled onclick=\"sepiaFiltrButton_click()\"");
            BeginWriteAttribute("title", " \r\n                        title=\"", 5681, "\"", 5748, 1);
#nullable restore
#line 82 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 5715, Localizer["ElementDisableTitle"], 5715, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 82 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
                                                             Write(Localizer["SemiAntiqueButton"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button><br />\r\n                <button id=\"noneFilter\" class=\"btn btn-filter\" disabled onclick=\"noneFiltrButton_click()\"");
            BeginWriteAttribute("title", " \r\n                        title=\"", 5903, "\"", 5970, 1);
#nullable restore
#line 84 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 5937, Localizer["ElementDisableTitle"], 5937, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 84 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
                                                             Write(Localizer["NoneButton"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</button><br />
            </div>

            <div class=""bg-secondary canvas-div"">
                <canvas id=""myCanvas""></canvas>
            </div>
        </div>
    </div>
</div>
<br />

<script>
    function addImage(url) {

        console.log('start');
        $.ajax({
            type: ""POST"",
            url: '");
#nullable restore
#line 101 "D:\C#\_Asyst-lab\ImageManager\ImageManager.MVC\Views\Home\Index.cshtml"
             Write(Url.Action("AddImage", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
            data: { imageUrl : url },
            dataType: 'text',
            success: function (result) {
                console.log(result.msg);
            },
            error: function (result) {
                if (result.status == 401) {
                    console.log('error 401');
                    location.reload();
                }
                else {
                    console.log('error');
                }
            },
            complete: function (result) {
                console.log(""completed with status code: "" + result.status);
            },
        })
        console.log('finish');
    }

</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ImageManager.MVC.ViewModels.IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
