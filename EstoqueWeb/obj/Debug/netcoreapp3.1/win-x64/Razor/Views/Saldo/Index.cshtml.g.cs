#pragma checksum "E:\GitHub\EstoqueWeb\Views\Saldo\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7764dde52bfb8967f89fca990344f556c5d7cbf7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Saldo_Index), @"mvc.1.0.view", @"/Views/Saldo/Index.cshtml")]
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
#line 1 "E:\GitHub\EstoqueWeb\Views\_ViewImports.cshtml"
using EstoqueBarbanera;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\GitHub\EstoqueWeb\Views\_ViewImports.cshtml"
using EstoqueBarbanera.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7764dde52bfb8967f89fca990344f556c5d7cbf7", @"/Views/Saldo/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fae11600c2ef857c40d2eb2758ac55feeaa5a676", @"/Views/_ViewImports.cshtml")]
    public class Views_Saldo_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EstoqueBarbanera.Models.Saldo>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Descricao", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Produto", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Prateleira", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Grupo", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", new global::Microsoft.AspNetCore.Html.HtmlString("Procurar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-top: 5px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Procurar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\GitHub\EstoqueWeb\Views\Saldo\Index.cshtml"
   int i = 0;
    if (!(Model is null))
    {
        i = Model.Count();
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 10 "E:\GitHub\EstoqueWeb\Views\Saldo\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h4>Procurar Saldo</h4>\r\n<hr />\r\n<div>\r\n    <div class=\"container-fluid mr-3 py-3 px-3 border bg-secondary\">\r\n        <div class=\"row bg-dark\">\r\n            <div class=\"col border bg-danger\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7764dde52bfb8967f89fca990344f556c5d7cbf78154", async() => {
                WriteLiteral("\r\n                    <div class=\"form-group\">\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7764dde52bfb8967f89fca990344f556c5d7cbf78486", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 23 "E:\GitHub\EstoqueWeb\Views\Saldo\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.All;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        <div>\r\n                            <label class=\"control-label\">Tipo</label>\r\n                            <select class=\"form-control\" name=\"selecao\">\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7764dde52bfb8967f89fca990344f556c5d7cbf710333", async() => {
                    WriteLiteral("Descricao");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7764dde52bfb8967f89fca990344f556c5d7cbf711592", async() => {
                    WriteLiteral("Produto");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7764dde52bfb8967f89fca990344f556c5d7cbf712849", async() => {
                    WriteLiteral("Prateleira");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7764dde52bfb8967f89fca990344f556c5d7cbf714109", async() => {
                    WriteLiteral("Grupo");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            </select>\r\n                            <label class=\"control-label \">Texto a Procurar</label>\r\n                            <input type=\"text\" name=\"texto\" class=\"form-control\" />\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7764dde52bfb8967f89fca990344f556c5d7cbf715582", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            <label style=\"display: block; width: 40%; float: right; border: red solid 1px; margin: 5px;\">");
#nullable restore
#line 35 "E:\GitHub\EstoqueWeb\Views\Saldo\Index.cshtml"
                                                                                                                    Write(i);

#line default
#line hidden
#nullable disable
                WriteLiteral(" Linhas</label>\r\n                        </div>\r\n                    </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
            <div class=""col border"">
                <button onclick=""alert('Para Fazer Export de Saldos faca \n\n\t-Saldos (Demais Colunas) \n\t-Itens de Estoque (Atualiza a coluna M_Kg) \n\n\t Botão SqlServer')"" class=""m-5 btn btn-primary"">Export Saldo</button>
                
            </div>
            <div class=""col border"">row1 col3</div>
        </div>
        <div class=""row"">
            <div class=""col border"">row2 col1</div>
            <div class=""col border"">row2 col2</div>
            <div class=""col border"">row2 col3</div>
        </div>
    </div>
");
            WriteLiteral(@"    <div class=""sticky-top"" style=""width:3110px;"">
        <table class=""table"">
            <thead style=""background-color:white"">
                <tr>
                    <th scope=""col"" style=""width:200px"">Produto</th>
                    <th scope=""col"" style=""width:630px"">Descricao</th>
                    <th scope=""col"" style=""width:10px"">Unid</th>
                    <th scope=""col"" style=""width:110px"">SaldoAtual</th>
                    <th scope=""col"" style=""width:130px"">PedCompras</th>
                    <th scope=""col"" style=""width:130px"">PrevFabric</th>
                    <th scope=""col"" style=""width:130px"">EstqMínimo</th>
                    <th scope=""col"" style=""width:130px"">ConsuPrevOs</th>
                    <th scope=""col"" style=""width:130px"">EstqMáximo</th>
                    <th scope=""col"" style=""width:110px"">Prateleira</th>
                    <th scope=""col"" style=""width:130px"">PedVendas</th>
                    <th scope=""col"" style=""width:100px"">Grupo</th>
       ");
            WriteLiteral(@"             <th scope=""col"" style=""width:180px"">DiassemMovimento</th>
                    <th scope=""col"" style=""width:100px"">M_Kg</th>
                    <th scope=""col"" style=""width:130px"">ForaEstoque</th>
                    <th scope=""col"" style=""width:130px"">DeTerceiros</th>
                </tr>
            </thead>

        </table>
    </div>
    <div style=""width:3110px;"">
        <table class=""table"">

            <tbody>
");
#nullable restore
#line 82 "E:\GitHub\EstoqueWeb\Views\Saldo\Index.cshtml"
                 if (i > 0)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 84 "E:\GitHub\EstoqueWeb\Views\Saldo\Index.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td style=\"width:200px; text-align: left;\">");
#nullable restore
#line 87 "E:\GitHub\EstoqueWeb\Views\Saldo\Index.cshtml"
                                                                  Write(Html.DisplayFor(modelItem => item.Produto));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td style=\"width:630px; text-align: left;\">");
#nullable restore
#line 88 "E:\GitHub\EstoqueWeb\Views\Saldo\Index.cshtml"
                                                                  Write(Html.DisplayFor(modelItem => item.Descricao));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td style=\"width:10px; text-align: center;\"> ");
#nullable restore
#line 89 "E:\GitHub\EstoqueWeb\Views\Saldo\Index.cshtml"
                                                                    Write(Html.DisplayFor(modelItem => item.Unid));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td style=\"width:110px; text-align: center;\"> ");
#nullable restore
#line 90 "E:\GitHub\EstoqueWeb\Views\Saldo\Index.cshtml"
                                                                     Write(Html.DisplayFor(modelItem => item.SaldoAtual));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td style=\"width:130px; text-align: center;\"> ");
#nullable restore
#line 91 "E:\GitHub\EstoqueWeb\Views\Saldo\Index.cshtml"
                                                                     Write(Html.DisplayFor(modelItem => item.PedCompras));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td style=\"width:130px; text-align: center;\"> ");
