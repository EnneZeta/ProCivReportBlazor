// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace ProCivReport.Pages
{
    #line hidden
    using System;
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
#line 2 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\Counter.razor"
using Microsoft.Extensions.Logging;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/counter")]
    public partial class Counter : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 38 "C:\Users\zazzaroa\source\repos\ProCivReportBlazor\Pages\Counter.razor"
       

    private Paths paths = new() { StreetList = new List<Street>() };

    private int Index = 0;

    private async Task HasClicked(int CheckID)
    {
        await JSRuntime.InvokeVoidAsync("disableCheckbox", CheckID, "");
    }

    private async Task HandleValidSubmit()
    {
        paths.StreetList = new();
        Index = 0;

        await JSRuntime.InvokeVoidAsync("enableCheckbox");

        if (paths.NrPath == "Nr1")
        {
            paths.StreetList.Add(new Street { Id = 1, Name = "Via Armaroli" });
            paths.StreetList.Add(new Street { Id = 2, Name = "Via Roma" });
            paths.StreetList.Add(new Street { Id = 3, Name = "Via Stelloni Ponente" });
            paths.StreetList.Add(new Street { Id = 4, Name = "Via Verde" });
            paths.StreetList.Add(new Street { Id = 5, Name = "Via Stelloni Ponente" });
            paths.StreetList.Add(new Street { Id = 6, Name = "Via Valtiera" });
            paths.StreetList.Add(new Street { Id = 7, Name = "Via Ferrovia" });
            paths.StreetList.Add(new Street { Id = 8, Name = "Tavernelle Parco" });
            paths.StreetList.Add(new Street { Id = 9, Name = "Via Nadalini" });
            paths.StreetList.Add(new Street { Id = 10, Name = "Via Ferrovia" });
            paths.StreetList.Add(new Street { Id = 11, Name = "Via Persicetana" });
            paths.StreetList.Add(new Street { Id = 12, Name = "Via Sacernia" });
            paths.StreetList.Add(new Street { Id = 13, Name = "Via Di Mezzo Ponente (fino al ponte)" });
            paths.StreetList.Add(new Street { Id = 14, Name = "Via Bacciliera (fino a cea)" });
            paths.StreetList.Add(new Street { Id = 15, Name = "Via di Mezzo Levante" });
            paths.StreetList.Add(new Street { Id = 16, Name = "Via Punta (Sotto Bologna)" });
            paths.StreetList.Add(new Street { Id = 17, Name = "Via Vivaio (Sotto Bologna)" });
            paths.StreetList.Add(new Street { Id = 18, Name = "Via Persicetana" });
            paths.StreetList.Add(new Street { Id = 19, Name = "Rotonda Bai" });
            paths.StreetList.Add(new Street { Id = 20, Name = "Via Giovanni Paolo II" });
            paths.StreetList.Add(new Street { Id = 21, Name = "Via Marcheselli" });
            paths.StreetList.Add(new Street { Id = 22, Name = "Rotonda Gandhi" });
            paths.StreetList.Add(new Street { Id = 23, Name = "Via Caduti di Ustica" });
            paths.StreetList.Add(new Street { Id = 24, Name = "Rotonda Gandhi" });
            paths.StreetList.Add(new Street { Id = 25, Name = "Via Armaroli" });
            paths.StreetList.Add(new Street { Id = 26, Name = "Via King" });
            paths.StreetList.Add(new Street { Id = 27, Name = "Via Rizzola Levante" });
            paths.StreetList.Add(new Street { Id = 28, Name = "Via del Campo" });
            paths.StreetList.Add(new Street { Id = 29, Name = "Via Collodi" });
            paths.StreetList.Add(new Street { Id = 30, Name = "Rotonda Pradazzo" });
            paths.StreetList.Add(new Street { Id = 31, Name = "Via Pradazzo" });
            paths.StreetList.Add(new Street { Id = 32, Name = "Via Garibaldi" });
            paths.StreetList.Add(new Street { Id = 33, Name = "Rotonda Bersaglieri" });
            paths.StreetList.Add(new Street { Id = 34, Name = "Via Rizzola Ponente" });
            paths.StreetList.Add(new Street { Id = 35, Name = "Via da Vinci" });
            paths.StreetList.Add(new Street { Id = 36, Name = "Via della Mimosa" });
            paths.StreetList.Add(new Street { Id = 37, Name = "Via Bazzane" });
            paths.StreetList.Add(new Street { Id = 38, Name = "Via Puccini" });
            paths.StreetList.Add(new Street { Id = 39, Name = "Via Roma" });
            paths.StreetList.Add(new Street { Id = 40, Name = "Via Armaroli" });
        }

        if (paths.NrPath == "Nr2")
        {
            paths.StreetList.Add(new Street { Id = 41, Name = "Via Armaroli" });
            paths.StreetList.Add(new Street { Id = 42, Name = "Via Roma" });
            paths.StreetList.Add(new Street { Id = 43, Name = "Via Pierantoni" });
            paths.StreetList.Add(new Street { Id = 44, Name = "Via Roma" });
            paths.StreetList.Add(new Street { Id = 45, Name = "Via Bazzane" });
            paths.StreetList.Add(new Street { Id = 46, Name = "Via Verdi" });
            paths.StreetList.Add(new Street { Id = 47, Name = "Via Parcheggio Via Verdi" });
            paths.StreetList.Add(new Street { Id = 48, Name = "Via Bazzane" });
            paths.StreetList.Add(new Street { Id = 49, Name = "Via Moro" });
            paths.StreetList.Add(new Street { Id = 50, Name = "Via Alpi" });
            paths.StreetList.Add(new Street { Id = 51, Name = "Via Delle Rose" });
            paths.StreetList.Add(new Street { Id = 52, Name = "Via Turati" });
            paths.StreetList.Add(new Street { Id = 53, Name = "Via dei Glicini" });
            paths.StreetList.Add(new Street { Id = 54, Name = "Via Dello Sport" });
            paths.StreetList.Add(new Street { Id = 55, Name = "Piazza 44410" });
            paths.StreetList.Add(new Street { Id = 56, Name = "Via Moro" });
            paths.StreetList.Add(new Street { Id = 57, Name = "Via Turati" });
            paths.StreetList.Add(new Street { Id = 58, Name = "Piazza Ex Poliambulatorio" });
            paths.StreetList.Add(new Street { Id = 59, Name = "Via Turati" });
            paths.StreetList.Add(new Street { Id = 60, Name = "Via Gramsci" });
            paths.StreetList.Add(new Street { Id = 61, Name = "Via Roma (fino al sottopasso pedonale)" });
            paths.StreetList.Add(new Street { Id = 62, Name = "Via Rizzola Ponente" });
            paths.StreetList.Add(new Street { Id = 63, Name = "Via Vittime 11 Settembre" });
            paths.StreetList.Add(new Street { Id = 64, Name = "Via Gramsci" });
            paths.StreetList.Add(new Street { Id = 65, Name = "Zona Orti" });
            paths.StreetList.Add(new Street { Id = 66, Name = "Via Gramsci" });
            paths.StreetList.Add(new Street { Id = 67, Name = "Via Vittime 11 Settembre" });
            paths.StreetList.Add(new Street { Id = 68, Name = "Via Rizzola Ponente" });
            paths.StreetList.Add(new Street { Id = 69, Name = "Via Roma" });
            paths.StreetList.Add(new Street { Id = 70, Name = "Via del Bracciante" });
            paths.StreetList.Add(new Street { Id = 71, Name = "Via Perlasca" });
            paths.StreetList.Add(new Street { Id = 72, Name = "Via Levi" });
            paths.StreetList.Add(new Street { Id = 73, Name = "Via del Bracciante" });
            paths.StreetList.Add(new Street { Id = 74, Name = "Via Allende" });
            paths.StreetList.Add(new Street { Id = 75, Name = "Via del Bracciante" });
            paths.StreetList.Add(new Street { Id = 76, Name = "Via Dell'artigiano" });
            paths.StreetList.Add(new Street { Id = 77, Name = "Rotonda Matteotti" });
            paths.StreetList.Add(new Street { Id = 78, Name = "Via Matteotti" });
            paths.StreetList.Add(new Street { Id = 79, Name = "Rotonda presso Via Berlinguer" });
            paths.StreetList.Add(new Street { Id = 80, Name = "Via Iotti" });
            paths.StreetList.Add(new Street { Id = 81, Name = "Rotonda presso Via Berlinguer" });
            paths.StreetList.Add(new Street { Id = 82, Name = "Via Matteotti" });
            paths.StreetList.Add(new Street { Id = 83, Name = "Via Buozzi" });
            paths.StreetList.Add(new Street { Id = 84, Name = "Via Di Vittorio" });
            paths.StreetList.Add(new Street { Id = 85, Name = "Via 44317" });
            paths.StreetList.Add(new Street { Id = 86, Name = "Piazza Della Resistenza" });
            paths.StreetList.Add(new Street { Id = 87, Name = "Piazza Della Pace" });
            paths.StreetList.Add(new Street { Id = 88, Name = "Rotonda Falcone" });
            paths.StreetList.Add(new Street { Id = 89, Name = "Piazza Marconi" });
            paths.StreetList.Add(new Street { Id = 90, Name = "Via  Roma" });
            paths.StreetList.Add(new Street { Id = 91, Name = "Via Gramsci" });
            paths.StreetList.Add(new Street { Id = 92, Name = "Via Armaroli" });
        }

        if (paths.NrPath == "Nr3")
        {
            paths.StreetList.Add(new Street{Id = 93, Name = "Via Armaroli"});
            paths.StreetList.Add(new Street{Id = 94, Name = "Via Pertini"});
            paths.StreetList.Add(new Street{Id = 95, Name = "Rotonda Bersaglieri"});
            paths.StreetList.Add(new Street{Id = 96, Name = "Via Giovanni Paolo II"});
            paths.StreetList.Add(new Street{Id = 97, Name = "Rotonda Bai"});
            paths.StreetList.Add(new Street{Id = 98, Name = "Via De Gasperi"});
            paths.StreetList.Add(new Street{Id = 99, Name = "Via  Bargellino"});
            paths.StreetList.Add(new Street{Id = 100, Name = "Via Dell'Industria"});
            paths.StreetList.Add(new Street{Id = 101, Name = "Rotonda Senza Nome"});
            paths.StreetList.Add(new Street{Id = 102, Name = "Via Roma Sud"});
            paths.StreetList.Add(new Street{Id = 103, Name = "Via Marzocchi"});
            paths.StreetList.Add(new Street{Id = 104, Name = "Via XXV Aprile"});
            paths.StreetList.Add(new Street{Id = 105, Name = "Via Ropa"});
            paths.StreetList.Add(new Street{Id = 106, Name = "Via Castagnini"});
            paths.StreetList.Add(new Street{Id = 107, Name = "Via Ropa"});
            paths.StreetList.Add(new Street{Id = 108, Name = "Via Baravelli"});
            paths.StreetList.Add(new Street{Id = 109, Name = "Via Piretti"});
            paths.StreetList.Add(new Street{Id = 110, Name = "Via Turrini"});
            paths.StreetList.Add(new Street{Id = 111, Name = "Via Corazza"});
            paths.StreetList.Add(new Street{Id = 112, Name = "Via Pizzoli"});
            paths.StreetList.Add(new Street{Id = 113, Name = "Via Grassilli"});
            paths.StreetList.Add(new Street{Id = 114, Name = "Via Gazzani"});
            paths.StreetList.Add(new Street{Id = 115, Name = "Via Stagni"});
            paths.StreetList.Add(new Street{Id = 116, Name = "Via Bizzarri"});
            paths.StreetList.Add(new Street{Id = 117, Name = "Via Mingozzi"});
            paths.StreetList.Add(new Street{Id = 118, Name = "Rotonda Harley Davidson"});
            paths.StreetList.Add(new Street{Id = 119, Name = "Via Persicetana"});
            paths.StreetList.Add(new Street{Id = 120, Name = "Via Bastia"});
            paths.StreetList.Add(new Street{Id = 121, Name = "Via Bizzarri"});
            paths.StreetList.Add(new Street{Id = 122, Name = "Via Grassilli"});
            paths.StreetList.Add(new Street{Id = 123, Name = "Via Finelli"});
            paths.StreetList.Add(new Street{Id = 124, Name = "Via Commenda"});
            paths.StreetList.Add(new Street{Id = 125, Name = "Via Della Salute"});
            paths.StreetList.Add(new Street{Id = 126, Name = "Rotonda Di Matteo"});
            paths.StreetList.Add(new Street{Id = 127, Name = "Via Stazione Bargellino"});
            paths.StreetList.Add(new Street{Id = 128, Name = "Rotonda Di Matteo"});
            paths.StreetList.Add(new Street{Id = 129, Name = "Via Torretta"});
            paths.StreetList.Add(new Street{Id = 130, Name = "Rotonda Di Matteo"});
            paths.StreetList.Add(new Street{Id = 131, Name = "Via Marcheselli"});
            paths.StreetList.Add(new Street{Id = 132, Name = "Rotonda Gandhi"});
            paths.StreetList.Add(new Street{Id = 133, Name = "Via Marcheselli"});
            paths.StreetList.Add(new Street{Id = 134, Name = "Via Giovanni Paolo II"});
            paths.StreetList.Add(new Street{Id = 135, Name = "Rotonda Bersaglieri"});
            paths.StreetList.Add(new Street{Id = 136, Name = "Via Pertini"});
            paths.StreetList.Add(new Street{Id = 137, Name = "Via Armaroli"});
        }

        if (paths.NrPath == "Nr4")
        {
            paths.StreetList.Add(new Street { Id = 138, Name = "Via Armaroli" });
            paths.StreetList.Add(new Street { Id = 139, Name = "Via Pertini" });
            paths.StreetList.Add(new Street { Id = 140, Name = "Via Prati" });
            paths.StreetList.Add(new Street { Id = 141, Name = "Via Fornace" });
            paths.StreetList.Add(new Street { Id = 142, Name = "Via Pilastrino" });
            paths.StreetList.Add(new Street { Id = 143, Name = "Via CastelCampeggi" });
            paths.StreetList.Add(new Street { Id = 144, Name = "Via Passo Pioppe" });
            paths.StreetList.Add(new Street { Id = 145, Name = "Via Longarola" });
            paths.StreetList.Add(new Street { Id = 146, Name = "Via Don Fornasari" });
            paths.StreetList.Add(new Street { Id = 147, Name = "Via Caduti della libertà" });
            paths.StreetList.Add(new Street { Id = 148, Name = "Via Arbizzani" });
            paths.StreetList.Add(new Street { Id = 149, Name = "Via Longarola" });
            paths.StreetList.Add(new Street { Id = 150, Name = "Via San Michele" });
            paths.StreetList.Add(new Street { Id = 151, Name = "Via Longarola" });
            paths.StreetList.Add(new Street { Id = 152, Name = "Via Costa" });
            paths.StreetList.Add(new Street { Id = 153, Name = "Via Fellini" });
            paths.StreetList.Add(new Street { Id = 154, Name = "Via Pasolini" });
            paths.StreetList.Add(new Street { Id = 155, Name = "Via Zucchelli" });
            paths.StreetList.Add(new Street { Id = 156, Name = "Via Marchesini" });
            paths.StreetList.Add(new Street { Id = 157, Name = "Rotonda De Pisis" });
            paths.StreetList.Add(new Street { Id = 158, Name = "Via Longarola" });
            paths.StreetList.Add(new Street { Id = 159, Name = "Via Fabbreria" });
            paths.StreetList.Add(new Street { Id = 160, Name = "Via Barleta" });
            paths.StreetList.Add(new Street { Id = 161, Name = "Vicolo Parma" });
            paths.StreetList.Add(new Street { Id = 162, Name = "Via Longarola" });
            paths.StreetList.Add(new Street { Id = 163, Name = "Via Larga" });
            paths.StreetList.Add(new Street { Id = 164, Name = "Via Valli" });
            paths.StreetList.Add(new Street { Id = 165, Name = "Via Prati" });
            paths.StreetList.Add(new Street { Id = 166, Name = "Via Calanchi" });
            paths.StreetList.Add(new Street { Id = 167, Name = "Via Turati (Sala Bolognese)" });
            paths.StreetList.Add(new Street { Id = 168, Name = "Via Stelloni Ponente" });
            paths.StreetList.Add(new Street { Id = 169, Name = "Via Roma" });
            paths.StreetList.Add(new Street { Id = 170, Name = "Via Armaroli" });
        }

        if (paths.NrPath == "Nr5")
        {
            paths.StreetList.Add(new Street { Id = 171, Name = "Via Armaroli" });
            paths.StreetList.Add(new Street { Id = 172, Name = "Via Roma" });
            paths.StreetList.Add(new Street { Id = 173, Name = "Rotonda Falcone" });
            paths.StreetList.Add(new Street { Id = 174, Name = "Via Roma" });
            paths.StreetList.Add(new Street { Id = 175, Name = "Via Garibaldi" });
            paths.StreetList.Add(new Street { Id = 176, Name = "Via Mazzini" });
            paths.StreetList.Add(new Street { Id = 177, Name = "Via Garibaldi" });
            paths.StreetList.Add(new Street { Id = 178, Name = "Rotonda Bersaglieri" });
            paths.StreetList.Add(new Street { Id = 179, Name = "Via Garibaldi" });
            paths.StreetList.Add(new Street { Id = 180, Name = "Via Cavour" });
            paths.StreetList.Add(new Street { Id = 181, Name = "Via Garibaldi" });
            paths.StreetList.Add(new Street { Id = 182, Name = "Via Pradazzo" });
            paths.StreetList.Add(new Street { Id = 183, Name = "RotondaPradazzo" });
            paths.StreetList.Add(new Street { Id = 184, Name = "Via Del Cerchio" });
            paths.StreetList.Add(new Street { Id = 185, Name = "Via due Scale" });
            paths.StreetList.Add(new Street { Id = 186, Name = "Rotonda Bonazzi" });
            paths.StreetList.Add(new Street { Id = 187, Name = "Via San Vitalino" });
            paths.StreetList.Add(new Street { Id = 188, Name = "Via Masetti" });
            paths.StreetList.Add(new Street { Id = 189, Name = "Via Aldina" });
            paths.StreetList.Add(new Street { Id = 190, Name = "Rotonda Dello Storione" });
            paths.StreetList.Add(new Street { Id = 191, Name = "Via Crocetta" });
            paths.StreetList.Add(new Street { Id = 192, Name = "Via Due Giugno" });
            paths.StreetList.Add(new Street { Id = 193, Name = "Via Crocetta" });
            paths.StreetList.Add(new Street { Id = 194, Name = "Via Castaldini (parcheggio)" });
            paths.StreetList.Add(new Street { Id = 195, Name = "Via Surrogazione" });
            paths.StreetList.Add(new Street { Id = 196, Name = "Via Giovanni XXIII" });
            paths.StreetList.Add(new Street { Id = 197, Name = "Via Bassi" });
            paths.StreetList.Add(new Street { Id = 198, Name = "Via Giovanni XXIII" });
            paths.StreetList.Add(new Street { Id = 199, Name = "Via Castaldini (scuola e parco)" });
            paths.StreetList.Add(new Street { Id = 200, Name = "Via Don Minzoni" });
            paths.StreetList.Add(new Street { Id = 201, Name = "Via Aldina" });
            paths.StreetList.Add(new Street { Id = 202, Name = "Via Ungheri" });
            paths.StreetList.Add(new Street { Id = 203, Name = "Rotonda Bugli" });
            paths.StreetList.Add(new Street { Id = 204, Name = "Via San Vitalino" });
            paths.StreetList.Add(new Street { Id = 205, Name = "Via Serra" });
            paths.StreetList.Add(new Street { Id = 206, Name = "Via del Maccabreccia" });
            paths.StreetList.Add(new Street { Id = 207, Name = "Via della Corte" });
            paths.StreetList.Add(new Street { Id = 208, Name = "Via Serra" });
            paths.StreetList.Add(new Street { Id = 209, Name = "Via San Vitalino" });
            paths.StreetList.Add(new Street { Id = 210, Name = "Via Rosselli" });
            paths.StreetList.Add(new Street { Id = 211, Name = "Via San Vitalino" });
            paths.StreetList.Add(new Street { Id = 212, Name = "Via Candini" });
            paths.StreetList.Add(new Street { Id = 213, Name = "Via San Vitalino" });
            paths.StreetList.Add(new Street { Id = 214, Name = "Rotonda Bugli" });
            paths.StreetList.Add(new Street { Id = 215, Name = "Via Ungheri" });
            paths.StreetList.Add(new Street { Id = 216, Name = "Via Aldina" });
            paths.StreetList.Add(new Street { Id = 217, Name = "Via Barca" });
            paths.StreetList.Add(new Street { Id = 218, Name = "Via Aldina" });
            paths.StreetList.Add(new Street { Id = 219, Name = "Via San Vitalino" });
            paths.StreetList.Add(new Street { Id = 220, Name = "Via Stelloni Levante" });
            paths.StreetList.Add(new Street { Id = 221, Name = "Via Pertini" });
            paths.StreetList.Add(new Street { Id = 222, Name = "Via Armaroli" });
            paths.StreetList.Add(new Street { Id = 223, Name = "Via Bassi" });
        }

        // Process the valid form
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILogger<Counter> Logger { get; set; }
    }
}
#pragma warning restore 1591