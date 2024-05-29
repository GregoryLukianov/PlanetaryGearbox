using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _Scripts
{
    public class ButtonsController: MonoBehaviour
    {
        [FormerlySerializedAs("buttonDecisionComponents")] public ButtonComponent[] buttonComponents;
        public bool IsListOpened { get; private set; }
        
        
        public void Start()
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
            var button = Array.Find(buttonComponents, x => x.detailType == detailType);
            
            if(button.IsSelected)
                DeSelectButton(detailType);
            else 
                SelectButton(detailType);
        }
        
        public void SelectButton(DetailType detailType)
        {
            foreach (var button in buttonComponents)
            {
                if (button.detailType == detailType)
                {
                    button.Select();
                    continue;
                }
                
                button.MakeNonInteractive();
            }
        }

        public void DeSelectButton(DetailType detailType)
        {
            foreach (var button in buttonComponents)
            {
                if (button.detailType == detailType)
                {
                    button.DeSelect();
                    continue;
                }
                
                button.MakeInteractive();
            }
        }
    }
}