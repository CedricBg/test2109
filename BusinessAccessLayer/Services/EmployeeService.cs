using System;
using DataAccess.Services;
using BusinessAccessLayer.Tools.Employee;
using BusinessAccessLayer.IRepositories;
using DataAccess.Repository;
using BusinessAccessLayer.Models.Employee;
using AutoMapper;
using DATA = DataAccess.Models.Employees;
using System.Text.Json;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace BusinessAccessLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeServices _employeeServices;

        private readonly IMapper _Mapper;

        public EmployeeService(IEmployeeServices employeeServices, IMapper mapper)
        {
            _employeeServices = employeeServices;
            _Mapper = mapper;
        }

        /// <summary>
        /// envoi la phoot de profil de l'employée
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<string> UploadFile(SendFoto file)
        {

            var detail = _Mapper.Map<DATA.SendFoto>(file);
            string task = await _employeeServices.UploadFile(detail);
            return task;
        }

        /// <summary>
        /// Ajout d'un employee à la db
        /// </summary>
        /// <param name="form"></param>
        /// <returns>ture are False</returns>
        public Boolean AddEmployee(DetailedEmployee form)
        {
            try
            {
                var detail = _Mapper.Map<DATA.DetailedEmployee>(form);
                _employeeServices.AddEmployee(detail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// liste de tout les employée
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAll() 
        {
            return  _employeeServices.GetAll().Select(dr => _Mapper.Map<Employee>(dr)).ToList();
        }

        /// <summary>
        /// retourne un employée par sont id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DetailedEmployee GetOne(int id) 
        {
            DetailedEmployee employee = _Mapper.Map<DetailedEmployee>(_employeeServices.GetOne(id));
            return employee;
        }

        /// <summary>
        /// On simule la suppression d'un employée il sera plus visible pour les opérations
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Deactive(int id)
        {
            return _employeeServices.Deactive(id);
        }
 
        /// <summary>
        /// mise à jour d'un employée
        /// </summary>
        /// <param name="detailedEmployee"></param>
        /// <returns></returns>
        public DetailedEmployee UpdateEmployee(DetailedEmployee detailedEmployee)
        {
            var detail = _Mapper.Map<DATA.DetailedEmployee>(detailedEmployee);
            DetailedEmployee employee = _Mapper.Map<DetailedEmployee>(_employeeServices.UpdateEmployee(detail));
            return employee;
        }

        /// <summary>
        /// Téléchargement de la photo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<byte[]> LoadFoto(int id)
        {
            byte[] reponse = await _employeeServices.LoadFoto(id);
            return reponse;
        }
    }
}
