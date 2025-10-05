using Models.Domain;

namespace Application.Interfaces
{
    public interface IAddressesService
    {
        Task<List<Address>> GetAllAddressesAsync();
        Task<Guid> CreateAddressAsync(Address address);
        Task<Address> UpdateAddressAsync(Address address);
        Task<Address> GetAddressDetailsAsync(Guid addressId);
    }
}
