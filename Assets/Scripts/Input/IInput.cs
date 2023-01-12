using UnityEngine;

namespace Santos
{
    public interface IInput
    {
        Vector2 GetDirectionAxis();
        bool GetRunningButton();
        bool GetPrimaryActionButtonDown();
        bool GetSecondaryActionButtonDown();
    }
}
