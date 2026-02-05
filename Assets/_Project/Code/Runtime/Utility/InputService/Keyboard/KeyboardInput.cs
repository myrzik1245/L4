using UnityEngine;

namespace Assets._Project.Code.Utility.InputService.Keyboard
{
    public class KeyboardInput : IInputService
    {
        public Vector2 Movement => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    }
}
