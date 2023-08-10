using System;

namespace Hacaton
{
    public enum GradeBox
    { 
        OneGrade, 
        TwoGrade, 
        ThreeGrade
    }
    public class Inventory : SingletonBase<Inventory>
    {
        public int _money;
        public int Money => _money;
        public int detailsOneGrade { get; private set; }
        
        private int _detailsTwoGrade;
        private int _detailsTreeGrade;

        public event Action ChangeCoin;
        public void AddMoney(int countMoney)
        {
            _money += countMoney;
            ChangeCoin?.Invoke();
        }
        public void AddBox(GradeBox lvGrade)
        {
            switch (lvGrade)
            {
                case GradeBox.OneGrade:
                    detailsOneGrade += 1;
                    break;

                case GradeBox.TwoGrade:
                    _detailsTwoGrade += 1;
                    break;

                case GradeBox.ThreeGrade:
                    _detailsTreeGrade += 1;
                    break;

            }                          
        }
    }
}

