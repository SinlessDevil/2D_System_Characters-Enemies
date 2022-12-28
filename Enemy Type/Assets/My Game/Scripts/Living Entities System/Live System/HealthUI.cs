using UnityEngine;
using LiveSystem.HealthEntitySystem;

namespace LiveSystem
{
    public class HealthUI : MonoBehaviour
    {
        [Header("Parameters Health UI")]
        [SerializeField] private TMPro.TMP_Text _countHealth;
        [SerializeField] private UnityEngine.UI.Image _fillBarHealth;
        [Space(10)]
        [Header("Link to Ñharacter")]
        [SerializeField] private HealthCharacter _characterHealth;

        private int _maxValueHealth;

        private void Start()
        {
            if (_characterHealth == null)
                throw new System.NullReferenceException("GameObject Character has not been assigned");
        }

        private void OnEnable()
        {
            _characterHealth.OnHealthChangeEvent += UpdateHealthUI;
            _characterHealth.OnHealthChangeByDefouldEvent += UpdateHealthUIByDelould;
        }

        private void OnDisable()
        {
            _characterHealth.OnHealthChangeEvent -= UpdateHealthUI;
            _characterHealth.OnHealthChangeByDefouldEvent -= UpdateHealthUIByDelould;
        }

        private void UpdateHealthUI(int health)
        {
            _countHealth.text = health.ToString();
            _fillBarHealth.fillAmount = health / _maxValueHealth;
        }

        private void UpdateHealthUIByDelould(int health)
        {
            _maxValueHealth = health;
            _countHealth.text = _maxValueHealth.ToString();
        }
    }
}