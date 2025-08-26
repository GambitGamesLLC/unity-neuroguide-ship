using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using Nestre.Core;
using Nestre.Errors;

namespace Nestre.APIManagement
{
    [System.Serializable]
    public class RequestCache
    {
        public string url;
        public Action<JSONNode> callback;

        public RequestCache(string url, Action<JSONNode> callback)
        {
            this.url = url;
            this.callback = callback;
        }
    }

    public class APIHandler : MonoBehaviour
    {
        [SerializeField] float retryFrequency;
        [SerializeField] int uploadAttemptLimit;

        List<RequestCache> requestQueue = new List<RequestCache>();
        private float timeSinceTriedQuery;
        int uploadAttempts;
        GameData gameData;

        private void Awake()
        {
            gameData = Resources.Load<GameData>("GameData");
        }

        private void Update()
        {
            if (requestQueue.Count == 0) return;

            timeSinceTriedQuery += Time.deltaTime;

            if (timeSinceTriedQuery >= retryFrequency)
            {
                StartCoroutine(ProcessRequest(requestQueue[0].url, requestQueue[0].callback));
                requestQueue.RemoveAt(0);
                timeSinceTriedQuery = 0;
                uploadAttempts++;

                if (uploadAttempts >= uploadAttemptLimit)
                {
                    GetComponent<ApplicationQuitter>().Quit();
                }
            }
        }

        public IEnumerator ProcessRequest(string url, Action<JSONNode> callback = null, bool useAuthHeader = true)
        {
            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                if (useAuthHeader) request.SetRequestHeader("Authorization", $"Bearer {gameData.GetIDToken()}");

                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    requestQueue.Add(new RequestCache(url, callback));
                    ErrorSystem.Instance.ErrorRoutine(request.error);
                    Debug.Log(request.error);

                    if (request.downloadHandler.text != "")
                        Debug.Log(request.downloadHandler.text);
                }
                else
                {
                    uploadAttempts = 0;
                    JSONNode node = JSON.Parse(request.downloadHandler.text);
                    callback?.Invoke(node);
                }
            }
        }
    }
}