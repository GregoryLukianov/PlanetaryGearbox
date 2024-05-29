using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Scripts
{
    public class ButtonComponent: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public DetailType detailType;
        public Button button;

        public event Action<DetailType> OnPointerEnterButton;
        public event Action<DetailType> OnPointerExitButton;
        
        public bool IsSelected { get; private set; }
        
        private Animator _animator;
        
        public void Initialize()
        {
            button = GetComponent<Button>();
            _animator = GetComponent<Animator>();
        }
        
        public void Open()
        {
            _animator.SetFloat("Speed", 1f);
            _animator.Play("Open",0,0);
        }

        public void Close()
        {
            _animator.SetFloat("Speed", -1f);
            _animator.Play("Open",0,1);
        }

        public void Select()
        {
            // _animator.SetFloat("Speed", 1f);
            // _animator.Play("PressButton",0,0);
            IsSelected = true;
        }

        public void DeSelect()
        {
            // _animator.SetFloat("Speed", -1f);
            // _animator.Play("PressButton",0,1);
            IsSelected = false;
        }

        public void MakeInteractive()
        {
            button.interactable = true;
        }
        
        public void MakeNonInteractive()
        {
            button.interactable = false;
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            OnPointerEnterButton?.Invoke(detailType);
        }

        
        public void OnPointerExit(PointerEventData eventData)
        {
            OnPointerExitButton?.Invoke(detailType);
        }
    }
}