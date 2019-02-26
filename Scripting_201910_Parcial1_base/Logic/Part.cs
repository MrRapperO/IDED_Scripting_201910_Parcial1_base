namespace Scripting_201910_Parcial1_base.Logic
{
    public abstract class Part
    {
        protected float speedBonus;
        protected float durability;

        public int Level { get; protected set; }
        public abstract VehicleType Type { get; }

        public float SpeedBonus
        {

            //Las partes pueden tener un desgaste, dado por su atributo Durability,
            //Cada nivel de la parte adiciona un 3 % del valor de SpeedBonus original al SpeedBonus que le otortga al vehículo que la tiene equipada.

            get { return (speedBonus*durability)*(0.03*Level); }
            protected set { speedBonus = value; }
        }

        public Part()
        {
        }

        public Part(float _speedBonus)
        {
            speedBonus = _speedBonus;
        }

        public void Upgrade()
        {
            if (Level < 3)
            {
                Level += 1;
            }
        }
    }
}