#pragma checksum "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cc1f6bf31e53cffa42e5be334308ef485b7c8355"
// <auto-generated/>
#pragma warning disable 1591
namespace ProCivReport.Pages
{
    #line hidden
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\_Imports.razor"
using ProCivReport;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\_Imports.razor"
using ProCivReport.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\_Imports.razor"
using System.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\_Imports.razor"
using System.Data.SqlClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor"
using ProCivReport.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor"
using System;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor"
using System.Runtime.CompilerServices;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor"
using ProCivReport.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/guasti")]
    public partial class GuastiIlluminazione : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Segnalazione Guasti Pubblica Illuminazione</h1>\r\n\r\n\r\n\r\n");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(1);
            __builder.AddAttribute(2, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 14 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor"
                  _persistency.LightingBreakdowns

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(3, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 14 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor"
                                                                   HandleValidSubmit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(4, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(5);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(6, "\r\n    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(7);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(8, "\r\n    ");
                __builder2.OpenElement(9, "p");
                __builder2.OpenElement(10, "label");
                __builder2.AddMarkupContent(11, "<strong>Allegato al Verbale Nr: </strong>");
                __builder2.OpenElement(12, "input");
                __builder2.AddAttribute(13, "type", "text");
                __builder2.AddAttribute(14, "id", "reportNumber");
                __builder2.AddAttribute(15, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 18 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor"
                                                                                                    _persistency.ServiceReport.ReportNumber

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(16, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _persistency.ServiceReport.ReportNumber = __value, _persistency.ServiceReport.ReportNumber));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(17, "\r\n        ");
                __builder2.OpenElement(18, "label");
                __builder2.AddMarkupContent(19, "<strong>del: </strong>");
                __builder2.OpenElement(20, "input");
                __builder2.AddAttribute(21, "type", "text");
                __builder2.AddAttribute(22, "id", "date");
                __builder2.AddAttribute(23, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 19 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor"
                                                                         _persistency.ServiceReport.Date

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(24, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _persistency.ServiceReport.Date = __value, _persistency.ServiceReport.Date));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(25, "\r\n        ");
                __builder2.OpenElement(26, "input");
                __builder2.AddAttribute(27, "type", "button");
                __builder2.AddAttribute(28, "value", "Aggiungi riga");
                __builder2.AddAttribute(29, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 20 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor"
                                                             e => { AddRow(); }

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseElement();
                __builder2.CloseElement();
#nullable restore
#line 22 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor"
     for (int i = 0; i < _maxNumber; i++)
    {
        var localVariable = i;

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(30, "label");
                __builder2.AddMarkupContent(31, "<strong>Lampione N.: </strong>");
                __builder2.OpenElement(32, "input");
                __builder2.AddAttribute(33, "type", "text");
                __builder2.AddAttribute(34, "id", 
#nullable restore
#line 25 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor"
                                                                      "lamp" + i

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(35, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 25 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor"
                                                                                          _lightingBreakdowns.Breaks[localVariable].Light

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(36, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _lightingBreakdowns.Breaks[localVariable].Light = __value, _lightingBreakdowns.Breaks[localVariable].Light));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(37, "\r\n        ");
                __builder2.OpenElement(38, "label");
                __builder2.AddMarkupContent(39, "<strong>Via: </strong>");
                __builder2.OpenElement(40, "input");
                __builder2.AddAttribute(41, "type", "text");
                __builder2.AddAttribute(42, "id", 
#nullable restore
#line 26 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor"
                                                              "via" + i

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(43, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 26 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor"
                                                                                 _lightingBreakdowns.Breaks[localVariable].Street

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(44, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _lightingBreakdowns.Breaks[localVariable].Street = __value, _lightingBreakdowns.Breaks[localVariable].Street));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(45, "\r\n        ");
                __builder2.OpenElement(46, "label");
                __builder2.AddMarkupContent(47, "<strong>Civico: </strong>");
                __builder2.OpenElement(48, "input");
                __builder2.AddAttribute(49, "type", "text");
                __builder2.AddAttribute(50, "id", 
#nullable restore
#line 27 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor"
                                                                 "civico" + i

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(51, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 27 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor"
                                                                                       _lightingBreakdowns.Breaks[localVariable].StreetNumber

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(52, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _lightingBreakdowns.Breaks[localVariable].StreetNumber = __value, _lightingBreakdowns.Breaks[localVariable].StreetNumber));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(53, "\r\n        <br>");
#nullable restore
#line 29 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor"
    }

#line default
#line hidden
#nullable disable
                __builder2.AddMarkupContent(54, "<button type=\"submit\">Salva</button>");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Persistency _persistency { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient _http { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime _jsRuntime { get; set; }
    }
}
#pragma warning restore 1591
