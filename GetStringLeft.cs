using UnityEngine;

namespace Fungus
{
    /// <summary>
    /// Get string from left side
    /// </summary>
    [CommandInfo("Variable",
                 "GetStringLeft",
                     "Get characters from left side of string")]
    [AddComponentMenu("")]
    public class GetStringLeft : Command
    {
        [Tooltip("Input: String")]
        [VariableProperty(typeof(StringVariable))]
        [SerializeField] protected StringVariable stringVar;

        [Tooltip("Number of characters to get")]
        [SerializeField] protected IntegerData intCount;

        [Tooltip("Output: String")]
        [VariableProperty(typeof(StringVariable))]
        [SerializeField] protected StringVariable storeResult;

        public override void OnEnter()
        {
            storeResult.Value = stringVar.Value.Substring(0, Mathf.Clamp(intCount.Value, 0, stringVar.Value.Length));

            Continue();
        }

        public override string GetSummary()
        {
            if (stringVar == null)
            {
                return "Error: String not selected";
            }

            if (intCount == null)
            {
                return "Error: Integer not selected";
            }

            if (storeResult == null)
            {
                return "Error: storeResult not set";
            }

            return "Get: " + intCount.Value + "; In Var: " + stringVar.Key + " = " + stringVar.Value + "; Out Var: " + storeResult.Key + " = " + storeResult.Value;
        }

        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }
    }
}