using University.App.Interfaces;
using University.App.Resources;
using Xamarin.Forms;

namespace University.App.Helpers
{
    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Accept { get { return Resource.Accept; } }
        public static string Notification { get { return Resource.Notification; } }
        public static string NoInternetConnection { get { return Resource.NoInternetConnection; } }
        public static string FieldsRequired { get { return Resource.FieldsRequired; } }
        public static string About { get { return Resource.About; } }
        public static string Wherephoto { get { return Resource.Wherephoto; } }
        public static string FromGallery { get { return Resource.FromGallery; } }
        public static string TakeaNewPicture { get { return Resource.TakeNewPicture; } }
        public static string Theprocessiscorrect { get { return Resource.Theprocessiscorrect; } }
        public static string Profile { get { return Resource.Profile; } }
        public static string Courses { get { return Resource.Courses; } }
        public static string ChangePassword { get { return Resource.ChangePassword; } }
        public static string Logout { get { return Resource.LogOut; } }
        public static string Cancel { get { return Resource.Cancel; } }
        public static string Bad { get { return Resource.Bad; } }
        public static string Well { get { return Resource.Well; } }
        public static string Excellent { get { return Resource.Excellent; } }
        public static string Acceptable { get { return Resource.Acceptable; } }
        public static string Regular { get { return Resource.Regular; } }
        public static string Petition { get { return Resource.Petition; } }
        public static string Complain { get { return Resource.Complain; } }
        public static string Claim { get { return Resource.Claim; } }
        public static string Suggestion { get { return Resource.Suggestion; } }
        public static string TheProcessSuccessful { get { return Resource.TheProcessSuccessful; } }
        public static string Error1 { get { return Resource.Error1; } }
        public static string Error2 { get { return Resource.Error2; } }
        public static string Error3 { get { return Resource.Error3; } }

    }
}
