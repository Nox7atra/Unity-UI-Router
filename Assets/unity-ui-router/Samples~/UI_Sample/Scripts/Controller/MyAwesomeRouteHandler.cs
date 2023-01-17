using UnityEngine;

namespace Nox7atra.UIRouter.Samples
{
    public class MyAwesomeRouteHandler : MonoBehaviour
    {
        [SerializeField] private string _uiUrl;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                UIRouteManager.OpenUrl(_uiUrl);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UIRouteManager.ProceedBack();
            }
        }
    }
}