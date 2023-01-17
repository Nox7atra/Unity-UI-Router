using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Nox7atra.UIRouter.Samples
{
    public class MyAwesomeStorage : MonoBehaviour
    {
        [SerializeField] private List<MyAwesomeData> _data;

        public MyAwesomeData GetDataById(string id)
        {
            return _data.FirstOrDefault(x => x.ID == id);
        }

        public List<MyAwesomeData> GetData()
        {
            return _data;
        }
    }

    [Serializable]
    public class MyAwesomeData
    {
        public string ID;
        public string AwesomeTitle;
        public string AwesomeText;
    }
}