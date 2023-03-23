using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Eshikivo.Demo
{
    public class DemoPopupMessageItem: MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Text messageText;

        private DemoPopupMessage m_instance;

        public void Initialize(DemoPopupMessage instance, string message)
        {
            messageText.text = message;
            m_instance = instance;
        }
        
        public string GetMessage()
        {
            return messageText.text;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            m_instance.TCS.TrySetResult(this);
            m_instance.Close();
        }
    }
}