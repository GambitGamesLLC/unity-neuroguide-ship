using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Nestre.Errors
{
    public class ErrorSystem : MonoBehaviour
    {
        private static ErrorSystem _instance;

        public static ErrorSystem Instance
        {
            get
            {
                if (_instance != null && !_instance.gameObject.activeInHierarchy) return null;

                if (_instance == null)
                    _instance = FindObjectOfType<ErrorSystem>();

                return _instance;
            }
        }

        [SerializeField] TMP_Text errorText;
        [SerializeField] float errorDisplayDuration;

        Coroutine currentErrorRoutine;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        public void ErrorRoutine(string errorString)
        {
            if (currentErrorRoutine != null)
                StopCoroutine(currentErrorRoutine);

            currentErrorRoutine = StartCoroutine(DisplayError(errorString));
        }

        private IEnumerator DisplayError(string error)
        {
            if (!errorText.text.Contains(error))
                errorText.text += error + "\n";

            yield return new WaitForSeconds(errorDisplayDuration);
            errorText.SetText("");
            currentErrorRoutine = null;
        }
    }
}
