#pragma checksum "C:\Users\k.salahshoor\Desktop\BaniHesab\BaniHesab\Pages\Identity\Categories.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c1d718c0f2917090002d9c4b724fce4a94dc825e"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BaniHesab.Pages.Identity
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\k.salahshoor\Desktop\BaniHesab\BaniHesab\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\k.salahshoor\Desktop\BaniHesab\BaniHesab\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\k.salahshoor\Desktop\BaniHesab\BaniHesab\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\k.salahshoor\Desktop\BaniHesab\BaniHesab\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\k.salahshoor\Desktop\BaniHesab\BaniHesab\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\k.salahshoor\Desktop\BaniHesab\BaniHesab\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\k.salahshoor\Desktop\BaniHesab\BaniHesab\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\k.salahshoor\Desktop\BaniHesab\BaniHesab\_Imports.razor"
using BaniHesab;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\k.salahshoor\Desktop\BaniHesab\BaniHesab\_Imports.razor"
using BaniHesab.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/categories")]
    public partial class Categories : OwningComponentBase<ApplicationDbContext>
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 98 "C:\Users\k.salahshoor\Desktop\BaniHesab\BaniHesab\Pages\Identity\Categories.razor"
       
    private ApplicationDbContext _db => Service;
    [Inject] private IJSRuntime _js { get; set; }
    List<Category> _items;
    Category _model;
    private bool _show;

    protected override async Task OnInitializedAsync()
    {
        //seed
        if (!await _db.Categories.AnyAsync())
        {
            for (int i = 1; i <= 10; i++)
            {
                _db.Categories.Add(new Category { Name = "Category " + i });
            }
            await _db.SaveChangesAsync();
        }

        _items = await _db.Categories.ToListAsync();
    }

    private async Task validsubmit()
    {
        _show = false;

        if (_model.Id == 0)
        {
            await _db.Categories.AddAsync(_model);
        }
        else
        {
            _db.Categories.Update(_model);
        }

        var result = await _db.SaveChangesAsync();
        if (result == 0)
        {
            //error
            await _js.InvokeVoidAsync("alert", "Error saving data");
        }
        else
        {
            //saved
            await _js.InvokeVoidAsync("alert", "Data saved");

            _items = await _db.Categories.ToListAsync();
        }
    }

    private void add()
    {
        _model = new Category();
        _show = true;
    }

    private void edit(Category model)
    {
        _model = model;
        _show = true;
    }

    private async Task delete(Category model)
    {
        if (await _js.InvokeAsync<bool>("confirm", "Are absolutely you sure you want to delete this item?"))
        {
            _db.Categories.Remove(model);
            var result = await _db.SaveChangesAsync();
            if (result == 0)
            {
                //error
                await _js.InvokeVoidAsync("alert", "Error deleting data");
            }
            else
            {
                //saved
                await _js.InvokeVoidAsync("alert", "Data saved");

                _items = await _db.Categories.ToListAsync();
            }
        }

    }

    private void close()
    {
        _show = false;
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
