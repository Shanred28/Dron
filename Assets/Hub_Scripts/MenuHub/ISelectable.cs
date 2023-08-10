
namespace Hacaton
{
    public interface ISelectable
    {
        public bool IsSelected { set; }
        public void SelectItem();
        public void RemoveSelection();
    }
}

