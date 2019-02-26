namespace Scripting_201910_Parcial1_base.Logic
{
    public class Nitro : Part
    {
        public Nitro() : base()
        {
        }

        public Nitro(float speedBonus) : base(speedBonus)
        {
        }

        public override VehicleType Type
        {
            get
            {
                //Nitro: Solo puede ser equipada a vehículos Car.

                return VehicleType.Car;
            }
        }
    }
}