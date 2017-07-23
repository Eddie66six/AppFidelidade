using AppFidelidade_App_Adm.Interfaces;
using AppFidelidade_App_Adm.Droid.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidMethods))]
namespace AppFidelidade_App_Adm.Droid.Interfaces
{
    public class AndroidMethods : IAndroidMethods
    {
        public void CloseApp()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}