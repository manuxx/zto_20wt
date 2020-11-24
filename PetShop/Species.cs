using System;

namespace Training.DomainClasses
{
    public class Species
    {
        public static readonly Species Rabbit = new Species(3, EnviromentType.Cage);
        public static readonly Species Mouse = new Species(1, EnviromentType.Cage);
        public static readonly Species Cat = new Species(7, EnviromentType.Home);
        public static readonly Species Snake = new Species(1, EnviromentType.Terrarium);
        public static readonly Species Dog = new Species(12, EnviromentType.Home);

        public int EstimatedLenOfLife { get; }
        public EnviromentType Environment1 { get; }

        private Species(int estimatedLenOfLife, EnviromentType environment)
        {
            this.EstimatedLenOfLife = estimatedLenOfLife;
            this.Environment1 = environment;
        }
    }
}
