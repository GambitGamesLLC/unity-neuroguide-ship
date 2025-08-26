using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nestre.Core
{
    public class GameDataWrapper : MonoBehaviour
    {
        private static GameDataWrapper instance;

        [SerializeField] GameData gameData;

        private void Awake()
        {
            if(instance != null && instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

    IEnumerator Start()
    {
      yield return new WaitForSeconds(1f);

      if (gameData.IsTestMode())
      {
        Debug.Log("User ID: " + gameData.GetUserID());
        Debug.Log("ID Token: " + gameData.GetIDToken());
        Debug.Log("Refresh Token: " + gameData.GetRefreshToken());
        Debug.Log("Access Token:" + gameData.GetAccessToken());
        Debug.Log("AppServices URL: " + gameData.GetAppServicesURL());
        Debug.Log("DB URL: " + gameData.GetDBURL());
        Debug.Log("CMS Host: " + gameData.GetCMSHost());
        Debug.Log("CMS Space: " + gameData.GetCMSSpace());
        Debug.Log("CMS Env: " + gameData.GetCMSEnvironment());
        Debug.Log("CMS Access Token: " + gameData.GetCMSAccessToken());
      }
    }

        public void SetUserID(string id)
        {
            gameData.SetUserID(id);
        }

        public void SetContext(string cxt)
        {
            gameData.SetContext(cxt);
        }

        public void SetVersion(string version)
        {
            gameData.SetVersion(version);
        }

        public void SetSubscriptionLevel(string subscriptionLevel)
        {
            gameData.SetSubscriptionLevel(subscriptionLevel);
        }

        public void SetIDToken(string id_token)
        {
            gameData.SetIDToken(id_token);
        }

        public void SetRefreshToken(string refresh_token)
        {
            gameData.SetRefreshToken(refresh_token);
        }

        public void SetAccessToken(string access_token)
        {
            gameData.SetAccessToken(access_token);
        }

        public void SetAppServicesURL(string appservices_url)
        {
            gameData.SetAppServicesURL(appservices_url);
        }

        public void SetDBURL(string db_url)
        {
            gameData.SetDBURL(db_url);
        }

    public void SetContentfulHost(string cms_host)
    {
      gameData.SetCMSHost(cms_host);
    }

    public void SetContentfulSpace(string cms_space)
    {
      gameData.SetCMSSpace(cms_space);
    }

    public void SetContentfulEnv(string cms_environment)
    {
      gameData.SetCMSEnvironment(cms_environment);
    }

    public void SetContentfulAccessToken(string cms_accessToken)
    {
      gameData.SetCMSAccessToken(cms_accessToken);
    }

    public void SetTestMode(string testModeState)
        {
            gameData.SetTestMode(testModeState == "true");
        }
    }
}
