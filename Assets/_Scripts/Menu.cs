using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts
{
    public class Menu: MonoBehaviour
    {
        [SerializeField] private Button PlanetaryGearboxButton;
        [SerializeField] ButtonsController buttons;
        public event Action OnPlanetaryGearboxOpenButtonPressed;
        public event Action<DetailType> OnDetailChosen;
        public event Action<DetailType> OnPointerEnterButton;
        public event Action<DetailType> OnPointerExitButton;

        public event Action<DetailType> OnToggleSwitched;

        public event Action OnLinesStatusChanges;

        private void Start()
        {
            foreach (var button in buttons.buttonComponents)
            {
                button.Initialize();
                button.OnPointerEnterButton += EnterPointer;
                button.OnPointerExitButton += ExitPointer;
            }
        }

        public void OpenPlanetaryGearbox()
        {
            if(buttons.IsListOpened)
                buttons.CloseButtonsList();
            else
                buttons.OpenButtonsList();
            
            OnPlanetaryGearboxOpenButtonPressed?.Invoke();
        }

        public void ChooseDetail(ButtonComponent buttonComponent)
        {
            PlanetaryGearboxButton.interactable = !PlanetaryGearboxButton.interactable;
            buttons.ChooseButton(buttonComponent.detailType);
            OnDetailChosen?.Invoke(buttonComponent.detailType);
        }
        
        public void SwitchToggle(ButtonComponent buttonComponent)
        {
            
            OnToggleSwitched?.Invoke(buttonComponent.detailType);
        }
        
        public void EnterPointer(DetailType detailType)
        {
            OnPointerEnterButton?.Invoke(detailType);
        }
        
        public void ExitPointer(DetailType detailType)
        {
            OnPointerExitButton?.Invoke(detailType);
        }

        public void ChangeLineStatus()
        {
            OnLinesStatusChanges?.Invoke();
        }
    }
}