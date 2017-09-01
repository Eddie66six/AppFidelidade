// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;

namespace AppFidelidade_App_Client.Helpers
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
        private static ISettings _appSettings => CrossSettings.Current;
        #region login
        private const string _loginDate = "loginDate";
        private static readonly string _loginDateDefault = string.Empty;

        private const string _TokenId = "tokenId";
        private static readonly string _TokenIdDefault = string.Empty;

        private const string _userIdKey = "userId";
        private static readonly string _userIdDefault = string.Empty;

        private const string _authTokenKey = "authToken";
        private static readonly string _authTokenDefault = string.Empty;

        public static string TokenId
        {
            get { return _appSettings.GetValueOrDefault(_TokenId, _TokenIdDefault); }
            set { _appSettings.AddOrUpdateValue(_TokenId, value); }
        }

        public static string LoginDate
        {
            get { return _appSettings.GetValueOrDefault(_loginDate, _loginDateDefault); }
            set { _appSettings.AddOrUpdateValue(_loginDate, value); }
        }

        public static string AuthToken
        {
            get { return _appSettings.GetValueOrDefault(_authTokenKey, _authTokenDefault); }
            set { _appSettings.AddOrUpdateValue(_authTokenKey, value); }
        }

        public static string UserId
        {
            get { return _appSettings.GetValueOrDefault(_userIdKey, _userIdDefault); }
            set { _appSettings.AddOrUpdateValue(_userIdKey, value); }
        }

        public static bool IsLoggedIn => !string.IsNullOrEmpty(UserId);
        #endregion

        #region facebook
        private const string _id = "id";
        private static readonly string _idDefault = string.Empty;

        private const string _name = "name";
        private static readonly string _nameDefault = string.Empty;

        private const string _photo = "photo";
        private static readonly string _photoDefault = string.Empty;

        public static string Nome
        {
            get { return _appSettings.GetValueOrDefault(_name, _nameDefault); }
            set { _appSettings.AddOrUpdateValue(_name, value); }
        }

        public static string Foto
        {
            get { return _appSettings.GetValueOrDefault(_photo, _photoDefault); }
            set { _appSettings.AddOrUpdateValue(_photo, value); }
        }

        public static string Id
        {
            get { return _appSettings.GetValueOrDefault(_id, _idDefault); }
            set { _appSettings.AddOrUpdateValue(_id, value); }
        }
        #endregion

        #region Usuario
        private const string _idCliente = "idCliente";
        private static readonly string _idClienteDefault = string.Empty;

        public static string IdCliente
        {
            get { return _appSettings.GetValueOrDefault(_idCliente, _idClienteDefault); }
            set { _appSettings.AddOrUpdateValue(_idCliente, value); }
        }

        private const string _usuarioTokenId = "usuarioTokenId";
        private static readonly string _usuarioTokenIdDefault = string.Empty;

        public static string UsuarioTokenId
        {
            get { return _appSettings.GetValueOrDefault(_usuarioTokenId, _usuarioTokenIdDefault); }
            set { _appSettings.AddOrUpdateValue(_usuarioTokenId, value); }
        }
        #endregion
        //geral
        public static void Clear()
        {
            UsuarioTokenId = null;
            IdCliente = null;
            Id = null;
            Foto = null;
            Nome = null;
            UserId = null;
            AuthToken = null;
            LoginDate = null;
            TokenId = null;
        }
    }
}