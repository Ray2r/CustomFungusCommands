using UnityEngine;

namespace Fungus
{
    /// <summary>
    /// Convert Int to Float
    /// </summary>
    [CommandInfo("Math",
                 "ToFloat",
                 "Convert Int to Float")]
    [AddComponentMenu("")]
    public class ToFloat : Command
    {
        [Tooltip("Value to be passed in to the function.")]
        [SerializeField] protected IntegerVariable intVar;

        [Tooltip("Where the result of the function is stored.")]
        [SerializeField] protected FloatVariable storedResult;

        public override void OnEnter()
        {
            storedResult.Value = intVar.Value;

            Continue();
        }

        public override string GetSummary()
        {
            if (intVar == null)
            {
                return "Error: Input Variable not selected";
            }

            if (storedResult == null)
            {
                return "Error: Output Variable not set";
            }
            return "In Var: " + intVar.Key + " = " + intVar.Value + "; Out Var: " + storedResult.Key;
        }

        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }
    }
}