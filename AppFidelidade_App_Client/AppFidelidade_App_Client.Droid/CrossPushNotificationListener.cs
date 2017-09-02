using System;
using Newtonsoft.Json.Linq;
using PushNotification.Plugin;
using PushNotification.Plugin.Abstractions;

namespace AppFidelidade_App_Client.Droid
{
    public class CrossPushNotificationListener : IPushNotificationListener
    {
        public void OnError(string message, DeviceType deviceType)
        {
            
        }

        public void OnMessage(JObject values, DeviceType deviceType)
        {
            
        }

        public void OnRegistered(string token, DeviceType deviceType)
        {
            App.SalvarTokenPush(token);
        }

        public void OnUnregistered(DeviceType deviceType)
        {
            
        }

        public bool ShouldShowNotification()
        {
            return true;
        }
    }
}