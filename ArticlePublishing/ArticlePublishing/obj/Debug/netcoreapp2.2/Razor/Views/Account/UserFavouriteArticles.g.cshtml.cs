#pragma checksum "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Account\UserFavouriteArticles.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "34f5ea12bcebdefb31fe9755b2db58bbb25a71fa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_UserFavouriteArticles), @"mvc.1.0.view", @"/Views/Account/UserFavouriteArticles.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/UserFavouriteArticles.cshtml", typeof(AspNetCore.Views_Account_UserFavouriteArticles))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"34f5ea12bcebdefb31fe9755b2db58bbb25a71fa", @"/Views/Account/UserFavouriteArticles.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6817aeeef6309181429aeace7e2660db444df6d3", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_UserFavouriteArticles : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ArticleViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Article", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ReadArticle", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Account\UserFavouriteArticles.cshtml"
  
    ViewData["Title"] = "UserFavouriteArticles";
    Layout = "~/Views/Shared/_UserProfileLayout.cshtml";

#line default
#line hidden
            BeginContext(140, 36, true);
            WriteLiteral("\r\n<h2>UserFavouriteArticles</h2>\r\n\r\n");
            EndContext();
#line 9 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Account\UserFavouriteArticles.cshtml"
 if (Model.articlesList.Count == 0)
{

#line default
#line hidden
            BeginContext(216, 46, true);
            WriteLiteral("    <h4>User has not any favourite blog</h4>\r\n");
            EndContext();
#line 12 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Account\UserFavouriteArticles.cshtml"
}

#line default
#line hidden
            BeginContext(265, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 14 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Account\UserFavouriteArticles.cshtml"
 foreach (var item in Model.articlesList)
{

#line default
#line hidden
            BeginContext(313, 83, true);
            WriteLiteral("    <div class=\"col-md-4\">\r\n        <div class=\"col-md-12 blogCards text-center\">\r\n");
            EndContext();
            BeginContext(493, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(505, 122, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "34f5ea12bcebdefb31fe9755b2db58bbb25a71fa6062", async() => {
                BeginContext(582, 41, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "34f5ea12bcebdefb31fe9755b2db58bbb25a71fa6325", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 592, "~/Images/", 592, 9, true);
#line 19 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Account\UserFavouriteArticles.cshtml"
AddHtmlAttributeValue("", 601, item.DefaultImage, 601, 18, false);

#line default
#line hidden
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 19 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Account\UserFavouriteArticles.cshtml"
                                                                   WriteLiteral(item.ID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(627, 77, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-12 blogCards\">\r\n            <h3>");
            EndContext();
            BeginContext(705, 10, false);
#line 22 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Account\UserFavouriteArticles.cshtml"
           Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(715, 85, true);
            WriteLiteral(" </h3>\r\n        </div>\r\n\r\n        <div class=\"col-md-12 blogCards\">\r\n            <h5>");
            EndContext();
            BeginContext(801, 9, false);
#line 26 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Account\UserFavouriteArticles.cshtml"
           Write(item.Text);

#line default
#line hidden
            EndContext();
            BeginContext(810, 68, true);
            WriteLiteral(". </h5>\r\n        </div>\r\n        <div class=\"col-md-12 blogCards\">\r\n");
            EndContext();
            BeginContext(995, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(1007, 108, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "34f5ea12bcebdefb31fe9755b2db58bbb25a71fa11172", async() => {
                BeginContext(1107, 4, true);
                WriteLiteral("Read");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 30 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Account\UserFavouriteArticles.cshtml"
                                                                   WriteLiteral(item.ID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1115, 59, true);
            WriteLiteral("\r\n            <br /> <br />\r\n\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 35 "C:\Users\canba\Desktop\apdp\ArticlePublishing\ArticlePublishing\Views\Account\UserFavouriteArticles.cshtml"
}

#line default
#line hidden
            BeginContext(1177, 4, true);
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ArticleViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
