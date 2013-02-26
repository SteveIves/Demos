
using System.Collections.ObjectModel;

namespace Silverlight4.DragDropListBox
{
    public class PersonDataProvider
    {
        public static ObservableCollection<Person> GetData()
        {
            return new ObservableCollection<Person>
                        {
                            new Person { Name = "Akash Sharma" },
                            new Person { Name = "Vinay Sen" },
                            new Person { Name = "Lalit Narayan" },
                            new Person { Name = "Madhumita Chatterjee" },
                            new Person { Name = "Priyanka Patil" },
                            new Person { Name = "Kumar Sanu" },
                            new Person { Name = "Victor Kapoor" },
                            new Person { Name = "Shymal Sen" },
                            new Person { Name = "Alan D'Souza" },
                            new Person { Name = "Kamal Saha" },
                            new Person { Name = "Alex Chan" },
                            new Person { Name = "Rohit Sharma" },
                            new Person { Name = "Dipti Sen" },
                            new Person { Name = "Dinesh Sharma" },
                            new Person { Name = "Kamal Kapoor" },
                            new Person { Name = "Raj Kapoor" },
                            new Person { Name = "Deepa Karmakar" },
                            new Person { Name = "Sarmishtha Chakrobarty" },
                            new Person { Name = "Pranab Kumar Debnath" },
                            new Person { Name = "Hiral Grover" },
                            new Person { Name = "Munmun Patel" },
                            new Person { Name = "Santosh Kumar Sen" },
                            new Person { Name = "Sandeep Debnath" }
                        };
        }
    }
}