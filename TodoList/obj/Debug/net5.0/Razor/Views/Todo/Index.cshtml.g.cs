#pragma checksum "D:\CODE\C#\demo001\TodoList\TodoList\Views\Todo\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d753d4bbde5c27a19ebdd642b729c8995d098d1c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Todo_Index), @"mvc.1.0.view", @"/Views/Todo/Index.cshtml")]
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
#line 1 "D:\CODE\C#\demo001\TodoList\TodoList\Views\_ViewImports.cshtml"
using TodoList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\CODE\C#\demo001\TodoList\TodoList\Views\_ViewImports.cshtml"
using TodoList.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\CODE\C#\demo001\TodoList\TodoList\Views\Todo\Index.cshtml"
using Humanizer;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d753d4bbde5c27a19ebdd642b729c8995d098d1c", @"/Views/Todo/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b81968e910e1c4b6c646faaf9ce216adba1ee08", @"/Views/_ViewImports.cshtml")]
    public class Views_Todo_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TodoViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MarkDone", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!--??????????????????Model-->\r\n<!--?????????????????????????????????????????????????????????,????????????-->\r\n<!--ViewData????????????????????????????????????????????????????????????-->\r\n<!--???Nuget????????????????????????????????????.core-->\r\n<!--?????????hidden????????????????????????????????????id,????????????-->\r\n");
#nullable restore
#line 8 "D:\CODE\C#\demo001\TodoList\TodoList\Views\Todo\Index.cshtml"
  
    ViewData["Title"] = "Manage your todo list";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"panel panel-default todo-panel\">\r\n    <div class=\"panel-heading\">\r\n        ");
#nullable restore
#line 14 "D:\CODE\C#\demo001\TodoList\TodoList\Views\Todo\Index.cshtml"
   Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </div>
    <table class=""table table-hover"">
        <thead>
        <tr>
            <td>&#x2714;</td>
            <td>Item</td>
            <td>Due</td>
        </tr>
        </thead>
        <!--????????????name='id'????????????????????????,????????????asp-name????????????--->
");
#nullable restore
#line 25 "D:\CODE\C#\demo001\TodoList\TodoList\Views\Todo\Index.cshtml"
         foreach (var item in Model.Items) {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d753d4bbde5c27a19ebdd642b729c8995d098d1c5155", async() => {
                WriteLiteral("\r\n                        <input type=\"checkbox\" class=\"done-checkbox\">\r\n                        <input type=\"hidden\" name=\"id\"");
                BeginWriteAttribute("value", " value=\"", 895, "\"", 911, 1);
#nullable restore
#line 30 "D:\CODE\C#\demo001\TodoList\TodoList\Views\Todo\Index.cshtml"
WriteAttributeValue("", 903, item.Id, 903, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n                <td>");
#nullable restore
#line 33 "D:\CODE\C#\demo001\TodoList\TodoList\Views\Todo\Index.cshtml"
               Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 34 "D:\CODE\C#\demo001\TodoList\TodoList\Views\Todo\Index.cshtml"
               Write(item.DueAt.Humanize());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 36 "D:\CODE\C#\demo001\TodoList\TodoList\Views\Todo\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n    <div class=\"panel-footer add-item-form\">\r\n        ");
#nullable restore
#line 39 "D:\CODE\C#\demo001\TodoList\TodoList\Views\Todo\Index.cshtml"
   Write(await Html.PartialAsync("AddItemPartial",new TodoItem()));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        <!--????????????:https://docs.microsoft.com/zh-cn/aspnet/core/mvc/views/partial?view=aspnetcore-5.0
        ?????????????????????????????????,await?????????????????????????????????????????????
        ??????????????????????????????????????????,???????????????model??????????????????,??????????????????????????????????????????,??????new ????????????????????????????
        ???:?????????????????????""????????????""???????????????,asp.net core?????????????????????????????????????????????????????????????????????,?????????????????????????????????,
        ???,???????????????????????????form????????????????????????????????????TodoItem???.???AddItemPartial??????????????????????????????.
        -->
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TodoViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
