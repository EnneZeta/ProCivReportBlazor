#pragma checksum "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d781e60d62324cea41888ec1ef2bcfae2bb13bdb"
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
#line 12 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor"
                  paths

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(3, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 12 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor"
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
                __builder2.AddMarkupContent(10, "<label><strong>Allegato al Verbale Nr: </strong><input type=\"text\"></label>\r\n        ");
                __builder2.AddMarkupContent(11, "<label><strong>del: </strong><input type=\"text\"></label>\r\n        ");
                __builder2.OpenElement(12, "input");
                __builder2.AddAttribute(13, "type", "button");
                __builder2.AddAttribute(14, "value", "Aggiungi riga");
                __builder2.AddAttribute(15, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 18 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor"
                                                             e => { AddRow(); }

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseElement();
                __builder2.CloseElement();
#nullable restore
#line 20 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor"
     for (int i = 0; i < MaxNumber; i++)
    {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(16, "label");
                __builder2.AddMarkupContent(17, "<strong>Lampione N.: </strong>");
                __builder2.OpenElement(18, "input");
                __builder2.AddAttribute(19, "type", "text");
                __builder2.AddAttribute(20, "id", 
#nullable restore
#line 22 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor"
                                                                      "lamp" + i

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(21, "\r\n        ");
                __builder2.OpenElement(22, "label");
                __builder2.AddMarkupContent(23, "<strong>Via: </strong>");
                __builder2.OpenElement(24, "input");
                __builder2.AddAttribute(25, "type", "text");
                __builder2.AddAttribute(26, "id", 
#nullable restore
#line 23 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor"
                                                              "via" + i

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(27, "\r\n        ");
                __builder2.OpenElement(28, "label");
                __builder2.AddMarkupContent(29, "<strong>Civico: </strong>");
                __builder2.OpenElement(30, "input");
                __builder2.AddAttribute(31, "type", "text");
                __builder2.AddAttribute(32, "id", 
#nullable restore
#line 24 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor"
                                                                 "civico" + i

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(33, "\r\n        <br>");
#nullable restore
#line 26 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor"
    }

#line default
#line hidden
#nullable disable
                __builder2.AddMarkupContent(34, "<button type=\"submit\">Salva</button>");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 30 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\GuastiIlluminazione.razor"
       
    private Paths paths = new() { StreetList = new List<Street>() };

    private string[] WeatherForecast;

    private async Task HandleValidSubmit()
    {
        WeatherForecast = await _http.GetFromJsonAsync<string[]>("api/Values");

    }

    private int MaxNumber = 1;

    private void AddRow()
    {
        MaxNumber++;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient _http { get; set; }
    }
}
#pragma warning restore 1591
