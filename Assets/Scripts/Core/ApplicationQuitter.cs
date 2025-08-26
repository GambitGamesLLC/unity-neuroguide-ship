using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Saving;
using SimpleJSON;
using System;

namespace Nestre.Core
{
    public class ApplicationQuitter : MonoBehaviour
    {
        public void Quit()
        {
            print("quitting");
            Application.Quit();
        }
    }
}
