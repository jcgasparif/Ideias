#pragma checksum "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Ideias\_ListaIdeias.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "937e48ef15ca479ff88c278dde86095c50da8717"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ideias__ListaIdeias), @"mvc.1.0.view", @"/Views/Ideias/_ListaIdeias.cshtml")]
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
#line 1 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Ideias\_ListaIdeias.cshtml"
using Softsige.Ideias.App.Core.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Ideias\_ListaIdeias.cshtml"
using Softsige.Ideias.Domain.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Ideias\_ListaIdeias.cshtml"
using Softsige.Ideias.App.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"937e48ef15ca479ff88c278dde86095c50da8717", @"/Views/Ideias/_ListaIdeias.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a8e98f311ea204c4fc04d0096f6324d1c32c8f7", @"/Views/_ViewImports.cshtml")]
    public class Views_Ideias__ListaIdeias : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IdeiasFiltroViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("disable-by-claim-name", "Ideias", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("disable-by-claim-value", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Visualizar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("disable-by-claim-value", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Editar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("disable-by-claim-value", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("modal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("#modal-excluir-ideia"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Excluir"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Enviar Ideia"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Ideias", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_14 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EnviarIdeiaParaAnalise", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_15 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ExcluirIdeias", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Softsige.Ideias.App.Core.Extensions.DesabilitaLinkByClaimTagHelper __Softsige_Ideias_App_Core_Extensions_DesabilitaLinkByClaimTagHelper;
        private global::Softsige.Ideias.App.Core.Extensions.ApagaElementoByUserIdTagHelper __Softsige_Ideias_App_Core_Extensions_ApagaElementoByUserIdTagHelper;
        private global::Softsige.Ideias.App.Core.Extensions.ApagaElementoByIdeiaIdTagHelper __Softsige_Ideias_App_Core_Extensions_ApagaElementoByIdeiaIdTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"
<div class=""table-responsive"">
    <table class=""table table-striped"">
        <thead>
            <tr>
                <th>Data de Inclus??o</th>
                <th>Descri????o</th>
                <th></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 17 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Ideias\_ListaIdeias.cshtml"
              
                if (Model.Any())
                {
                    foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 23 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Ideias\_ListaIdeias.cshtml"
                           Write(item.DataInclusao.ToString("dd/MM/yyyy HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 24 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Ideias\_ListaIdeias.cshtml"
                           Write(item.Descricao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"text-right\">\r\n                                <div class=\"btn-group\">\r\n\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "937e48ef15ca479ff88c278dde86095c50da871711414", async() => {
                WriteLiteral("\r\n                                        <spam class=\"fa fa-search\"></spam>\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Softsige_Ideias_App_Core_Extensions_DesabilitaLinkByClaimTagHelper = CreateTagHelper<global::Softsige.Ideias.App.Core.Extensions.DesabilitaLinkByClaimTagHelper>();
            __tagHelperExecutionContext.Add(__Softsige_Ideias_App_Core_Extensions_DesabilitaLinkByClaimTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Softsige_Ideias_App_Core_Extensions_DesabilitaLinkByClaimTagHelper.IdentityClaimName = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Softsige_Ideias_App_Core_Extensions_DesabilitaLinkByClaimTagHelper.IdentityClaimValue = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 28 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Ideias\_ListaIdeias.cshtml"
                                                                                                                                                    WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "937e48ef15ca479ff88c278dde86095c50da871714788", async() => {
                WriteLiteral("\r\n                                        <spam class=\"fa fa-pencil\"></spam>\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Softsige_Ideias_App_Core_Extensions_ApagaElementoByUserIdTagHelper = CreateTagHelper<global::Softsige.Ideias.App.Core.Extensions.ApagaElementoByUserIdTagHelper>();
            __tagHelperExecutionContext.Add(__Softsige_Ideias_App_Core_Extensions_ApagaElementoByUserIdTagHelper);
            __Softsige_Ideias_App_Core_Extensions_ApagaElementoByIdeiaIdTagHelper = CreateTagHelper<global::Softsige.Ideias.App.Core.Extensions.ApagaElementoByIdeiaIdTagHelper>();
            __tagHelperExecutionContext.Add(__Softsige_Ideias_App_Core_Extensions_ApagaElementoByIdeiaIdTagHelper);
            __Softsige_Ideias_App_Core_Extensions_DesabilitaLinkByClaimTagHelper = CreateTagHelper<global::Softsige.Ideias.App.Core.Extensions.DesabilitaLinkByClaimTagHelper>();
            __tagHelperExecutionContext.Add(__Softsige_Ideias_App_Core_Extensions_DesabilitaLinkByClaimTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Softsige_Ideias_App_Core_Extensions_DesabilitaLinkByClaimTagHelper.IdentityClaimName = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Softsige_Ideias_App_Core_Extensions_DesabilitaLinkByClaimTagHelper.IdentityClaimValue = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 32 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Ideias\_ListaIdeias.cshtml"
                                                                                                                                              WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 32 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Ideias\_ListaIdeias.cshtml"
                                                                                                                                                                            WriteLiteral(item.AspNetUsersId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Softsige_Ideias_App_Core_Extensions_ApagaElementoByUserIdTagHelper.IdentityUserId = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("suppress-by-userid", __Softsige_Ideias_App_Core_Extensions_ApagaElementoByUserIdTagHelper.IdentityUserId, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 32 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Ideias\_ListaIdeias.cshtml"
__Softsige_Ideias_App_Core_Extensions_ApagaElementoByIdeiaIdTagHelper.IdeiaId = item.Id;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("suppress-by-ideiaId", __Softsige_Ideias_App_Core_Extensions_ApagaElementoByIdeiaIdTagHelper.IdeiaId, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "937e48ef15ca479ff88c278dde86095c50da871720207", async() => {
                WriteLiteral("\r\n                                        <spam class=\"fa fa-trash\"></spam>\r\n                                    ");
            }
            );
            __Softsige_Ideias_App_Core_Extensions_ApagaElementoByUserIdTagHelper = CreateTagHelper<global::Softsige.Ideias.App.Core.Extensions.ApagaElementoByUserIdTagHelper>();
            __tagHelperExecutionContext.Add(__Softsige_Ideias_App_Core_Extensions_ApagaElementoByUserIdTagHelper);
            __Softsige_Ideias_App_Core_Extensions_ApagaElementoByIdeiaIdTagHelper = CreateTagHelper<global::Softsige.Ideias.App.Core.Extensions.ApagaElementoByIdeiaIdTagHelper>();
            __tagHelperExecutionContext.Add(__Softsige_Ideias_App_Core_Extensions_ApagaElementoByIdeiaIdTagHelper);
            __Softsige_Ideias_App_Core_Extensions_DesabilitaLinkByClaimTagHelper = CreateTagHelper<global::Softsige.Ideias.App.Core.Extensions.DesabilitaLinkByClaimTagHelper>();
            __tagHelperExecutionContext.Add(__Softsige_Ideias_App_Core_Extensions_DesabilitaLinkByClaimTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Softsige_Ideias_App_Core_Extensions_DesabilitaLinkByClaimTagHelper.IdentityClaimName = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Softsige_Ideias_App_Core_Extensions_DesabilitaLinkByClaimTagHelper.IdentityClaimValue = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 36 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Ideias\_ListaIdeias.cshtml"
                                                                                                                                    WriteLiteral(item.AspNetUsersId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Softsige_Ideias_App_Core_Extensions_ApagaElementoByUserIdTagHelper.IdentityUserId = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("suppress-by-userid", __Softsige_Ideias_App_Core_Extensions_ApagaElementoByUserIdTagHelper.IdentityUserId, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 36 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Ideias\_ListaIdeias.cshtml"
__Softsige_Ideias_App_Core_Extensions_ApagaElementoByIdeiaIdTagHelper.IdeiaId = item.Id;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("suppress-by-ideiaId", __Softsige_Ideias_App_Core_Extensions_ApagaElementoByIdeiaIdTagHelper.IdeiaId, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 36 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Ideias\_ListaIdeias.cshtml"
                                                                                                                                                                                                        Write(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-id", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 40 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Ideias\_ListaIdeias.cshtml"
                                     if (item.StatusId == StatusEnum.IdeiaCriada.ToInt())
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "937e48ef15ca479ff88c278dde86095c50da871725264", async() => {
                WriteLiteral("\r\n                                            <spam class=\"fa fa-comments\"></spam>\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_13.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_13);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_14.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_14);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 42 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Ideias\_ListaIdeias.cshtml"
                                                                                                                                                    WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("\r\n");
#nullable restore
#line 45 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Ideias\_ListaIdeias.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </div>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 49 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Ideias\_ListaIdeias.cshtml"
                    }
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td colspan=\"3\">Nenhuma ideia encontrada</td>\r\n                    </tr>\r\n");
#nullable restore
#line 56 "C:\Users\JCGAPARIF\source\Workspaces\Ideias Marchesan\Softsige.Ideias\Softsige.Ideias.Web\Views\Ideias\_ListaIdeias.cshtml"
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "937e48ef15ca479ff88c278dde86095c50da871729221", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_15.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_15);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IdeiasFiltroViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
