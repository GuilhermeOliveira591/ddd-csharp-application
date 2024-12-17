

using ddd_csharp_application.src.Domain.Customer.ValueObject;

namespace ddd_csharp_application.src.Domain.Customer.Entity
{
    public class CustomerEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Address? Address { get; set; }
        public bool Active { get; set; } = true;
        public decimal RewardPoints { get; set; } = 0;

        public CustomerEntity(string id, string name)
        {
            this.Id = id;
            this.Name = name;
            this.Validate();
        }

        public bool Validate()
        {
            if (this.Id.Length == 0)
            {
                throw new ArgumentException("Id is required");
            }

            if (this.Name.Length == 0)
            {
                throw new ArgumentException("Name is required");
            }

            return true;

        }

        public void ChangeName(string name)
        {
            this.Name = name;
            this.Validate();
        }

        public void ChangeAddress(Address address)
        {
            this.Address = address;
        }

        public void Activate()
        {
            if (this.Address == null)
            {
                throw new ArgumentException("Address is mandatory to activate a costumer");
            }

            this.Active = true;
        }

        public void Deactivate()
        {
            this.Active = false;
        }

        public bool IsActive()
        {
            return this.Active;
        }

        public void AddRewardPoints(decimal points)
        {
            this.RewardPoints += points;
        }

    }
}


