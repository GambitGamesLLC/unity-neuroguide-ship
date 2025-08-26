using Nestre.CMS;
using System;
using TMPro;
using UnityEngine;

namespace Nestre.UI.CMS
{
  public class ContentPresenter: MonoBehaviour
  {
    [SerializeField] string id;

    TMP_Text text;
    ContentStore contentStore;

    public event Action onTextUpdated;

    private void Awake()
    {
      text = GetComponent<TMP_Text>();
      contentStore = Resources.Load<ContentStore>("Content Store");
    }

    private void Start()
    {
      UpdateFromContentStore();
    }

    public void UpdateFromContentStore()
    {
      if (string.IsNullOrEmpty(id)) return;

      if (contentStore.HasContent())
      {
        UpdateText();
      }
      else
      {
        contentStore.onContentDictComplete += UpdateText;
      }
    }

    void UpdateText()
    {
      text.SetText(contentStore.GetContent(id));
      onTextUpdated?.Invoke();
    }

    private void OnDisable()
    {
      contentStore.onContentDictComplete -= UpdateText;
    }

    public void SetID(string id)
    {
      this.id = id;
    }
  }
}
