#pragma checksum "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Admin\Complaints.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "47034f7ef37a94bbac7c23ee3d68a5f38a866877"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Complaints), @"mvc.1.0.view", @"/Views/Admin/Complaints.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/Complaints.cshtml", typeof(AspNetCore.Views_Admin_Complaints))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47034f7ef37a94bbac7c23ee3d68a5f38a866877", @"/Views/Admin/Complaints.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6817aeeef6309181429aeace7e2660db444df6d3", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Complaints : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AdminViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Scripts/jquery-3.3.1.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Content/jquery-confirm.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Scripts/jquery-confirm.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Admin\Complaints.cshtml"
  
    ViewData["Title"] = "Complaints";
    Layout = "~/Views/Shared/_UserProfileLayout.cshtml";

#line default
#line hidden
            BeginContext(127, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Admin\Complaints.cshtml"
 foreach (var item in Model.Complaints)
{
    string status = "success";
    if (item.Checked == false)
    {
        status = "danger";
    }

#line default
#line hidden
            BeginContext(279, 8, true);
            WriteLiteral("    <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 287, "\"", 314, 3);
            WriteAttributeValue("", 295, "panel", 295, 5, true);
            WriteAttributeValue(" ", 300, "panel-", 301, 7, true);
#line 14 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Admin\Complaints.cshtml"
WriteAttributeValue("", 307, status, 307, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(315, 38, true);
            WriteLiteral(">\r\n        <div class=\"panel-heading\">");
            EndContext();
            BeginContext(354, 12, false);
#line 15 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Admin\Complaints.cshtml"
                              Write(item.Subject);

#line default
#line hidden
            EndContext();
            BeginContext(366, 11, true);
            WriteLiteral(" -User ID: ");
            EndContext();
            BeginContext(378, 11, false);
#line 15 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Admin\Complaints.cshtml"
                                                      Write(item.UserID);

#line default
#line hidden
            EndContext();
            BeginContext(389, 11, true);
            WriteLiteral(" -Blog ID: ");
            EndContext();
            BeginContext(401, 14, false);
#line 15 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Admin\Complaints.cshtml"
                                                                             Write(item.ArticleID);

#line default
#line hidden
            EndContext();
            BeginContext(415, 57, true);
            WriteLiteral("</div>\r\n        <div class=\"panel-body\">\r\n            <p>");
            EndContext();
            BeginContext(473, 9, false);
#line 17 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Admin\Complaints.cshtml"
          Write(item.Text);

#line default
#line hidden
            EndContext();
            BeginContext(482, 18, true);
            WriteLiteral("</p>\r\n            ");
            EndContext();
            BeginContext(501, 142, false);
#line 18 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Admin\Complaints.cshtml"
       Write(Html.ActionLink("Go to Article", "ReadArticle", "Article", new { id = item.ArticleID, cid = item.ID }, new { @class = "btn btn-info btn-xs" }));

#line default
#line hidden
            EndContext();
            BeginContext(643, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 20 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Admin\Complaints.cshtml"
             if (item.Checked == false)
            {

#line default
#line hidden
            BeginContext(802, 23, true);
            WriteLiteral("                <button");
            EndContext();
            BeginWriteAttribute("id", " id=", 825, "", 837, 1);
#line 22 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Admin\Complaints.cshtml"
WriteAttributeValue("", 829, item.ID, 829, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 837, "\"", 879, 5);
            WriteAttributeValue("", 845, "btn", 845, 3, true);
            WriteAttributeValue(" ", 848, "btn-", 849, 5, true);
#line 22 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Admin\Complaints.cshtml"
WriteAttributeValue("", 853, status, 853, 7, false);

#line default
#line hidden
            WriteAttributeValue(" ", 860, "btn-xs", 861, 7, true);
            WriteAttributeValue(" ", 867, "checkReport", 868, 12, true);
            EndWriteAttribute();
            BeginContext(880, 24, true);
            WriteLiteral(">Check Report</button>\r\n");
            EndContext();
#line 23 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Admin\Complaints.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(952, 45, true);
            WriteLiteral("                <label style=\"font-size:14px\"");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 997, "\"", 1027, 4);
            WriteAttributeValue("", 1005, "btn", 1005, 3, true);
            WriteAttributeValue(" ", 1008, "btn-", 1009, 5, true);
#line 26 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Admin\Complaints.cshtml"
WriteAttributeValue("", 1013, status, 1013, 7, false);

#line default
#line hidden
            WriteAttributeValue(" ", 1020, "btn-xs", 1021, 7, true);
            EndWriteAttribute();
            BeginContext(1028, 18, true);
            WriteLiteral(">Checked</label>\r\n");
            EndContext();
#line 27 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Admin\Complaints.cshtml"
            }

#line default
#line hidden
            BeginContext(1061, 28, true);
            WriteLiteral("        </div>\r\n    </div>\r\n");
            EndContext();
#line 30 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Admin\Complaints.cshtml"

}

#line default
#line hidden
            BeginContext(1094, 22, true);
            WriteLiteral("\r\n\r\n\r\n\r\n<br /><br />\r\n");
            EndContext();
            BeginContext(1116, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "47034f7ef37a94bbac7c23ee3d68a5f38a86687711727", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1169, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1171, 81, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "47034f7ef37a94bbac7c23ee3d68a5f38a86687712907", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1252, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1254, 78, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "47034f7ef37a94bbac7c23ee3d68a5f38a86687714245", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1332, 704, true);
            WriteLiteral(@"
<script>
    $(document).ready(function () {
        $("".checkReport"").click(function () {
                var deletedID = $(this).attr('id');

                $.confirm({
                    theme: 'light',
                    boxWidth: '30%',
                    title: '',
                    content: 'Are you sure to check this report?',
                    buttons: {
                        Yes: {
                            text: 'Yes',
                            keys: ['enter', 'shift'],
                            action: function () {

                                $.ajax({
                                    type: ""POST"",
                                    url: '");
            EndContext();
            BeginContext(2037, 38, false);
#line 58 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Admin\Complaints.cshtml"
                                     Write(Url.Action("CheckComplaints", "Admin"));

#line default
#line hidden
            EndContext();
            BeginContext(2075, 481, true);
            WriteLiteral(@"',
                                    data: { id: deletedID },
                                    success: function (data) {
                                        window.location.reload();
                                    }
                                });
                            }
                        },
                        No: function () {
                        }
                    }
                });
            });
    });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AdminViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
