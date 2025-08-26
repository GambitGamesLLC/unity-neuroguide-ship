using Nestre.APIManagement;
using Nestre.Core;
using SimpleJSON;
using System.Collections;
using UnityEngine;

namespace Nestre.CMS
{
  public class ContentLoader : MonoBehaviour
  {
    ContentStore contentStore;

    GameData gameData;
    APIHandler apiHandler;

    JSONNode localContentCache = new JSONObject();
    JSONNode globalContentCache = new JSONObject();

    private void Awake()
    {
      gameData = Resources.Load<GameData>("GameData");
      apiHandler = GetComponent<APIHandler>();
      contentStore = Resources.Load<ContentStore>("Content Store");
    }

    private void Start()
    {
      StartCoroutine(LoadContent());
    }

    public IEnumerator LoadContent()
    {
      //get local content
      yield return apiHandler.ProcessRequest(BuildURL(gameData.GetAppIdentifier()),
      (JSONNode content) =>
      {
        localContentCache = content;
      }, false);

      //get global content
      yield return apiHandler.ProcessRequest(BuildURL("GLOBAL"),
      (JSONNode content) =>
      {
        globalContentCache = content;
      }, false);

      BuildContentStore();
    }

    string BuildURL(string filter)
    {
      string url = $"https://{gameData.GetCMSHost()}/spaces/{gameData.GetCMSSpace()}/environments/{gameData.GetCMSEnvironment()}/entries?access_token={gameData.GetCMSAccessToken()}&content_type=text&select=sys.id,fields.text&fields.title[match]={filter}";
      return url;
    }

    private void BuildContentStore()
    {
      contentStore.BuildContentDict(localContentCache, globalContentCache);
    }

  }
}
