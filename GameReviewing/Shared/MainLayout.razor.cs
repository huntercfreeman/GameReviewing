using GameReviewing.Models;
using GameReviewing.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewing.Shared
{
    public partial class MainLayout : LayoutComponentBase
    {
        [Inject]
        public UserState UserState { get; set; }
        [Inject]
        public IUserService UserService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            UserState.UserStateChangedEventHandler += UserState_UserStateChangedEventHandler;
        }

        private void UserState_UserStateChangedEventHandler(object sender, EventArgs e)
        {
            StateHasChanged();
        }

        public void NavigateToLogin()
        {
            NavigationManager.NavigateTo("/login");
        }
    }
}
