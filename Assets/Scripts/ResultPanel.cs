using UnityEngine;
using UnityEngine.UI;

namespace Hacaton
{
    public class ResultPanel : SingletonBase<ResultPanel>
    {
        [SerializeField] private Text _ammountMoney;
        [SerializeField] private Text _ammountDetailsG1;

        [SerializeField] private Text _textTitle;
        [SerializeField] private Text _textButtonNextAction;

        [SerializeField] private Text _textPriceCargoMoney;

        private int _startMoney;
        private int _startDetailsG1;


        private bool _isSuccess;
        private void Start () 
        {
            _startMoney = Inventory.Instance.Money;
            _startDetailsG1 = Inventory.Instance.detailsOneGrade;
            gameObject.SetActive(false);
        }


        public void ShowResults(bool success)
        {
            Time.timeScale = 0;
            gameObject.SetActive(true);
            _isSuccess = success;
            _textTitle.text = success ? "Победа!" : "Разбился";
            _textButtonNextAction.text = success ? "Домой" : "Еще раз";
            _ammountMoney.text = (Inventory.Instance.Money - _startMoney).ToString();
            _ammountDetailsG1.text = (Inventory.Instance.detailsOneGrade - _startDetailsG1).ToString();
            if (success)
            {
                var cargo = Dron.Instance.cargoDron;
                var integrity = cargo.CurrentCargoIntegrity * 100 / cargo.MaxCargoIntegrity;
                var moneyCargo = (int)(cargo.CoastCargo * integrity / 100);
                Inventory.Instance.AddMoney(moneyCargo);
                _textPriceCargoMoney.text = moneyCargo.ToString();
            }
            else
                _textPriceCargoMoney.text = "Груз утерян";

        }

        public void OnButtonNextAction()
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
            if (_isSuccess)
                LevelSequenceController.Instance.ReturnHUB();
            else
                LevelSequenceController.Instance.RestartLevel();
        }

    }
}

