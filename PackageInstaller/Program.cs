using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




public class Package
{
    public string Name { get; set; }
    public ICollection<string> Dependencies { get; set; }


   



    static void Main(string[] args)
    {
        var example3 = new[]
               {
        new Package { Name = "R2D2", Dependencies = new List<string> { "C3PO" }},
        new Package { Name = "C3PO", Dependencies = new List<string> { "stupid ball" }},
        new Package { Name = "stupid ball", Dependencies = new List<string> { "R2D2" }},
    };
        var example2 = new[]
       {
        new Package { Name = "Luke", Dependencies = new List<string> { "Padme", "Anakin", "Darth Vader" }},
        new Package { Name = "Chewbacca", Dependencies = new List<string> { "Han" }},
        new Package { Name = "Leia", Dependencies = new List<string> { "Padme", "Anakin" }},
        new Package { Name = "Han", Dependencies = new List<string> { "Millenium Falcon", "Leia" }},
        new Package { Name = "Jaina", Dependencies = new List<string> { "Han", "Leia" }},
        new Package { Name = "Boba Fett", Dependencies = new List<string> {}},
        new Package { Name = "Darth Vader", Dependencies = new List<string> {"Palpatine"}}
        };

        

        var packager = new Packager();


        foreach(String answer in packager.InstallPackages(example2))
        {
            Console.WriteLine(answer);
        }
        var name = Console.ReadLine();

    }



}

public class Packager
{
    public void WriteToConsole(IEnumerable items)
    {
        foreach(string o in items)
        {
            Console.WriteLine(o);
        }
    }
    public IEnumerable<string> InstallPackages(IEnumerable<Package> packages)
    {
        List<string> dependencies = new List<string>();
        List<string> names = new List<string>();
        List<string> answer = new List<string>();
        List<string> toremove = new List<string>();
        foreach (Package thing in packages)
            {
                names.Add(thing.Name);
                //Console.WriteLine(thing.Name);
                foreach (string o in thing.Dependencies)
                {
                if (!dependencies.Contains(o))
                {
                    dependencies.Add(o);
                }
                    
                }

            }
        int stupidhack = names.Union(dependencies).Count();
        int y = 0;
        while (! (answer.Count == stupidhack))
        {
            y++;
            //dependencies.Intersect(toremove);
            if (y > 1000)
            {
                Console.WriteLine("You either have a looping dependency or are trying to import too many packages..what are you, a node.js dev?");
                break;
            }
            //foreach (String thing in dependencies)
            for (int i = dependencies.Count -1; i>=0; i--)
            {
                while(i >= dependencies.Count)
                {
                    i--;
                }
                if (!names.Contains(dependencies[i]))
                {
                    if (!answer.Contains(dependencies[i]))
                    {
                        answer.Add(dependencies[i]);
                        dependencies.RemoveAt(i);
                       // toremove.Add(thing);

                        
                    }
                    
                }
            }
            foreach (Package temp in packages)
            {
                int x = 0;
                foreach (string depen in temp.Dependencies)
                {


                    if (answer.Contains(depen))
                    {
                        x++;
                    }

                }
                if (x == temp.Dependencies.Count())
                {
                    if (!answer.Contains(temp.Name))
                    {
                        answer.Add(temp.Name);
                        dependencies.Remove(temp.Name);
                    }
                }
            }

        }
       


        
        return answer;
    }


}

