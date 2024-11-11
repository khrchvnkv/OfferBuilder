using System;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

namespace Common.UnityLogic.UI.Components.InputField
{
    [RequireComponent(typeof(TMP_InputField))]
    public class PositiveFloatInputField : MonoBehaviour
    {
        private const string FloatRegexPattern = @"^\d+(\.\d+)?$";

        [SerializeField] private TMP_InputField _inputField;

        public void ResetInputValue() => _inputField.text = string.Empty;

        public float GetValue()
        {
            var text = _inputField.text;
            if (string.IsNullOrWhiteSpace(text))
            {
                return 0.0f;
            }

            if (float.TryParse(text, out var value))
            {
                return value;
            }

            throw new FormatException($"Input field has invalid value: '{text}'");
        }
        
        private void OnValidate() => 
            _inputField ??= gameObject.GetComponent<TMP_InputField>();

        private void OnEnable() => 
            _inputField.onValueChanged.AddListener(ValidateInput);
        
        private void OnDisable() => 
            _inputField.onValueChanged.AddListener(ValidateInput);

        private void ValidateInput(string input)
        {
            if (Regex.IsMatch(input, @"^\."))
            {
                input = Regex.Replace(input, @"^\.", "0.");
                _inputField.stringPosition = input.Length;
            }
            
            if (!Regex.IsMatch(input, FloatRegexPattern))
            {
                input = Regex.Replace(input, @"[^0-9.]", string.Empty);
                input = Regex.Replace(input, @"(?<=\..*?)\.", string.Empty);
                _inputField.text = input;
            }
        }
    }
}