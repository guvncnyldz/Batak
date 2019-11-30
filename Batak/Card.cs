using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batak
{
    public class Card
    {
        public CardType Type { get; private set; }
        public int Value { get; private set; }
        public bool IsPushable { get; private set; }

        public Card(int value, CardType type)
        {
            this.Value = value;
            this.Type = type;
        }

        public void Pushable(bool isPushable)
        {
            this.IsPushable = isPushable;
        }

        public bool Compare(Card card)
        {
            bool isValueEqual = card.Value == Value;
            bool isTypeEqual = card.Type == Type;

            return isTypeEqual && isValueEqual;
        }

        public bool Compare(int value)
        {
            return this.Value == value;
        }

        public bool Compare(CardType trumpType)
        {
            return Type == trumpType;
        }
    }
}
