namespace AppFidelidade_App_Client
{
    public static class Data
    {
        private static string QrCode { get; set; }
        public static void SalvarQrCode()
        {
            QrCode = "wJxT8UXe/kiuJ7S7yHRO5g==";
        }

        public static string ObterQrCode()
        {
            return QrCode;
        }
    }
}
