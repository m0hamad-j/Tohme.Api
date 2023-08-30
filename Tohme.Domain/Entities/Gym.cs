using Tohme.Shared.Abstraction;

namespace Tohme.Domain.Entities
{
    public class Gym : BaseEntity
    {
        public string Name { get; set; }
        public List<Trainer> Trainers { get; set; }=new List<Trainer>();
        public List<Trainee> Trainees { get; set; } = new List<Trainee>();
        public List<Protein> Proteins { get; set; } = new List<Protein>();
        public List<Dumbbell> Dumbbells { get; set; } =new List<Dumbbell>();

        public Gym(string name)
        {
            Name = name;
        }

        public void Update(string name)
            => Name = name;

        public void AddTrainer(Trainer trainer)
        {
            Trainers.Add(trainer);
        }
        public void AddTrainee(Trainee trainee)
        {
            Trainees.Add(trainee);
        }
        public void AddProtein(Protein protein)
        { 
            Proteins.Add(protein);
        }
        public void AddDumbbell(Dumbbell dumbbell)
        {
            Dumbbells.Add(dumbbell);
        }
    }
}
