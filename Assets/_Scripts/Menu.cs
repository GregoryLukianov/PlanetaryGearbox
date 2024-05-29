using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Scripts
{
    public class Menu: MonoBehaviour
    {
        [SerializeField] private Button planetaryGearboxButton;
        [SerializeField] private ButtonsController buttons;
        
        public event Action OnPlanetaryGearboxOpenButtonPressed;
        public event Action<DetailType> OnDetailChosen;
        public event Action<DetailType> OnPointerEnterButton;
        public event Action<DetailType> OnPointerExitButton;
        public event Action<DetailType> OnToggleSwitched;
        public event Action OnLinesStatusChanges;
        
        
        public void Initialize()
        {
            buttons.Initialize();
            foreach (var button in buttons.ButtonComponents)
            {
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
            planetaryGearboxButton.interactable = !planetaryGearboxButton.interactable;
            
            buttons.ChooseButton(buttonComponent.DetailType);
            
            OnDetailChosen?.Invoke(buttonComponent.DetailType);
        }
        
        public void SwitchToggle(ButtonComponent buttonComponent)
        {
            OnToggleSwitched?.Invoke(buttonComponent.DetailType);
        }

        public void ChangeLineStatus()
        {
            OnLinesStatusChanges?.Invoke();
        }

        public void Exit()
        {
            SceneManager.LoadScene(0);
        }
        
        private void EnterPointer(DetailType detailType)
        {
            OnPointerEnterButton?.Invoke(detailType);
        }
        
        private void ExitPointer(DetailType detailType)
        {
            OnPointerExitButton?.Invoke(detailType);
        }
    }
}