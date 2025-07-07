using TMPro;
using UnityEngine;

namespace Modules.New
{
    public class ManaView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _mana;

        public void UpdateManaText(int manaAmount)
        {
            _mana.text = manaAmount.ToString();
        }
    }
}
