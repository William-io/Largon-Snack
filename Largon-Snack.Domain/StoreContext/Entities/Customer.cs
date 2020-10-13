namespace Largon_Snack.Domain.StoreContext.Entities
{
    public class Customer
    {
        public Customer(
            string firtName,
            string lastName,
            string document,
            string email,
            string phone,
            string address)
        {
            FirtName = firtName;
            LastName = lastName;
            Document = document;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public string FirtName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }

        public override string ToString()
        {
            return $"{FirtName} {LastName}";
        }
    }
}
