using Input;
using UnityEngine;

namespace Player
{
    public class Player : Actor.Actor
    {
        private IInput _input;
        
        public void Configure(IInput input)
        {
            _input = input;
        }
        protected override Vector2 GetDirection()
        {
            return _input.GetDirectionAxis();
        }
        protected override bool GetRunning()
        {
            return _input.GetRunningButton();
        }
        protected override bool GetPrimaryAction()
        {
            return _input.GetPrimaryActionButtonDown();
        }
        protected override bool GetSecondaryAction()
        {
            return _input.GetSecondaryActionButtonDown();
        }
    }
}