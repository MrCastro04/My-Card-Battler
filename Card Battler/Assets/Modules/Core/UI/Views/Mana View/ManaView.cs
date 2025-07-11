using TMPro;
using UnityEngine;

namespace Modules.Core.UI.Views.Mana_View
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
