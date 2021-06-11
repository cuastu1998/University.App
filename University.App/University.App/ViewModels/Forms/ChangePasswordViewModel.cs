using System;
using University.BL.DTOs;
using University.BL.Services.Implements;
using University.App.Helpers;
using Xamarin.Forms;

namespace University.App.ViewModels.Forms
{
    public class ChangePasswordViewModel : BaseViewModel
    {
        #region Attributes
        private string _email;
        private string _old_Password;
        private string _new_Password;
        private string _Confirm_Newpassword;
        private bool _isEmailValid;
        private bool _isEnabled;
        private bool _isRunning;
        private ApiService _apiService;
        #endregion

        #region Propesties 
        public string Email
        {
            get { return this._email; }
            set { this.SetValue(ref this._email, value); }
        }

        public string Old_Password
        {
            get { return this._old_Password; }
            set { this.SetValue(ref this._old_Password, value); }
        }

        public string New_Password
        {
            get { return this._new_Password; }
            set { this.SetValue(ref this._new_Password, value); }
        }

        public string Confirm_Newpassword
        {
            get { return this._Confirm_Newpassword; }
            set { this.SetValue(ref this._Confirm_Newpassword, value); }
        }

        public bool IsEmailValid
        {
            get { return this._isEmailValid; }
            set { this.SetValue(ref this._isEmailValid, value); }
        }

        public bool IsEnabled
        {
            get { return this._isEnabled; }
            set { this.SetValue(ref this._isEnabled, value); }
        }

        public bool IsRunning
        {
            get { return this._isRunning; }
            set { this.SetValue(ref this._isRunning, value); }
        }
        #endregion

        #region Commands
        public Command ChangePasswordCommand { get; set; }
        #endregion

        #region Constructor
        public ChangePasswordViewModel()
        {
         this._apiService = new ApiService();
         this.IsEmailValid = this.IsEnabled = true;
         this.IsRunning = false;
         this.ChangePasswordCommand = new Command(ChangePassword);
        }
        #endregion

        #region Methods0
        async void ChangePassword()
        {
            try
            {
                this.IsRunning = true;
                this.IsEnabled = false;

                if (!await _apiService.CheckConnection())
                {
                    this.IsRunning = false;
                    this.IsEnabled = true;
                    await Application.Current.MainPage.DisplayAlert(Languages.Notification, Languages.NoInternetConnection, Languages.Accept);
                    return;
                }
                if (string.IsNullOrEmpty(this.Email) || string.IsNullOrEmpty(this.Old_Password) || string.IsNullOrEmpty(this.New_Password) || string.IsNullOrEmpty(this.Confirm_Newpassword))
                {
                    this.IsRunning = false;
                    this.IsEnabled = true;
                    await Application.Current.MainPage.DisplayAlert(Languages.Notification, Languages.FieldsRequired, Languages.Accept);
                    return;
                }

                if (string.IsNullOrEmpty(New_Password) || New_Password?.Length < 6)
                {
                    await App.Current.MainPage.DisplayAlert(Languages.Notification, Languages.Error1, Languages.Accept);
                    return;
                }

                if (string.IsNullOrEmpty(Confirm_Newpassword))
                {
                    await App.Current.MainPage.DisplayAlert(Languages.Notification, Languages.Error2, Languages.Accept);
                    return;
                }

                if (New_Password != Confirm_Newpassword)
                {
                    await App.Current.MainPage.DisplayAlert(Languages.Notification, Languages.Error3, Languages.Accept);
                    return;
                }

                var manageDTO = new ChangePasswordDTO
                {
                    UserId = Helpers.Settings.UserID,
                    OldPassword = this.Old_Password,
                    NewPassword = this.New_Password,
                    ConfirmPassword = this.Confirm_Newpassword
                };

                var responseDTO = await _apiService.RequestAPI<ChangePasswordDTO>(Helpers.Endpoints.URL_BASE_UNIVERSITY_AUTH,
                    Helpers.Endpoints.Change_Password,
                    manageDTO,
                    ApiService.Method.Post,
                    true);

                if (responseDTO.Code == 200)
                {
                    await Application.Current.MainPage.DisplayAlert(Languages.Notification, Languages.TheProcessSuccessful, Languages.Accept);
                }
                else
                    await Application.Current.MainPage.DisplayAlert(Languages.Notification, responseDTO.Message, Languages.Accept);
                this.IsRunning = false;
                this.IsEnabled = true;
            }
            catch (Exception ex)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(Languages.Notification, ex.Message, Languages.Accept);
            }
        #endregion
        }
    }
}