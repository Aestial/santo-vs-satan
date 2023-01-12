using UnityEngine;

namespace Santos
{
    public class UnityInputManagerAdapter : IInput
    {
        public Vector2 GetDirectionAxis()
        {
            var horizontal = UnityEngine.Input.GetAxis("Horizontal");
            var vertical = UnityEngine.Input.GetAxis("Vertical");
            return new Vector2(horizontal, vertical);
        }
        public bool GetRunningButton()
        {
            return UnityEngine.Input.GetButton("Fire3");
        }

        public bool GetPrimaryActionButtonDown()
        {
            return UnityEngine.Input.GetButtonDown("Fire1");
        }

        public bool GetSecondaryActionButtonDown()
        {
            return UnityEngine.Input.GetButtonDown("Fire2");
        }
    }
}