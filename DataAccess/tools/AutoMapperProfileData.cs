using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DATA  =  DataAccess.Models.Employees;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.tools
{
    public class AutoMapperProfileData : Profile 
    {
        public AutoMapperProfileData() 
        {
            
        }
    }
}