#nullable restore
#line 92 "E:\GitHub\EstoqueWeb\Views\Saldo\Index.cshtml"
                                                                     Write(Html.DisplayFor(modelItem => item.PrevFabric));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td style=\"width:130px; text-align: center;\"> ");
#nullable restore
#line 93 "E:\GitHub\EstoqueWeb\Views\Saldo\Index.cshtml"
                                                                     Write(Html.DisplayFor(modelItem => item.EstqMinimo));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td style=\"width:130px; text-align: center;\"> ");
#nullable restore
#line 94 "E:\GitHub\EstoqueWeb\Views\Saldo\Index.cshtml"
                                                                     Write(Html.DisplayFor(modelItem => item.ConsuPrevOs));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td style=\"width:130px; text-align: center;\"> ");
#nullable restore
#line 95 "E:\GitHub\EstoqueWeb\Views\Saldo\Index.cshtml"
                                                                     Write(Html.DisplayFor(modelItem => item.EstqMaximo));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td style=\"width:110px; text-align: center;\"> ");
#nullable restore
#line 96 "E:\GitHub\EstoqueWeb\Views\Saldo\Index.cshtml"
                                                                     Write(Html.DisplayFor(modelItem => item.Prateleira));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td style=\"width:130px; text-align: center;\"> ");
#nullable restore
#line 97 "E:\GitHub\EstoqueWeb\Views\Saldo\Index.cshtml"
                                                                     Write(Html.DisplayFor(modelItem => item.PedVendas));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td style=\"width:100px; text-align: center;\">   ");
#nullable restore
#line 98 "E:\GitHub\EstoqueWeb\Views\Saldo\Index.cshtml"
                                                                       Write(Html.DisplayFor(modelItem => item.Grupo));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td style=\"width:180px; text-align: center;\"> ");
#nullable restore
#line 99 "E:\GitHub\EstoqueWeb\Views\Saldo\Index.cshtml"
                                                                     Write(Html.DisplayFor(modelItem => item.DiassemMovimento));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td style=\"width:110px; text-align: center;\"> ");
#nullable restore
#line 100 "E:\GitHub\EstoqueWeb\Views\Saldo\Index.cshtml"
                                                                     Write(Html.DisplayFor(modelItem => item.AguardandoCQ));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td style=\"width:130px; text-align: center;\"> ");
#nullable restore
#line 101 "E:\GitHub\EstoqueWeb\Views\Saldo\Index.cshtml"
                                                                     Write(Html.DisplayFor(modelItem => item.ForaEstoque));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td style=\"width:130px; text-align: center;\"> ");
#nullable restore
#line 102 "E:\GitHub\EstoqueWeb\Views\Saldo\Index.cshtml"
                                                                     Write(Html.DisplayFor(modelItem => item.DeTerceiros));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 104 "E:\GitHub\EstoqueWeb\Views\Saldo\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 104 "E:\GitHub\EstoqueWeb\Views\Saldo\Index.cshtml"
                     
                }
                else
                {

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n\r\n</div>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EstoqueBarbanera.Models.Saldo>> Html { get; private set; }
    }
}
#pragma warning restore 1591
