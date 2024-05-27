using System;
using UnityEngine;

namespace _Scripts
{
    public class Detail: MonoBehaviour
    {
        private Animator _animator;


        public void Initialize()
        {
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
    }
}