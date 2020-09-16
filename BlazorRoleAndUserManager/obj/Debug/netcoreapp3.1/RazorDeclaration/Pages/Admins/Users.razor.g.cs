#pragma checksum "C:\Users\k.salahshoor\Desktop\XXX\BlazorRoleAndUserManager\Pages\Admins\Users.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "447d724f79121f5e7eb8e6dd8f3de51d0f03482d"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorRoleAndUserManager.Pages.Admins
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\k.salahshoor\Desktop\XXX\BlazorRoleAndUserManager\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\k.salahshoor\Desktop\XXX\BlazorRoleAndUserManager\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\k.salahshoor\Desktop\XXX\BlazorRoleAndUserManager\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\k.salahshoor\Desktop\XXX\BlazorRoleAndUserManager\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\k.salahshoor\Desktop\XXX\BlazorRoleAndUserManager\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\k.salahshoor\Desktop\XXX\BlazorRoleAndUserManager\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\k.salahshoor\Desktop\XXX\BlazorRoleAndUserManager\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\k.salahshoor\Desktop\XXX\BlazorRoleAndUserManager\_Imports.razor"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\k.salahshoor\Desktop\XXX\BlazorRoleAndUserManager\_Imports.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\k.salahshoor\Desktop\XXX\BlazorRoleAndUserManager\_Imports.razor"
using System.ComponentModel.DataAnnotations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\k.salahshoor\Desktop\XXX\BlazorRoleAndUserManager\_Imports.razor"
using BlazorRoleAndUserManager;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\k.salahshoor\Desktop\XXX\BlazorRoleAndUserManager\_Imports.razor"
using BlazorRoleAndUserManager.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\k.salahshoor\Desktop\XXX\BlazorRoleAndUserManager\_Imports.razor"
using BlazorRoleAndUserManager.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\k.salahshoor\Desktop\XXX\BlazorRoleAndUserManager\_Imports.razor"
using BlazorRoleAndUserManager.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\k.salahshoor\Desktop\XXX\BlazorRoleAndUserManager\_Imports.razor"
using BlazorRoleAndUserManager.Pages.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\k.salahshoor\Desktop\XXX\BlazorRoleAndUserManager\_Imports.razor"
using BlazorRoleAndUserManager.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\k.salahshoor\Desktop\XXX\BlazorRoleAndUserManager\Pages\Admins\Users.razor"
           [Authorize(Roles = "Admins")]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/users")]
    public partial class Users : OwningComponentBase<UserManager<AppUser>>
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 214 "C:\Users\k.salahshoor\Desktop\XXX\BlazorRoleAndUserManager\Pages\Admins\Users.razor"
       
    private UserManager<AppUser> _userManager => Service;

    [Inject] private IJSRuntime _js { get; set; }
    [Inject] private RoleManager<AppRole> _roleManager { get; set; }

    List<PageViewModel> _items;
    PageViewModel _model;
    private bool _show;
    private List<AppRole> _roles;

    private List<string> _serverSideErrors = new List<string>();
    private string _passwordError;

    protected override async Task OnInitializedAsync()
    {
        _roles = await _roleManager.Roles.ToListAsync();

        await setItems();
    }

    private async Task setItems()
    {
        _items = new List<PageViewModel>();

        var users = await _userManager.Users.ToListAsync();
        foreach (var user in users)
        {
            var roleNames = await _userManager.GetRolesAsync(user);
            var roleName = roleNames.FirstOrDefault();
            var role = _roles.SingleOrDefault(x => x.Name == roleName);

            var vm = new PageViewModel();
            vm.Email = user.Email;
            vm.FirstName = user.FirstName;
            vm.Id = user.Id;
            vm.LastName = user.LastName;
            vm.Phone = user.PhoneNumber;
            vm.SelectedRoleName = (role == null ? "ندارد" : role.FaName);
            vm.UserName = user.UserName;

            _items.Add(vm);
        }
    }

    private async Task validsubmit()
    {
        _serverSideErrors.Clear();
        _passwordError = null;

        //validations
        if (string.IsNullOrEmpty(_model.Password))
        {
            _passwordError = "Please enter a password";
        }
        else if (_model.Password.Length < 3)
        {
            _passwordError = "Password must be at least 3 chatacters long";
        }
        else if (_model.Id == null && await _userManager.FindByNameAsync(_model.UserName) != null)
        {
            _serverSideErrors.Add("There is another user with the same username. Please change the username");
        }
        else
        {
            if (_model.Id == null)//add
            {
                //save with pwd
                var appUser = new AppUser(_model.UserName, _model.FirstName, _model.LastName, _model.Email, _model.Phone);
                await _userManager.CreateAsync(appUser, _model.Password);

                //role
                if (!await _userManager.IsInRoleAsync(appUser, _model.SelectedRoleName))
                {
                    await _userManager.AddToRoleAsync(appUser, _model.SelectedRoleName);
                }
            }
            else //edit
            {
                var appUser = await _userManager.FindByIdAsync(_model.Id);
                appUser.Email = _model.Email;
                appUser.FirstName = _model.FirstName;
                appUser.LastName = _model.LastName;
                appUser.PhoneNumber = _model.Phone;
                appUser.UserName = _model.UserName;

                await _userManager.UpdateAsync(appUser);

                //pwd
                if (!string.IsNullOrEmpty(_model.Password))
                {
                    await _userManager.RemovePasswordAsync(appUser);
                    await _userManager.AddPasswordAsync(appUser, _model.Password);
                }

                if (!await _userManager.IsInRoleAsync(appUser, _model.SelectedRoleName))
                {
                    var roles = await _userManager.GetRolesAsync(appUser);
                    foreach (var role in roles)
                    {
                        await _userManager.RemoveFromRoleAsync(appUser, role);
                    }

                    await _userManager.AddToRoleAsync(appUser, _model.SelectedRoleName);
                }
            }

            //saved
            await _js.InvokeVoidAsync("alert", "Data saved");
            _show = false;
            await setItems();
        }
    }

    private void add()
    {
        _serverSideErrors.Clear();
        _passwordError = null;

        _model = new PageViewModel();
        _model.Id = null;

        _show = true;
    }

    private void edit(PageViewModel vm)
    {
        _serverSideErrors.Clear();
        _passwordError = null;

        _model = vm;

        _show = true;
    }

    private async Task delete(PageViewModel vm)
    {
        _serverSideErrors.Clear();
        _passwordError = null;

        if (await _js.InvokeAsync<bool>("confirm", "Are absolutely you sure you want to delete this item?"))
        {
            _model = null;

            var modelToDelete = await _userManager.FindByIdAsync(vm.Id);
            var result = await _userManager.DeleteAsync(modelToDelete);
            if (result.Succeeded)
            {
                //saved
                await _js.InvokeVoidAsync("alert", "Data saved");

                await setItems();
            }
            else
            {
                //foreach (IdentityError err in result.Errors)
                //{
                //    _serverSideErrors.Add(err.Description);
                //}

                //error
                await _js.InvokeVoidAsync("alert", "Error deleting data");
            }
        }

    }

    private void close()
    {
        _show = false;
    }

    private class PageViewModel
    {
        public string Id { get; set; }
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمائید")]
        public string UserName { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمائید")]
        public string FirstName { get; set; }
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمائید")]
        public string LastName { get; set; }
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "لطفا {0} صحیح وارد نمائید")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمائید")]
        public string Email { get; set; }
        [Display(Name = "تلفن")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمائید")]
        public string Phone { get; set; }

        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Display(Name = "نقش")]
        [Required(ErrorMessage = "لطفا {0} را انتخاب نمائید")]
        public string SelectedRoleName { get; set; }
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
