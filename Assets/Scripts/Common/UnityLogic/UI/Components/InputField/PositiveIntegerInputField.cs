using NaughtyAttributes;
using TMPro;
using UnityEngine;

namespace Common.UnityLogic.UI.Components.InputField
{
    [RequireComponent(typeof(TMP_InputField))]
    public sealed class PositiveIntegerInputField : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private bool _hasMaxValue;
        [SerializeField, ShowIf(nameof(_hasMaxValue))] private int _maxValue;
        [SerializeField] private bool _hasDefaultValue;
        [SerializeField, ShowIf(nameof(_hasDefaultValue))] private int _defaultValue;

        private void OnValidate()
        {
            _inputField ??= gameObject.GetComponent<TMP_InputField>();
            if (_hasMaxValue && _maxValue < 0)
            {
                _maxValue = 0;
            }
            
            if (_hasDefaultValue && _defaultValue < 0)
            {
                _defaultValue = 0;
            }
        }

        private void OnEnable()
        {
            _inputField.text = 0.ToString();
            _inputField.onValueChanged.AddListener(ValidateInput);
        }

        private void OnDisable() => _inputField.onValueChanged.RemoveListener(ValidateInput);

        private void ValidateInput(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return;

            if (int.TryParse(text, out var value))
            {
                if (value < 0)
                {
                    value = 0;
                }

                if (_hasMaxValue && value > _maxValue)
                {
                    value = _maxValue;
                }
                
                _inputField.text = value.ToString();
            }
        }
    }
}