using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Scripts
{
    public class ButtonComponent: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private DetailType detailType;
        [SerializeField] private Button button;

        private Animator _animator;
        
        public bool IsSelected { get; private set; }
        public DetailType DetailType => detailType;
        
        public event Action<DetailType> OnPointerEnterButton;
        public event Action<DetailType> OnPointerExitButton;
        
        
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
            IsSelected = true;
        }

        public void DeSelect()
        {
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