#pragma checksum "C:\Users\elman\Desktop\p219_backend_project-EHesenov2000\EduHome\EduHome\Views\Shared\_CourseComments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3d478e197357f50633e6b0e4340f7517ce460dac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__CourseComments), @"mvc.1.0.view", @"/Views/Shared/_CourseComments.cshtml")]
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
#line 1 "C:\Users\elman\Desktop\p219_backend_project-EHesenov2000\EduHome\EduHome\Views\Shared\_CourseComments.cshtml"
using EduHome.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d478e197357f50633e6b0e4340f7517ce460dac", @"/Views/Shared/_CourseComments.cshtml")]
    public class Views_Shared__CourseComments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CourseComment>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\elman\Desktop\p219_backend_project-EHesenov2000\EduHome\EduHome\Views\Shared\_CourseComments.cshtml"
 if (Model != null)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\elman\Desktop\p219_backend_project-EHesenov2000\EduHome\EduHome\Views\Shared\_CourseComments.cshtml"
     foreach (var comment in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <hr />\r\n        <div class=\"review-comment mb--20\">\r\n            <div class=\"text\">\r\n                <h6 class=\"author\">\r\n                    ");
#nullable restore
#line 11 "C:\Users\elman\Desktop\p219_backend_project-EHesenov2000\EduHome\EduHome\Views\Shared\_CourseComments.cshtml"
               Write(comment.AppUser.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ??? <span class=\"font-weight-400\">");
#nullable restore
#line 11 "C:\Users\elman\Desktop\p219_backend_project-EHesenov2000\EduHome\EduHome\Views\Shared\_CourseComments.cshtml"
                                                                         Write(comment.CreatedAt.ToString("HH:mm d MMMM, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </h6>\r\n                <p>\r\n                    ");
#nullable restore
#line 14 "C:\Users\elman\Desktop\p219_backend_project-EHesenov2000\EduHome\EduHome\Views\Shared\_CourseComments.cshtml"
               Write(comment.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </p>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 18 "C:\Users\elman\Desktop\p219_backend_project-EHesenov2000\EduHome\EduHome\Views\Shared\_CourseComments.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\elman\Desktop\p219_backend_project-EHesenov2000\EduHome\EduHome\Views\Shared\_CourseComments.cshtml"
     
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CourseComment>> Html { get; private set; }
    }
}
#pragma warning restore 1591
