public class Contact
{

    public string Name { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Telephone { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public bool IsBestFriend { get; set; }

    public Contact(string name, string lastName, string address, string telephone, string email, int age, bool isBestFriend)
    {
        Name = name;
        LastName = lastName;
        Address = address;
        Telephone = telephone;
        Email = email;
        Age = age;
        IsBestFriend = isBestFriend;
    }
}
