
using System.Collections.Generic;

namespace GameInput
{
    public static class GameInput
    {
        private static Dictionary<InputType, float> input = new Dictionary<InputType, float>();
        
        public static float Get(InputType type)
        {
            return input.TryGetValue(type, out var value) ? value : 0;
        }

        public static void Set(InputType type, float amount)
        {
            input[type] = amount;
        }
    }

    public enum InputType
    {
        Horizontal,
        Vertical
    }
}