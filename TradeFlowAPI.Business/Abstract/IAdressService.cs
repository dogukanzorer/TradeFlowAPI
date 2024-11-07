using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TradeFlowAPI.Entities.Concrete;
using TradeFlowAPI.Entities.DTOs;
using TradeFlowAPI.Entities.Enums;

namespace TradeFlowAPI.Business.Abstract
{
    public interface IAdressService
    {
        // Tüm adresleri getir
        IDataResult<List<Adress>> GetAll();

        // ID'ye göre adres getir
        IDataResult<Adress> GetById(Guid id);

        // Kullanıcı ID'sine göre adresleri getir
        IDataResult<List<Adress>> GetByUserId(Guid userId);

        // Şehir adına göre adresleri getir
        IDataResult<List<Adress>> GetByCity(string city);

        // Belirli bir eyalet adına göre adresleri getir
        IDataResult<List<Adress>> GetByState(string state);

        // Adres türüne göre adresleri getir
        IDataResult<List<Adress>> GetByAddressType(AddressType type);

        // Adres ekle
        IResult Add(AdressDetailDto addressDto);

        // Adresi güncelle
        IResult Update(Guid id, AdressDetailDto addressDto);

        // Adres sil
        IResult Delete(Guid id);

        // Belirli bir zip koduna göre adresleri getir
        IDataResult<List<Adress>> GetByZipCode(string zipCode);

        // Belirli bir tarihten sonra güncellenmiş adresleri getir
        IDataResult<List<Adress>> GetUpdatedAfter(DateTime date);

        // Verilen formatta adresi doğrula
        IResult ValidateAddressFormat(AdressDetailDto addressDto);

        // Adresleri güncellenme tarihine göre sırala
        IDataResult<List<Adress>> GetAllOrderedByUpdateDate();

        
    }
}
