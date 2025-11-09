namespace Assignment8_Inheritance_Overloading_Constructors.Models
{
    internal class Coffee
    {
        private string _beanType;
        private int _strength;
        private bool _withMilk;

        public string BeanType
        {
            get { return _beanType; }
            set { _beanType = value; }
        }

        public int Strength
        {
            get { return _strength; }
            set { _strength = value;  }
        }

        public bool WithMilk
        {
            get { return _withMilk; }
            set { _withMilk = value; }
        }

        public Coffee(string beanType, int strength, bool withMilk)
        {
            BeanType = beanType;
            Strength = strength;
            WithMilk = withMilk;
        }

        public Coffee(string beanType, int strength) : this(beanType, strength, false)
        {
        }

        public Coffee() : this("Arabica", 3)
        {
        }
    }
}
