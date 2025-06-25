using TMPro;
using UnityEngine;

namespace Modules.Content.Card.Scripts
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _mana;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private GameObject _wrapper;

        public void Setup(CardModel cardModel)
        {
            _mana.text = cardModel.ManaAmount.ToString();

            _name.text = cardModel.Name;

            _spriteRenderer.sprite = cardModel.Image;
        }
    }
}