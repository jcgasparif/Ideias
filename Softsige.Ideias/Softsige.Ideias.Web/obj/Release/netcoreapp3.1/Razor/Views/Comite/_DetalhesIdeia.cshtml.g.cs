#pragma checksum "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Comite\_DetalhesIdeia.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "da3ecd44d1ee41902e3a07f74cc8b8426c82b18b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Comite__DetalhesIdeia), @"mvc.1.0.view", @"/Views/Comite/_DetalhesIdeia.cshtml")]
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
#line 1 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\_ViewImports.cshtml"
using Softsige.Ideias.App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\_ViewImports.cshtml"
using Softsige.Ideias.App.Core.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Comite\_DetalhesIdeia.cshtml"
using Softsige.Ideias.App.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da3ecd44d1ee41902e3a07f74cc8b8426c82b18b", @"/Views/Comite/_DetalhesIdeia.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4aa704ea63e87d028d815a46f824577699ec6da8", @"/Views/_ViewImports.cshtml")]
    public class Views_Comite__DetalhesIdeia : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IdeiasViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ListaAnexos", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div id=""ibox-title-comite-detalhes-ideia"" class=""ibox-title header-green"">
    <h5>Detalhes da Ideia</h5>
    <div class=""ibox-tools"">
        <i id=""ibox-tools-comite-detalhes-ideia-chevron"" class=""fa fa-chevron-down text-white""></i>
    </div>
</div>
<div id=""ibox-content-comite-detalhes-ideia"" class=""ibox-content"" style=""display:none;"">
    <div class=""form-group row"">
        <div class=""col-sm-2 col-form-label"">
            ");
#nullable restore
#line 13 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Comite\_DetalhesIdeia.cshtml"
       Write(Html.DisplayNameFor(model => model.DataInclusao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-sm-10 col-form-label\">\r\n            ");
#nullable restore
#line 16 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Comite\_DetalhesIdeia.cshtml"
       Write(Html.DisplayFor(model => model.DataInclusao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"hr-line-dashed\"></div>\r\n    <div class=\"form-group row\">\r\n        <div class=\"col-sm-2 col-form-label\">\r\n            ");
#nullable restore
#line 22 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Comite\_DetalhesIdeia.cshtml"
       Write(Html.DisplayNameFor(model => model.Descricao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-sm-10 col-form-label\">\r\n            ");
#nullable restore
#line 25 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Comite\_DetalhesIdeia.cshtml"
       Write(Html.DisplayFor(model => model.Descricao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"hr-line-dashed\"></div>\r\n    <div class=\"form-group row\">\r\n        <div class=\"col-sm-2 col-form-label\">\r\n            ");
#nullable restore
#line 31 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Comite\_DetalhesIdeia.cshtml"
       Write(Html.DisplayNameFor(model => model.ProdutoNovo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-sm-10 col-form-label\">\r\n            ");
#nullable restore
#line 34 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Comite\_DetalhesIdeia.cshtml"
       Write(Html.DisplayFor(model => model.ProdutoNovo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"form-group row\">\r\n        <div class=\"col-sm-2 col-form-label\">\r\n            ");
#nullable restore
#line 39 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Comite\_DetalhesIdeia.cshtml"
       Write(Html.DisplayNameFor(model => model.ProdutoExistente));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-sm-10 col-form-label\">\r\n            ");
#nullable restore
#line 42 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Comite\_DetalhesIdeia.cshtml"
       Write(Html.DisplayFor(model => model.ProdutoExistente));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"hr-line-dashed\"></div>\r\n    <div class=\"form-group row\">\r\n        <div class=\"col-sm-2 col-form-label\">\r\n            ");
#nullable restore
#line 48 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Comite\_DetalhesIdeia.cshtml"
       Write(Html.DisplayNameFor(model => model.ExisteConcorrente));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-sm-10 col-form-label\">\r\n            ");
#nullable restore
#line 51 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Comite\_DetalhesIdeia.cshtml"
       Write(Html.DisplayFor(model => model.ExisteConcorrente));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"form-group row\">\r\n        <div class=\"col-sm-2 col-form-label\">\r\n            ");
#nullable restore
#line 56 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Comite\_DetalhesIdeia.cshtml"
       Write(Html.DisplayNameFor(model => model.DetalhesConcorrente));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-sm-10 col-form-label\">\r\n            ");
#nullable restore
#line 59 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Comite\_DetalhesIdeia.cshtml"
       Write(Html.DisplayFor(model => model.DetalhesConcorrente));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"hr-line-dashed\"></div>\r\n    <div class=\"form-group row\">\r\n        <div class=\"col-sm-2 col-form-label\">\r\n            ");
#nullable restore
#line 65 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Comite\_DetalhesIdeia.cshtml"
       Write(Html.DisplayNameFor(model => model.Argumentos));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-sm-10 col-form-label\">\r\n            ");
#nullable restore
#line 68 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Comite\_DetalhesIdeia.cshtml"
       Write(Html.DisplayFor(model => model.Argumentos));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"hr-line-dashed\"></div>\r\n    <div class=\"form-group row\">\r\n        <div class=\"col-sm-2 col-form-label\">\r\n            ");
#nullable restore
#line 74 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Comite\_DetalhesIdeia.cshtml"
       Write(Html.DisplayNameFor(model => model.DataSubAnalise));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-sm-10 col-form-label\">\r\n            ");
#nullable restore
#line 77 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Comite\_DetalhesIdeia.cshtml"
       Write(Html.DisplayFor(model => model.DataSubAnalise));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"hr-line-dashed\"></div>\r\n    <div class=\"form-group row\">\r\n        <div class=\"col-sm-2 col-form-label\">\r\n            ");
#nullable restore
#line 83 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Comite\_DetalhesIdeia.cshtml"
       Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-sm-10 col-form-label\">\r\n            ");
#nullable restore
#line 86 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Comite\_DetalhesIdeia.cshtml"
       Write(Html.DisplayFor(model => model.Status.Descricao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"hr-line-dashed\"></div>\r\n    <div class=\"ibox-title\">\r\n        <h5>Anexos</h5>\r\n    </div>\r\n    <div class=\"ibox-content\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "da3ecd44d1ee41902e3a07f74cc8b8426c82b18b12302", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 94 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Comite\_DetalhesIdeia.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IdeiasViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
