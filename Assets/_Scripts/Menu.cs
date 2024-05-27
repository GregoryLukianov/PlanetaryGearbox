using System;
using UnityEngine;

namespace _Scripts
{
    public class Menu: MonoBehaviour
    {
        public event Action OnButtonClicked;

        
        public void OpenButtonClicked()
        {
            OnButtonClicked?.Invoke();
        }
    }
}