using UnityEngine;

namespace Input
{
    public interface IInput
    {
        Vector2 GetDirectionAxis();
        bool GetRunningButton();
        bool GetPrimaryActionButtonDown();
        bool GetSecondaryActionButtonDown();
    }
}
