using UnityEngine;

namespace Nox7atra.UIRouter.Samples
{
    [UIRoute("main_panel")]
    public class MyAwesomePanel : MonoBehaviour
    {
        [SerializeField] private MyAwesomeStorage _awesomeStorage;
        [SerializeField] private MyAwesomeCard[] _awesomeCards;

        private void Start()
        {
            UIRouteManager.SetMainScreenRoute("main_panel");
            Show();
        }

        public void Show()
        {
            var datas = _awesomeStorage.GetData();
            for (int i = 0; i < datas.Count; i++)
            {
                _awesomeCards[i].SetData(datas[i]);
            }
        }
    }
}