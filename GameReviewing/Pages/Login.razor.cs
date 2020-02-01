using GameReviewing.Models;
using GameReviewing.Services.Interfaces;
using GameReviewing.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewing.Pages
{
    public partial class Login : ComponentBase
    {
        [Inject]
        public IUserService UserService { get; set; }
        [Inject]
        public UserState UserState { get; set; }

        public LoginViewModel User { get; set; } = new LoginViewModel();
        public EditContext EditContext { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            EditContext = new EditContext(User);
        }

        public void OnSubmit()
        {
            bool isValid = EditContext.Validate();

            if(isValid)
            {
                bool loginSuccessful = UserService.Login(User.Username, User.Password);

                if(loginSuccessful)
                {
                    UserState.Username = User.Username;
                }
            }
        }
    }
}
