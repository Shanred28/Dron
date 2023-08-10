using UnityEngine;
using UnityEngine.Events;

namespace Hacaton
{

    public class Cargo : MonoBehaviour
    {
        private bool _indestructible = false;
        public bool IsIndestructible => _indestructible;

        [SerializeField] private CargoType _cargoType;
        public CargoType TypeCargo => _cargoType;

        [SerializeField] private CagroProperties _cagroProperties;
        public int CoastCargo => _cagroProperties.CostCargo;

        [SerializeField] private float _damageCargo = 10;

        private Dron _dron;

        //  В конце миссии передать значения, для определения награды. 
        private float _currentCargoIntegrity;
        public float CurrentCargoIntegrity => _currentCargoIntegrity;

        private float _maxCargoIntegrity;
        public float MaxCargoIntegrity => _maxCargoIntegrity;

        private bool _IsDestroyCargo;
        public bool IsDestroyCargo => _IsDestroyCargo;

        [HideInInspector] public UnityEvent ChangeCargoIntegrityEvent;


        private void Start()
        {
            _dron = transform.root.GetComponent<Dron>();
            _maxCargoIntegrity = _cagroProperties.CargoIntegrity;
            _currentCargoIntegrity = _maxCargoIntegrity;
            DamageCargo();
            _dron.CrashedEvent.AddListener(ApplyDamage);
        }


        private void DamageCargo()
        {
            if (_cargoType == CargoType.VeryFragile)
            {
                _damageCargo = _damageCargo * 2;
            }
            if (_cargoType == CargoType.Fragily)
            {
                _damageCargo = _damageCargo + 1;
            }
            if (_cargoType == CargoType.NotFragily)
            {
                _indestructible = true; 
            }
        }

        public void ApplyDamage()
        {
            if (_indestructible) return;
            if (_IsDestroyCargo) return;

            _currentCargoIntegrity -= _damageCargo + _dron.ForceCrashed;
            ChangeCargoIntegrityEvent?.Invoke();

            if (_currentCargoIntegrity <= 0)
                DestroyedCargo();
        }

        private void DestroyedCargo()
        {
            _IsDestroyCargo = true;
        }

    }
}

