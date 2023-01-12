using UnityEngine;

namespace Santos
{
    public class Player : Actor
    {
        private IInput m_Input;
        
        public void Configure(IInput input)
        {
            m_Input = input;
        }
        protected override Vector2 GetDirection()
        {
            return m_Input.GetDirectionAxis();
        }
        protected override bool GetRunning()
        {
            return m_Input.GetRunningButton();
        }
        protected override bool GetPrimaryAction()
        {
            return m_Input.GetPrimaryActionButtonDown();
        }
        protected override bool GetSecondaryAction()
        {
            return m_Input.GetSecondaryActionButtonDown();
        }
    }
}
