using Application.Interfaces;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.Domain;

namespace Application.Services
{
    public class AddressesService : IAddressesService
    {
        private readonly AppDbContext _context;
        public AddressesService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<Guid> CreateAddressAsync(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
            return address.Guid ?? Guid.Empty;
        }

        public async Task<Address> GetAddressDetailsAsync(Guid addressId)
        {
            return await _context.Addresses.FirstOrDefaultAsync(x => x.Guid == addressId);
        }

        public async Task<List<Address>> GetAllAddressesAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<Address?> UpdateAddressAsync(Address updatedAddress)
        {
            var existingAddress = await _context.Addresses
                .FirstOrDefaultAsync(x => x.Guid == updatedAddress.Guid);

            if (existingAddress == null)
                return null;

            existingAddress.City = updatedAddress.City;
            existingAddress.Street = updatedAddress.Street;
            existingAddress.PostalCode = updatedAddress.PostalCode;
            existingAddress.Region = updatedAddress.Region;

            _context.Addresses.Update(existingAddress);
            await _context.SaveChangesAsync();

            return existingAddress;
        }
    }
}
