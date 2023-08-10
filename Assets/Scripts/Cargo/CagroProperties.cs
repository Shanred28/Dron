using UnityEngine;

namespace Hacaton
{
    public enum CargoType
    { 
        VeryFragile,
        Fragily,
        NotFragily
    }

    [CreateAssetMenu]
    public sealed class CagroProperties : ScriptableObject
    {
        [SerializeField] private CargoType _cargoType;
        public CargoType TypeCargo => _cargoType;

        [SerializeField] private Cargo _visualModel;
        [SerializeField] private string _Name;
        public string Name => _Name;
        [SerializeField] private float _weight;
        public float Weight => _weight;
        [SerializeField] private float _cargoIntegrity;
        public float CargoIntegrity => _cargoIntegrity;

        [SerializeField] private int _costCargo;
        public int CostCargo => _costCargo;

    }
}
