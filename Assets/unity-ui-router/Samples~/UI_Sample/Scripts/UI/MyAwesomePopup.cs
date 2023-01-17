using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Nox7atra.UIRouter.Samples
{
    [UIRoute("main_panel/card_popup")]
    public class MyAwesomePopup : MonoBehaviour
    {
        [SerializeField] private MyAwesomeStorage _awesomeStorage;
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _text;
        
        public void Show(Dictionary<string, string> data)
        {
            gameObject.SetActive(true);
            var myAwesomeData = _awesomeStorage.GetDataById(data["id"]);
            _text.text = myAwesomeData.AwesomeText;
            _title.text = myAwesomeData.AwesomeTitle;
        }

        public void Hide()
        {
            UIRouteManager.ReleaseLastScreen();
            gameObject.SetActive(false);
        }
    }
}