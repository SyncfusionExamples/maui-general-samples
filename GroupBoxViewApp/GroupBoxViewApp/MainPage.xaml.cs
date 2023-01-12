using System.Collections.ObjectModel;

namespace GroupBoxViewApp;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
        this.BindingContext = new GroupMemberViewModel();
    }

}

public class GroupMemberViewModel
{
    public ObservableCollection<Person> GroupMembers { get; set; }
    public ObservableCollection<Person> GroupMembers1 { get; set; }
    public ObservableCollection<Person> GroupMembers2 { get; set; }


    private String myVar = "Text Value";

    public String TextString
    {
        get
        {
            return myVar;
        }
        set
        {
            myVar = value;
        }
    }


    public GroupMemberViewModel()
    {

        GroupMembers = new ObservableCollection<Person>();
        GroupMembers1 = new ObservableCollection<Person>();
        GroupMembers2 = new ObservableCollection<Person>();

        GroupMembers.Add(new Person() { Name = "Clara", Picture = "clara.png", Color = Colors.LightPink });
        GroupMembers.Add(new Person() { Name = "Alexandar", Picture = "alexandar.png", Color = Colors.LightGreen });
        GroupMembers.Add(new Person() { Name = "Gabriella", Picture = "gabriella.png" });
        GroupMembers1.Add(new Person() { Name = "Lita", Picture = "lita.png" });
        GroupMembers1.Add(new Person() { Name = "Nora", Picture = "nora.png" });
        GroupMembers1.Add(new Person() { Name = "Sebastian", Picture = "sebastian.png" });
        GroupMembers2.Add(new Person() { Name = "Tye", Picture = "tye.png" });
        GroupMembers2.Add(new Person() { Name = "Jennifer", Picture = "jennifer.png" });
        GroupMembers2.Add(new Person() { Name = "Jackson", Picture = "jackson.png" });
    }


    public class Person
    {
        public String Name { get; set; }
        public String Picture { get; set; }
        public Color Color { get; set; }
    }
}

