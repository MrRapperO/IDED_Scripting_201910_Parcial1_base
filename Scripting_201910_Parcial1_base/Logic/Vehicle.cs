namespace Scripting_201910_Parcial1_base.Logic
{
    public abstract class Vehicle
    {
        protected float baseMaxSpeed, maxSpeed;

        protected int Level { get; set; }

        protected abstract VehicleType Type { get; }

        protected Part CurrentPart { get; set; }

        public float MaxSpeed
        {
            get
            {
                return maxSpeed;
            }
        }

        public Vehicle()
        {
        }

        public Vehicle(float _baseMaxSpeed)
        {
            baseMaxSpeed = _baseMaxSpeed;

            //Sin partes equipadas, MaxSpeed = baseMaxSpeed para cualquier vehículo.
            maxSpeed = baseMaxSpeed;
            //--

            Level = 0;
            CurrentPart = null;
        }

        public bool Equip(Part part)
        {
            bool result = false;

            if (Type == part.Type || part.Type == VehicleType.Any)
            {

                //Cada vehículo solo puede tener una parte Part equipada
                CurrentPart = part;


                UpdateSpeed();

                result = true;

            }

            return result;
        }

        protected void UpdateSpeed() {
            if (CurrentPart.SpeedBonus() > 0.5f)
            {
                //En ningún caso la bonificación puede duplicar el valor del baseMaxSpeed del vehículo, por lo que el valor de este porcentaje no podrá ser mayor al 50%
                maxSpeed = baseMaxSpeed + (baseMaxSpeed * 0.5f);
            }
            else
            {
                //Todas las Part adicionan un porcentaje SpeedBonus a la velocidad del vehículo
                maxSpeed = baseMaxSpeed + (baseMaxSpeed * CurrentPart.SpeedBonus());
            }
        }

        public void Upgrade()
        {
            //Un jugador puede mejorar su vehículo al hacerle un Upgrade. Esto subirá el Level del vehículo y la parte que tenga equipada hasta 3 veces.
            if (Level<3)
            {
                Level += 1;

                //•	Solo la parte equipada será afectada por la mejora.
                CurrentPart.Upgrade();

                //Cada nivel del vehículo incrementa un 5 % de la baseMaxSpeed al vehículo.
                baseMaxSpeed = baseMaxSpeed + (baseMaxSpeed*0.05f);

                UpdateSpeed();

                
            }
        }
    }
}