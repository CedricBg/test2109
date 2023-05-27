using AutoMapper;
using AutoMapper.Internal;
using DataAccess.DataAccess;
using DataAccess.Models;
using DataAccess.Models.Customer;
using DataAccess.Models.Employees;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using SendFoto = DataAccess.Models.Employees.SendFoto;

namespace DataAccess.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly SecurityCompanyContext _db;

        private readonly ICountryServices _country;

        private readonly IMapper _Mapper;

        public EmployeeServices(SecurityCompanyContext context, IMapper mapper, ICountryServices country)
        {
            _db = context;
            _Mapper = mapper;
            _country = country;
        }

        public Boolean AddEmployee(DetailedEmployee employee)
        {
            if (_db.DetailedEmployees is not null)
            {
                Role role = _db.Roles.FirstOrDefault(c =>c.roleId == employee.Role.roleId);
                Language language = _db.Languages.FirstOrDefault(c => c.Id == employee.Language.Id);

                _db.DetailedEmployees.Add(new DetailedEmployee
                {
                    firstName = employee.firstName,
                    SurName = employee.SurName,
                    CreationDate = DateTime.UtcNow,
                    BirthDate = employee.BirthDate,
                    Vehicle = employee.Vehicle,
                    SecurityCard = employee.SecurityCard,
                    EmployeeCardNumber = employee.EmployeeCardNumber,
                    RegistreNational = employee.RegistreNational,
                    Role = role,
                    Phone = employee.Phone,
                    Email = employee.Email,
                    Address = employee.Address,
                    IsDeleted = false,
                    Language = language,
                });
                try
                {
                    _db.SaveChanges();

                    return true;
                }
                catch(Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
           
        }

        public DetailedEmployee UpdateEmployee(DetailedEmployee employee)
        {
            if (_db.DetailedEmployees.First().Id != null)
            {
                Role role =  _db.Roles.FirstOrDefault(c => c.roleId == employee.Role.roleId);
                Language language =  _db.Languages.FirstOrDefault(c => c.Id == employee.Language.Id);
                DetailedEmployee dBemployee =  _db.DetailedEmployees.Where(e=> e.Id == employee.Id)
                    .Include("Email")
                    .Include("Phone")
                    .Include("Address")
                    .Include("Role")
                    .Include("Language")
                    .FirstOrDefault();

                var emailIdsToRemove = dBemployee.Email
                .Where(email => !employee.Email.Any(e => e.EmailId == email.EmailId))
                .Select(email => email.EmailId)
                .ToList();

                foreach (var emailId in emailIdsToRemove)
                {
                    var emailToRemove = _db.EmailAddresses.Find(emailId);
                    _db.EmailAddresses.Remove(emailToRemove);
                }
                

                var phonesIdsToRemove = dBemployee.Phone
                .Where(phone => !employee.Phone.Any(e => e.PhoneId == phone.PhoneId))
                .Select(phone => phone.PhoneId)
                .ToList();


                foreach(var phoneId in phonesIdsToRemove)
                {
                    var phoneToRemove = _db.Phones.Find(phoneId);
                    _db.Phones.Remove(phoneToRemove);
                }



                foreach (var phone in employee.Phone)
                {
                    var existingPhone = _db.Phones.Find(phone.PhoneId);
                    if (existingPhone != null)
                    {
                        existingPhone.Number = phone.Number; 
                    }
                    if(phone.PhoneId == null)
                    {
                        dBemployee.Phone.Add(phone);    
                    }
                }

                foreach(var email in employee.Email)
                {
                    var existingEmail = _db.EmailAddresses.Find(email.EmailId);
                    if(existingEmail != null)
                    {
                        existingEmail.EmailAddress = email.EmailAddress;
                    }
                    if(email.EmailId == null)
                    {
                        dBemployee.Email.Add(email);
                    }
                }

                var existingAdrress = _db.Address.Find(employee.Address.AddressId);
                    if(existingAdrress != null)
                    {
                        existingAdrress.SreetAddress = employee.Address.SreetAddress;
                        existingAdrress.StateId = employee.Address.StateId;
                        existingAdrress.State = employee.Address.State;
                        existingAdrress.City = employee.Address.City;
                        existingAdrress.ZipCode = employee.Address.ZipCode;
                    }
                        

                if (dBemployee.Role.roleId != employee.Role.roleId && dBemployee.Id != 1) dBemployee.Role = role;
                if (dBemployee.Language.Id != employee.Language.Id) dBemployee.Language = language;


                if(dBemployee.firstName != employee.firstName) dBemployee.firstName = employee.firstName;
                if(dBemployee.SurName != employee.SurName) dBemployee.SurName = employee.SurName;
                if (dBemployee.EmployeeCardNumber != employee.EmployeeCardNumber) dBemployee.EmployeeCardNumber = employee.EmployeeCardNumber;
                if (dBemployee.SecurityCard != employee.SecurityCard) dBemployee.SecurityCard = employee.SecurityCard;
                if (dBemployee.BirthDate != employee.BirthDate) dBemployee.BirthDate = employee.BirthDate;


                _db.SaveChanges();

                return dBemployee;
            }
            else 
            {
                return null; 
            }
        }

        public  List<Employee> GetAll()
        {
                if (_db.employees is not null)
                { 
                    List<Employee> requete =  _db.DetailedEmployees
                    .Where(e=>e.IsDeleted == false)
                    .Include(e=>e.Role)
                    .Include(e=>e.Language)
                        .Select((employee) => new Employee
                        {
                            Id = employee.Id,
                            firstName = employee.firstName,
                            SurName = employee.SurName,
                            Role = employee.Role,
                            Language = employee.Language
                        })
                        .ToList();

                    return requete;
                }
                    else
                {
                    throw new Exception();
                }  
        }

        public DetailedEmployee GetOne(int id)
        {  
            if(_db.DetailedEmployees is not null)
            { 
                try
                {
                    DetailedEmployee person =  _db.DetailedEmployees
                                        .Where(e => e.Id == id)
                                        .Include(e => e.Phone)
                                        .Include(e => e.Email)
                                        .Include(e => e.Address)
                                        .Include(e =>e.Role)
                                        .Include(e =>e.Language)
                                        .First();
                    Countrys country = Country(person.Address.StateId);
                    person.Address.State = country.Country;
                    return person;
                }
                catch(Exception) 
                {
                    return new DetailedEmployee();
                }  
            }
            else
            {
                return new DetailedEmployee();
            }
        }

        public Countrys Country(int? id)
        {
            try
            {
                Countrys countrys = _db.Countrys
                    .Where(e => e.Id == id).First();
                return countrys;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public bool Deactive(int id)
        {
            if(_db.DetailedEmployees.First().Id != null && id != 1)
            {
                DetailedEmployee detailedEmployee =  _db.DetailedEmployees.Where(e => e.Id == id).FirstOrDefault();
                if(detailedEmployee.IsDeleted == true)
                {

                    return false;
                }
                detailedEmployee.IsDeleted = true;
 
                _db.SaveChanges();
                return true;
            }
            else 
            {
                return false;
            }

        }

        public async Task<string> UploadFile(SendFoto file)
        {
            if (file == null || file.Foto.Length == 0)
            {
                return "fichier non valide";
            }
            string folderPath = CreateFolder("..\\images\\" + file.IdEmployee);

            var filePath = Path.Combine(folderPath, file.Foto.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.Foto.CopyToAsync(stream);
            }
            FotoDb fotodb = new FotoDb
            {
                NameFoto = folderPath+"\\"+ file.Foto.FileName,
                idEmployee = file.IdEmployee,
            };
            Boolean response =  SaveInformationFoto(fotodb);
            if (response == true)
                return "Fichier téléchargé avec succès!";
            else
                return "Erreur lors de l'enregistrement veuillez changer le nom du fichier";
        }

        private bool SaveInformationFoto(FotoDb fotoDb)
        {
            if (fotoDb == null)
            {
                return false;
            }
            FotoDb fotoDb1 = _db.Foto.FirstOrDefault(e =>e.idEmployee == fotoDb.idEmployee);
            if (fotoDb1 != null)
                fotoDb1.NameFoto = fotoDb.NameFoto;
            else
            {
                FotoDb fotoDb3 = new FotoDb
                {
                    NameFoto = fotoDb.NameFoto,
                    idEmployee = fotoDb.idEmployee
                    
                };
                _db.Foto.Add(fotoDb3);
            }
            _db.SaveChanges();
            return true;
        }

        private string CreateFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            return folderPath;
        }

        public async Task<byte[]> LoadFoto(int id)
        {
            string GetFototPath = GetFotoPath(id);
            if (GetFototPath == null)
                return null;

            byte[] photoBytes;
            using (FileStream SourceStream = File.Open(GetFototPath, FileMode.Open))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    await SourceStream.CopyToAsync(memoryStream);
                    photoBytes =  memoryStream.ToArray();
                }
            }
            return photoBytes;

        }

        private string GetFotoPath(int id)
        {
            string filePath = _db.Foto
                .Where(e => e.idEmployee == id).Select(c => c.NameFoto).FirstOrDefault();
            if (filePath == null)
            {
                filePath = "..\\images\\default\\avatar.png";
            }
            return filePath;
        }
    }
}
