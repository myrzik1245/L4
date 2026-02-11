using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.Utility.LoadScreen
{
    public class LoadScreen : MonoBehaviour, ILoadScreen
    {
        [SerializeField] private Image _animationImage;
        [SerializeField] private float _animationSpeed;

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            Hide();
        }

        private void Update()
        {
            float offset = _animationSpeed * Time.deltaTime;

            _animationImage.rectTransform.Rotate(0, 0, offset);
        }
    }
}