using Models.Domain;

namespace Application.Interfaces
{
    public interface IAddressesService
    {
        Task<List<Address>> GetAllAddressesAsync();
        Task<Address> CreateAddressAsync(Address address);
        Task<Address> UpdateAddressAsync(Address address);
        Task<Address> GetAddressDetailsAsync(Guid addressId);
    }
}
