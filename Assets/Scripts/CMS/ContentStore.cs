using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nestre.CMS
{
  [CreateAssetMenu(fileName = "New Content Store", menuName = "Content Store")]
  public class ContentStore : ScriptableObject
  {
    Dictionary<string, string> contentDict;

    public event Action onContentDictComplete;

    public void BuildContentDict(JSONNode localContent, JSONNode globalContent)
    {
      contentDict = new Dictionary<string, string>();

      foreach(JSONNode node in localContent["items"])
      {
        contentDict[node["sys"]["id"]] = node["fields"]["text"];
      }

      foreach (JSONNode node in globalContent["items"])
      {
        contentDict[node["sys"]["id"]] = node["fields"]["text"];
      }

      onContentDictComplete?.Invoke();
    }

    public string GetContent(string id)
    {
      if (contentDict == null) Debug.LogError("Tried to access content store before it was populated");
      if (contentDict[id] == null) Debug.LogError("No content found with the id " + id);

      return contentDict[id];
    }

    public bool HasContent()
    {
      return contentDict != null;
    }
  }
}
