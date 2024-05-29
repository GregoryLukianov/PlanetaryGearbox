using System;
using UnityEngine;

namespace _Scripts
{
    public class ButtonsController: MonoBehaviour
    {
        [SerializeField] private ButtonComponent[] buttonComponents;
        
        public bool IsListOpened { get; private set; }
        public ButtonComponent[] ButtonComponents => buttonComponents;
        
        
        public void Initialize()
        {
            IsListOpened = false;
            foreach (var button in buttonComponents)
            {
                button.Initialize();
            }
        }

        public void OpenButtonsList()
        {
            foreach (var button in buttonComponents)
                button.Open();

            IsListOpened = true;
        }
        
        public void CloseButtonsList()
        {
            foreach (var button in buttonComponents)
                button.Close();
            
            IsListOpened = false;
        }

        public void ChooseButton(DetailType detailType)
        {
            var button = Array.Find(buttonComponents, x => x.DetailType == detailType);
            
            if(button.IsSelected)
                DeSelectButton(detailType);
            else 
                SelectButton(detailType);
        }
        
        private void SelectButton(DetailType detailType)
        {
            foreach (var button in buttonComponents)
            {
                if (button.DetailType == detailType)
                {
                    button.Select();
                    continue;
                }
                
                button.MakeNonInteractive();
            }
        }

        private void DeSelectButton(DetailType detailType)
        {
            foreach (var button in buttonComponents)
            {
                if (button.DetailType == detailType)
                {
                    button.DeSelect();
                    continue;
                }
                
                button.MakeInteractive();
            }
        }
    }
}