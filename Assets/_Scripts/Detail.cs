using System;
using UnityEngine;

namespace _Scripts
{
    public class Detail: MonoBehaviour
    {
        public DetailType detailType;
        public Transform center;
        public CameraRotation camera;
        public Outline outline;
        public bool isInspectable;
        
        private Animator _animator;
        
        public bool IsInspecting { get; private set; }


        public void Initialize()
        {
            _animator = GetComponent<Animator>();
            
            if(isInspectable)
                CameraOff();
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

        public void StartInspect()
        {
            gameObject.SetActive(true);
            IsInspecting = true;
            CameraOn();
        }
        
        public void StopInspect()
        {
            IsInspecting = false;
            CameraOff();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
        public void CameraOff()
        {
            camera.CameraOff();
        }
        public void CameraOn()
        {
            camera.CameraOn(1);
        }

        public void OutlineOn()
        {
            outline.TurnOnOutline();
        }
        
        public void OutlineOff()
        {
            outline.TurnOffOutline();
        }
    }
}