#pragma checksum "C:\Users\elman\Desktop\p219_backend_project-EHesenov2000\EduHome\EduHome\Areas\Manage\Views\Request\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0ba1e3d33746165f3b782aa6cea75dbe115b0376"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Request_Detail), @"mvc.1.0.view", @"/Areas/Manage/Views/Request/Detail.cshtml")]
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
#line 1 "C:\Users\elman\Desktop\p219_backend_project-EHesenov2000\EduHome\EduHome\Areas\Manage\Views\Request\Detail.cshtml"
using EduHome.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\elman\Desktop\p219_backend_project-EHesenov2000\EduHome\EduHome\Areas\Manage\Views\Request\Detail.cshtml"
using EduHome.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ba1e3d33746165f3b782aa6cea75dbe115b0376", @"/Areas/Manage/Views/Request/Detail.cshtml")]
    public class Areas_Manage_Views_Request_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Request>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "changestatus", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\elman\Desktop\p219_backend_project-EHesenov2000\EduHome\EduHome\Areas\Manage\Views\Request\Detail.cshtml"
  
    ViewData["Title"] = "Detail";
    Layout = "~/Areas/Manage/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    <div class=\"card mb-4\">\r\n        <div class=\"card-header row\">\r\n            <div class=\"col-md-6\">\r\n                ");
#nullable restore
#line 14 "C:\Users\elman\Desktop\p219_backend_project-EHesenov2000\EduHome\EduHome\Areas\Manage\Views\Request\Detail.cshtml"
           Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("  -  ");
#nullable restore
#line 14 "C:\Users\elman\Desktop\p219_backend_project-EHesenov2000\EduHome\EduHome\Areas\Manage\Views\Request\Detail.cshtml"
                               Write(Model.RequestDate.ToString("HH:mm - dd MMMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"col-md-6\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0ba1e3d33746165f3b782aa6cea75dbe115b03765430", async() => {
                WriteLiteral("\r\n                    <input type=\"hidden\" name=\"id\"");
                BeginWriteAttribute("value", " value=\"", 613, "\"", 630, 1);
#nullable restore
#line 18 "C:\Users\elman\Desktop\p219_backend_project-EHesenov2000\EduHome\EduHome\Areas\Manage\Views\Request\Detail.cshtml"
WriteAttributeValue("", 621, Model.Id, 621, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                    <div class=\"row\">\r\n                        <div class=\"form-group col-md-6\">\r\n                            <label>Author</label>\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0ba1e3d33746165f3b782aa6cea75dbe115b03766339", async() => {
                    WriteLiteral("\r\n                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 22 "C:\Users\elman\Desktop\p219_backend_project-EHesenov2000\EduHome\EduHome\Areas\Manage\Views\Request\Detail.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.Status);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#nullable restore
#line 22 "C:\Users\elman\Desktop\p219_backend_project-EHesenov2000\EduHome\EduHome\Areas\Manage\Views\Request\Detail.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = new  SelectList(Enum.GetNames(typeof(EduHome.Enums.RequestStatus)));

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        </div>\r\n                        <button type=\"submit\" class=\"btn btn-primary\">Set status</button>\r\n                    </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n\r\n        </div>\r\n        <div class=\"card-body\">\r\n            <p class=\"card-text\">Total amount: ");
#nullable restore
#line 32 "C:\Users\elman\Desktop\p219_backend_project-EHesenov2000\EduHome\EduHome\Areas\Manage\Views\Request\Detail.cshtml"
                                          Write(Model.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"row\">\r\n\r\n            <div class=\"col-sm-4\">\r\n                <div class=\"card\">\r\n                    <div class=\"card-body\">\r\n                        <h5 class=\"card-title\">Category: ");
#nullable restore
#line 41 "C:\Users\elman\Desktop\p219_backend_project-EHesenov2000\EduHome\EduHome\Areas\Manage\Views\Request\Detail.cshtml"
                                                    Write(Model.Course.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                        <p class=\"card-text\">UserName: ");
#nullable restore
#line 42 "C:\Users\elman\Desktop\p219_backend_project-EHesenov2000\EduHome\EduHome\Areas\Manage\Views\Request\Detail.cshtml"
                                                  Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p class=\"card-text\">Price: ");
#nullable restore
#line 43 "C:\Users\elman\Desktop\p219_backend_project-EHesenov2000\EduHome\EduHome\Areas\Manage\Views\Request\Detail.cshtml"
                                               Write(Model.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p class=\"card-text\">Phone: ");
#nullable restore
#line 44 "C:\Users\elman\Desktop\p219_backend_project-EHesenov2000\EduHome\EduHome\Areas\Manage\Views\Request\Detail.cshtml"
                                               Write(Model.ContactPhone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p class=\"card-text\">Address: ");
#nullable restore
#line 45 "C:\Users\elman\Desktop\p219_backend_project-EHesenov2000\EduHome\EduHome\Areas\Manage\Views\Request\Detail.cshtml"
                                                 Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n    </div>\r\n\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Request> Html { get; private set; }
    }
}
#pragma warning restore 1591
