using DataAccess.DataAccess;
using DataAccess.Models.Rondes;
using DataAccess.Repository;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class RondesServices : IRondesServices
    {
        SecurityCompanyContext _context;

        public RondesServices(SecurityCompanyContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Enregistrement de pastilles rfid
        /// </summary>
        /// <param name="rfidPatrol"></param>
        /// <returns></returns>
        public Boolean AddRfid(List<RfidPatrol> rfidPatrol)
        {
            try
            {
                foreach (var rfid in rfidPatrol)
                {
                    _context.RfidPatrol.Add(rfid);
                }
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        /// <summary>
        /// Retourne une liste de pastille sur base de l'id du site
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<RfidPatrol> GetRfidPatrols(int id)
        {
            try
            {
                List<RfidPatrol> rfidPatrols = _context.RfidPatrol.Where(elt => elt.IdSite == id).ToList();
                return rfidPatrols;
            }
            catch (Exception)
            {
                return new List<RfidPatrol>();
            }
            
        }
    }
}
