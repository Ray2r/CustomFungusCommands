using UnityEngine;

namespace Fungus
{
    /// <summary>
    /// Get string from right side
    /// </summary>
    [CommandInfo("Variable",
                 "GetStringRight",
                     "Get characters from right side of string")]
    [AddComponentMenu("")]
    public class GetStringRight : Command
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
            var stringtext = stringVar.Value;
            var count = Mathf.Clamp(intCount.Value, 0, stringtext.Length);
            storeResult.Value = stringtext.Substring(stringtext.Length - count, count);

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