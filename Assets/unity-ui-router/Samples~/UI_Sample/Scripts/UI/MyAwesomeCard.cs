using TMPro;
using UnityEngine;

namespace Nox7atra.UIRouter.Samples
{
    public class MyAwesomeCard : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _text;
        private string _Id;

        public void SetData(MyAwesomeData data)
        {
            _Id = data.ID;
            _title.text = data.AwesomeTitle;
            _text.text = data.AwesomeText;
        }

        public void OnOpen()
        {
            UIRouteManager.OpenUrl($"main_panel/card_popup?id={_Id}");
        }
    }
}