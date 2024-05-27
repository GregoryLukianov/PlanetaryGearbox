using System;
using UnityEngine;

namespace _Scripts
{
    public class Presenter: MonoBehaviour
    {
        [SerializeField] Menu menu;
        [SerializeField] Model model;

        
        private void Start()
        {
            menu.OnButtonClicked += Open;
        }

        private void Open()
        {
            model.ChangeModel();
        }
        
    }
}