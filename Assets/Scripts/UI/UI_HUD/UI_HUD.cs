using UnityEngine;
using UnityEngine.UI;

namespace Hacaton
{
    public class UI_HUD : MonoBehaviour
    {
        [SerializeField] private Image _imageFilledHP;
        [SerializeField] private Image _imageFilledEnergy;

        [SerializeField] private Dron _dron;
        [SerializeField] private Cargo _cargo;
        [SerializeField] private Text _textCountBoxMail;
        [SerializeField] private Text _textCoin;

        void Start () 
        {
            Player.Instance.ChangeCountBoxMail.AddListener(ChangeBoxMail);
            Inventory.Instance.ChangeCoin += ChangeCoin;
            _textCoin.text = Inventory.Instance.Money.ToString();
        }

        private void Update()
        {
            _imageFilledHP.fillAmount = _cargo.CurrentCargoIntegrity / _cargo.MaxCargoIntegrity;
            _imageFilledEnergy.fillAmount = _dron.CurrentEnergy / _dron.MaxEnergy;
        }

        private void ChangeBoxMail()
        {
            _textCountBoxMail.text = Player.Instance.CountBoxMail.ToString();
        }

        private void ChangeCoin() 
        {
            _textCoin.text = Inventory.Instance.Money.ToString();
        }
    }
}

