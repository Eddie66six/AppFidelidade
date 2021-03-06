﻿namespace AppFidelidade_App_Client.Models.AzureAuth
{
    public class FacebookProfile
    {
        public Picture picture { get; set; }
        public string id { get; set; }
    }

    public class Picture
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public int height { get; set; }
        public bool is_silhouette { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }

}
