using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using TradeFlowAPI.Business.Abstract;
using TradeFlowAPI.DataAccess.Abstract;
using TradeFlowAPI.DataAccess.Concrete.EntityFramework;
using TradeFlowAPI.Entities.Concrete;
using TradeFlowAPI.Entities.DTOs;
using TradeFlowAPI.Entities.Enums;

namespace TradeFlowAPI.Business.Concrete
{
    public class AdressManager : IAdressService
    {
        private readonly IAdressDal _adressDal;

        public AdressManager(IAdressDal addressDal)
        {
            _adressDal = addressDal;
        }
        public IDataResult<List<Adress>> GetAll()
        {
            var result = _adressDal.GetAll();
            return new SuccessDataResult<List<Adress>>(result, "Addresses listed.");
        }

        public IDataResult<List<Adress>> GetAllOrderedByUpdateDate()
        {
            var result = _adressDal.GetAll().OrderByDescending(a => a.UpdatedDate).ToList();
            return new SuccessDataResult<List<Adress>>(result, "Addresses ordered by update date.");
        }

        public IDataResult<List<Adress>> GetByAddressType(AddressType type)
        {
            var result = _adressDal.GetAll(a => a.AddressType == type);
            return new SuccessDataResult<List<Adress>>(result, $"Addresses with type {type} listed.");
        }

        public IDataResult<List<Adress>> GetByCity(string city)
        {
            var result = _adressDal.GetAll(a => a.City.Equals(city, StringComparison.OrdinalIgnoreCase));
            return new SuccessDataResult<List<Adress>>(result, $"Addresses in {city} listed.");
        }

        public IDataResult<Adress> GetById(Guid id)
        {
            var result = _adressDal.Get(a => a.Id == id);
            return new SuccessDataResult<Adress>(result, "Address fetched by Id.");
        }

        public IDataResult<List<Adress>> GetByState(string state)
        {
            var result = _adressDal.GetAll().Where(a => a.State.ToLower() == state.ToLower()).ToList();
            if (result.Any())
            {
                return new SuccessDataResult<List<Adress>>(result);
            }
            return new ErrorDataResult<List<Adress>>("No addresses found with this state.");
        }

        public IDataResult<List<Adress>> GetByUserId(Guid userId)
        {
            var result = _adressDal.GetAll(a => a.UserId == userId);
            return new SuccessDataResult<List<Adress>>(result, $"Addresses for UserId {userId} listed.");
        }

        public IDataResult<List<Adress>> GetByZipCode(string zipCode)
        {
            var result = _adressDal.GetAll(a => a.ZipCode.Equals(zipCode));
            return new SuccessDataResult<List<Adress>>(result, $"Addresses with ZipCode {zipCode} listed.");
        }

        public IDataResult<List<Adress>> GetUpdatedAfter(DateTime date)
        {
            var result = _adressDal.GetAll(a => a.UpdatedDate > date);
            return new SuccessDataResult<List<Adress>>(result, $"Addresses updated after {date} listed.");
        }

        public IResult Add(AdressDetailDto addressDto)
        {
            // Adres DTO'sundan adres entity'si oluşturuluyor
            var address = new Adress
            {
                Street = addressDto.Street,
                City = addressDto.City,
                State = addressDto.State,
                ZipCode = addressDto.ZipCode,
                UserId = addressDto.UserId,
                AddressType = addressDto.AddressType
            };

            _adressDal.Add(address);
            return new SuccessResult("Address added successfully.");
        }

        public IResult Update(Guid id, AdressDetailDto addressDto)
        {
            var existingAddress = _adressDal.Get(a => a.Id == id);
            if (existingAddress == null)
            {
                return new ErrorResult("No address found to update.");
            }

            existingAddress.Street = addressDto.Street;
            existingAddress.City = addressDto.City;
            existingAddress.State = addressDto.State;
            existingAddress.ZipCode = addressDto.ZipCode;
            existingAddress.UserId = addressDto.UserId;
            existingAddress.AddressType = addressDto.AddressType;

            _adressDal.Update(existingAddress);
            return new SuccessResult("Address updated successfully.");
        }

        public IResult Delete(Guid id)
        {
            var address = _adressDal.Get(a => a.Id == id);
            if (address == null)
            {
                return new ErrorResult("No address found to delete.");
            }

            _adressDal.Delete(address);
            return new SuccessResult("Address deleted successfully.");
        }

        public IResult ValidateAddressFormat(AdressDetailDto addressDto)
        {
            if (string.IsNullOrWhiteSpace(addressDto.Street) || string.IsNullOrWhiteSpace(addressDto.City) ||
                string.IsNullOrWhiteSpace(addressDto.State) || string.IsNullOrWhiteSpace(addressDto.ZipCode))
            {
                return new ErrorResult("Address fields cannot be empty.");
            }

            // ZipCode format validation example (basic check)
            if (!addressDto.ZipCode.All(char.IsDigit))
            {
                return new ErrorResult("Invalid ZipCode format.");
            }

            return new SuccessResult("Address format is valid.");
        }
    }
}
