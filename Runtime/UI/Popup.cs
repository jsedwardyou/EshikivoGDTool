using System.Threading.Tasks;
using Eshikivo.Utils.Prefab;
using UnityEngine;

namespace Eshikivo.UI
{
    public abstract class Popup<TPopup, TPopupParam, TResult>: PrefabResource 
        where TPopup : Popup<TPopup, TPopupParam, TResult> 
        where TPopupParam : PopupParam
    {
        protected static Transform s_container = null;
        protected TaskCompletionSource<TResult> m_tcs;

        public TaskCompletionSource<TResult> TCS => m_tcs;

        public virtual Task<TResult> Open(TPopupParam param)
        {
            m_tcs = new TaskCompletionSource<TResult>();

            return m_tcs.Task;
        }

        public virtual Task Close()
        {
            var tcs = new TaskCompletionSource<object>();
            tcs.TrySetResult(null);

            return tcs.Task;
        }

        public static Task<TResult> OpenPopup(TPopupParam param, Transform container=null)
        {
            if (s_container == null)
            {
                s_container = FindObjectOfType<PopupContainer>().transform;
            }

            TPopup popupGO = PrefabLoader.Instance.LoadPrefab<TPopup>(container == null ? s_container : container);

            return popupGO.Open(param);
        }
    }
}