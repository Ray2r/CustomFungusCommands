using UnityEngine;

namespace Fungus
{
    /// <summary>
    /// Round float to decimal places
    /// </summary>
    [CommandInfo("Math",
                 "Round Float",
                     "Round float to decimal places.")]
    [AddComponentMenu("")]
    public class RoundFloat : Command
    {
        [Tooltip("Input")]
        [VariableProperty(typeof(FloatVariable))]
        [SerializeField] protected FloatVariable floatVar;

        public enum Operation
        {
            Zero,
            One,
            Two,
            Three,
            Four,
            Five,
            Six
        }

        [Tooltip("Decimal places to use")]
        [SerializeField] protected Operation decimalPlaces = Operation.Two;

        [Tooltip("Output")]
        [VariableProperty(typeof(FloatVariable))]
        [SerializeField] protected FloatVariable storeResult;

        public override void OnEnter()
        {
            switch (decimalPlaces)
            {
                case Operation.Zero:
                    storeResult.Value = Mathf.Round(floatVar.Value);
                    break;
                case Operation.One:
                    storeResult.Value = Mathf.Round((floatVar.Value) * 10f) / 10f;
                    break;
                case Operation.Two:
                    storeResult.Value = Mathf.Round((floatVar.Value) * 100f) / 100f;
                    break;
                case Operation.Three:
                    storeResult.Value = Mathf.Round((floatVar.Value) * 1000f) / 1000f;
                    break;
                case Operation.Four:
                    storeResult.Value = Mathf.Round((floatVar.Value) * 10000f) / 10000f;
                    break;
                case Operation.Five:
                    storeResult.Value = Mathf.Round((floatVar.Value) * 100000f) / 100000f;
                    break;
                case Operation.Six:
                    storeResult.Value = Mathf.Round((floatVar.Value) * 1000000f) / 1000000f;
                    break;
            }

            Continue();
        }

        public override string GetSummary()
        {
            if (floatVar == null)
            {
                return "Error: Float not selected";
            }

            if (storeResult == null)
            {
                return "Error: storeResult not set";
            }

            return "Decimals: " + decimalPlaces.ToString() + "; In: " + floatVar.Key + " = " + floatVar.Value + "; Out: " + storeResult.Key + " = " + storeResult.Value;
        }

        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }
    }
}