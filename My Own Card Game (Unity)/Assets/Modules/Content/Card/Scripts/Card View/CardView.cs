using Modules.Content.Card.Scripts.Models;
using TMPro;
using UnityEngine;

namespace Modules.Content.Card.Scripts.Card_View
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _manaAmount;
        [SerializeField] private TMP_Text _attackAmount;
        [SerializeField] private TMP_Text _healthAmount;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _description;
        [SerializeField] private TMP_Text _cardType;
        [SerializeField] private GameObject _wrapper;
        
        public void Setup(CardModel cardModel)
        {
            _manaAmount.text = cardModel.ManaAmount.ToString();

            _attackAmount.text = cardModel.AttackAmount.ToString();

            _healthAmount.text = cardModel.HealthAmount.ToString();
            
            _cardType.text = cardModel.CardType.ToString();

            _name.text = cardModel.Name;

            _description.text = cardModel.Description;
        }
    }
}