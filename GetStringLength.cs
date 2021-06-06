using UnityEngine;

namespace Fungus
{
    /// <summary>
    /// Number of characters in the string
    /// </summary>
    [CommandInfo("Variable",
                 "GetStringLength",
                     "Number of characters in the string")]
    [AddComponentMenu("")]
    public class GetStringLength : Command
    {
        [Tooltip("The String to get the Length for")]
        [VariableProperty(typeof(StringVariable))]
        [SerializeField] protected StringVariable stringVar;

        [Tooltip("The output character length")]
        [VariableProperty(typeof(IntegerVariable))]
        [SerializeField] protected IntegerVariable storeResult;

        public override void OnEnter()
        {
            storeResult.Value = stringVar.Value.Length;

            Continue();
        }

        public override string GetSummary()
        {
            if (stringVar == null)
            {
                return "Error: String not selected";
            }

            if (storeResult == null)
            {
                return "Error: storeResult not set";
            }

            return "In Var: " + stringVar.Key + " = " + stringVar.Value + "; Out Var: " + storeResult.Key + " = " + storeResult.Value;
        }

        public override bool HasReference(Variable stringVar)
        {
            return (stringVar == this.stringVar) || storeResult == stringVar;
        }

        public override Color GetButtonColor()
        {
            return new Color32(253, 253, 150, 255);
        }
    }
} 