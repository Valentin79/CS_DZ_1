namespace CS_Sem_1
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            // Бабушка
            var person_2 = new AdultFamilyMember()
                { Mother = null, Fater = null, Name = "Ольга", Sex = Gender.Female };
            // Дедушка
            var grandfather = new AdultFamilyMember()
                { Mother = null, Fater = null, Name = "Андрей", Sex = Gender.Male };
            // Отец
            var father = new AdultFamilyMember() 
                { Mother = null, Fater = grandfather, Name = "Гриша", Sex = Gender.Male, };
            // Мать
            var mother = new AdultFamilyMember() 
                { Mother = person_2, Fater = null, Name = "Маша", Sex = Gender.Female };
            // Сын
            var son = new FamilyMember()
                { Mother = mother, Fater = father, Name= "Вася", Sex= Gender.Male };
            // Дядя
            var person_1 = new AdultFamilyMember()
                { Mother = null, Fater = grandfather, Name = "Евгений", Sex = Gender.Male };
            // Дядя по линии матери
            var person_3 = new AdultFamilyMember()
                { Mother = person_2, Fater = null, Name = "Петр", Sex = Gender.Male };
            // Жена Петра (person_3)
            var person_5 = new AdultFamilyMember()
            { Mother = null, Fater = null, Name = "Полина", Sex = Gender.Female };
            // Ребенок person_3 и person_5 
            var person_4 = new FamilyMember()
                { Mother = person_5, Fater = person_3, Name = "Настя", Sex = Gender.Female };
            // дочь person_5 и father
            var person_6 = new FamilyMember()
                { Mother = person_5, Fater = father, Name = "Катя", Sex = Gender.Female };


            // раздаём детей
            grandfather.Children = new FamilyMember[] { father, person_1 };
            mother.Children = new FamilyMember[] { son,};
            father.Children = new FamilyMember[] { son, person_6 };
            person_2.Children = new FamilyMember[] { person_3 };
            person_3.Children = new FamilyMember[] { person_4 };
            person_5.Children = new FamilyMember[] { person_4, person_6 };


            // распределяем супругов
            mother.Spouse = father;
            father.Spouse = mother;
            person_3.Spouse = person_5;
            person_5.Spouse = person_3;


            //grandfather.Print(2);
            //father.ShowSpouse();
            //person_6.ShowParents();
            //person_6.ShowGrandParents();
            Tools.ShowSiblings(person_6);
            Console.ReadLine();
        }
    }
}