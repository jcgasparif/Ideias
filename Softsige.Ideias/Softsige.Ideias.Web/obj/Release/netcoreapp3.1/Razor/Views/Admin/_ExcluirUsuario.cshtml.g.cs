#pragma checksum "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Admin\_ExcluirUsuario.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e4cdd83150ba34cd4dc6b1b3bb276963d03dd24e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin__ExcluirUsuario), @"mvc.1.0.view", @"/Views/Admin/_ExcluirUsuario.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4cdd83150ba34cd4dc6b1b3bb276963d03dd24e", @"/Views/Admin/_ExcluirUsuario.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4aa704ea63e87d028d815a46f824577699ec6da8", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin__ExcluirUsuario : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""modal"" id=""modal-excluir-usuario"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
    <div class=""modal-dialog"">
        <div class=""modal-content animated"">
            <div class=""modal-header header-blue"">
                <i class=""fa fa-question-circle yellow-question-circle""></i>&nbsp;
                <h4 class=""modal-title"">Pergunta</h4>
                <button type=""button"" class=""close"" data-dismiss=""modal""><span class=""text-white"" aria-hidden=""true"">&times;</span><span class=""sr-only"">Fechar</span></button>
            </div>
            <div class=""modal-body"">
                <p>Deseja realmente excluir este usu??rio?</p>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-white"" data-dismiss=""modal"">N??o</button>
                <button id=""btnExcluirUsuario"" type=""button"" class=""btn btn-primary"">Sim</button>
            </div>
        </div>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
