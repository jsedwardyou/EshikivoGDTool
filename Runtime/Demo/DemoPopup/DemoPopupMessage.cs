using System.Threading.Tasks;
using Eshikivo.UI;
using UnityEngine;

namespace Eshikivo.Demo
{
    public class DemoPopupMessage : Popup<DemoPopupMessage, DemoPopupMessageParam, DemoPopupMessageItem>
    {
        [SerializeField] private DemoPopupMessageItem prefab;
        [SerializeField] private Transform container;
        
        public override Task<DemoPopupMessageItem> Open(DemoPopupMessageParam param)
        {
            Debug.Log("Open popup!");
            base.Open(param);
            
            // init params to items
            foreach (var message in param.Messages)
            {
                var item = Instantiate(prefab, container);
                item.Initialize(this, message);
                
                item.gameObject.SetActive(true);
            }

            return m_tcs.Task;
        }

        public override Task Close()
        {
            Debug.Log("Let's close this popup");
            var task = base.Close();
            Destroy(this.gameObject);
            return task;
        }
    }
}