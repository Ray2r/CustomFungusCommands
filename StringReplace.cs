using UnityEngine;

namespace Fungus
{
    /// <summary>
    /// Replace an Old string with a New string
    /// </summary>
    [CommandInfo("Variable",
                 "String Replace",
                     "Replace an Old string with a New string")]
    [AddComponentMenu("")]
    public class StringReplace : Command
    {
        [Tooltip("Input: String")]
        [VariableProperty(typeof(StringVariable))]
        [SerializeField] protected StringVariable stringVar;

        [Tooltip("Old string to get rid of")]
        [SerializeField] protected StringData stringOld;

        [Tooltip("New string to replace Old string")]
        [SerializeField] protected StringData stringNew;

        [Tooltip("Output: String")]
        [VariableProperty(typeof(StringVariable))]
        [SerializeField] protected StringVariable storeResult;

        public override void OnEnter()
        {
            storeResult.Value = stringVar.Value.Replace(stringOld.Value, stringNew.Value);

            Continue();
        }

        public override string GetSummary()
        {
            if (stringVar == null)
            {
                return "Error: String not selected";
            }

            if (stringOld == null)
            {
                return "Error: Old String not selected";
            }

            if (stringNew == null)
            {
                return "Error: New String not selected";
            }

            if (storeResult == null)
            {
                return "Error: storeResult not set";
            }

            return "In Var: " + stringVar.Key + "; Out Var: " + storeResult.Key + " = " + storeResult.Value;
        }

        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }
    }
}