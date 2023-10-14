using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sem_1
{
    public enum Gender
    {
        Male,
        Female
    }


    public class FamilyMember
    {
        public FamilyMember Mother { get; set; }
        public FamilyMember Fater { get; set; }
        public string Name { get; set; }
        public Gender Sex { get; set; }


        void Info(int indent = 0)
        {
            Console.WriteLine($"{new String('-', indent)}Имя {this.Name}");
        }
        public virtual void Print(int indent = 0)
        {
            Info(indent);
        }

        public void ShowParents()
        {
            Console.WriteLine($"Mother: {Mother?.Name}");
            Console.WriteLine($"Fater: {Fater?.Name}");
        }

        public void ShowGrandParents()
        {
            Console.WriteLine($"Grandparent: {Mother?.Fater?.Name}");
            Console.WriteLine($"Grandparent: {Fater?.Fater?.Name}");
        }

        

    }


    public class AdultFamilyMember : FamilyMember
    {
        public FamilyMember Spouse { get; set; }
        public FamilyMember[] Children { get; set; }

        public override void Print(int indent = 0)
        {
            base.Print(indent);
            if (Children != null)
            {
                foreach (var child in Children)
                    child.Print(indent * 2);
            }

        }

        public void ShowSpouse()
        {
            if (this.Sex == Gender.Female)
            {
                Console.WriteLine($"Супруг: {Spouse?.Name}");
            }
            else
            {
                Console.WriteLine($"Супруга: {Spouse?.Name}");
            }
        }

    }
    public class Tools
    {
        public static void ShowSiblings(FamilyMember person)
        {
            AdultFamilyMember[] parents = { (AdultFamilyMember) person.Mother, (AdultFamilyMember)person.Fater };
            foreach (var parent in parents)
            {
                if (parent.Children != null) // Тут наверное проверка не нужна, потому что изначально мы идем от ребенка.
                {
                    foreach (FamilyMember child in parent.Children)
                        if (!person.Name.Equals(child.Name))  // Тут надо бы использовать id, но для примера сойдет
                        {
                            Console.WriteLine(child.Name);

                        }
                        
                }

            }

        }
    }
}
