#pragma checksum "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Account\UserInformation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a0afd4ffdfbe1da2946037cad742aca3e234a2e9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_UserInformation), @"mvc.1.0.view", @"/Views/Account/UserInformation.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/UserInformation.cshtml", typeof(AspNetCore.Views_Account_UserInformation))]
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
#line 2 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\_ViewImports.cshtml"
using ArticlePublishing.Models.Entities;

#line default
#line hidden
#line 3 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\_ViewImports.cshtml"
using ArticlePublishing.Models.ViewModels;

#line default
#line hidden
#line 4 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a0afd4ffdfbe1da2946037cad742aca3e234a2e9", @"/Views/Account/UserInformation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6817aeeef6309181429aeace7e2660db444df6d3", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_UserInformation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Users>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(14, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Account\UserInformation.cshtml"
  
    ViewData["Title"] = "UserInformation";
    Layout = "~/Views/Shared/_UserProfileLayout.cshtml";

#line default
#line hidden
            BeginContext(125, 183, true);
            WriteLiteral("<br />\r\n<br />\r\n<br />\r\n<br />\r\n<h2>UserInformation</h2>\r\n<table class=\"table\">\r\n    <tbody>\r\n        <tr>\r\n            <td>Name Surname</td>\r\n            <td>:</td>\r\n            <td>");
            EndContext();
            BeginContext(309, 10, false);
#line 17 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Account\UserInformation.cshtml"
           Write(Model.Name);

#line default
#line hidden
            EndContext();
            BeginContext(319, 6, true);
            WriteLiteral("&nbsp;");
            EndContext();
            BeginContext(326, 13, false);
#line 17 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Account\UserInformation.cshtml"
                            Write(Model.Surname);

#line default
#line hidden
            EndContext();
            BeginContext(339, 105, true);
            WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <td>E-Mail</td>\r\n            <td>:</td>\r\n            <td>");
            EndContext();
            BeginContext(445, 11, false);
#line 22 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Account\UserInformation.cshtml"
           Write(Model.Email);

#line default
#line hidden
            EndContext();
            BeginContext(456, 108, true);
            WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <td>User name</td>\r\n            <td>:</td>\r\n            <td>");
            EndContext();
            BeginContext(565, 14, false);
#line 27 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Account\UserInformation.cshtml"
           Write(Model.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(579, 105, true);
            WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <td>Adress</td>\r\n            <td>:</td>\r\n            <td>");
            EndContext();
            BeginContext(685, 12, false);
#line 32 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Account\UserInformation.cshtml"
           Write(Model.Adress);

#line default
#line hidden
            EndContext();
            BeginContext(697, 104, true);
            WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <td>Phone</td>\r\n            <td>:</td>\r\n            <td>");
            EndContext();
            BeginContext(802, 11, false);
#line 37 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Account\UserInformation.cshtml"
           Write(Model.Phone);

#line default
#line hidden
            EndContext();
            BeginContext(813, 112, true);
            WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <td>Register Date</td>\r\n            <td>:</td>\r\n            <td>");
            EndContext();
            BeginContext(926, 18, false);
#line 42 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Account\UserInformation.cshtml"
           Write(Model.RegisterDate);

#line default
#line hidden
            EndContext();
            BeginContext(944, 44, true);
            WriteLiteral("</td>\r\n        </tr>\r\n    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Users> Html { get; private set; }
    }
}
#pragma warning restore 1591
