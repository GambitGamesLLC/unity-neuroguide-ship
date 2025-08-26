using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nestre.Core
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Game Data")]
    public class GameData : ScriptableObject
    {
        [SerializeField] string app_identifier;

        //these fields will be passed in from the app
        [SerializeField] string userID;
        [SerializeField] string context;
        [SerializeField] string version;
        [SerializeField] string subscriptionLevel;
        [SerializeField] string id_token, access_token, refresh_token;
        [SerializeField] string appservices_url, db_url;
    [SerializeField] string cms_host, cms_space, cms_environment, cms_accessToken;

        [SerializeField] bool isTestMode = false;

        public void SetUserID(string id)
        {
            userID = id;
        }

        public void SetContext(string cxt)
        {
            context = cxt;
        }

        public void SetVersion(string version)
        {
            this.version = version;
        }

        public void SetSubscriptionLevel(string subscriptionLevel)
        {
            this.subscriptionLevel = subscriptionLevel;
        }

        public void SetIDToken(string id_token)
        {
            this.id_token = id_token;
        }

        public void SetAccessToken(string access_token)
        {
            this.access_token = access_token;
        }

        public void SetRefreshToken(string refresh_token)
        {
            this.refresh_token = refresh_token;
        }

        public void SetAppServicesURL(string appservices_url)
        {
            this.appservices_url = appservices_url;
        }

        public void SetDBURL(string db_url)
        {
            this.db_url = db_url;
        }

    public void SetCMSHost(string cms_host)
    {
      this.cms_host = cms_host;
    }

    public void SetCMSSpace(string cms_space)
    {
      this.cms_space = cms_space;
    }

    public void SetCMSEnvironment(string cms_environment)
    {
      this.cms_environment = cms_environment;
    }

    public void SetCMSAccessToken(string cms_accessToken)
    {
      this.cms_accessToken = cms_accessToken;
    }

    public void SetTestMode(bool testModeState)
        {
            isTestMode = testModeState;
        }

        public string GetUserID()
        {
            return userID;
        }

        public string GetAppIdentifier()
        {
            return app_identifier;
        }

        public string GetContext()
        {
            return context;
        }

        public string GetVersion()
        {
            return version;
        }

        public string GetSubscriptionLevel()
        {
            return subscriptionLevel;
        }

        public string GetIDToken()
        {
            return id_token;
        }

        public string GetAccessToken()
        {
            return access_token;
        }

        public string GetRefreshToken()
        {
            return refresh_token;
        }

        public string GetAppServicesURL()
        {
            return appservices_url;
        }

        public string GetDBURL()
        {
            return db_url;
        }

    public string GetCMSHost()
    {
      return cms_host;
    }

    public string GetCMSSpace()
    {
      return cms_space;
    }

    public string GetCMSEnvironment()
    {
      return cms_environment;
    }

    public string GetCMSAccessToken()
    {
      return cms_accessToken;
    }

    public bool IsTestMode()
        {
            return isTestMode;
        }
    }
}
