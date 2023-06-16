using DataAccess.DataAccess;
using DataAccess.Migrations;
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

        /// <summary>
        /// Modification d'une pastille Rfid de ronde par son id
        /// </summary>
        /// <param name="rfid"></param>
        /// <returns></returns>
        public List<RfidPatrol> UpdateRfid(RfidPatrol rfid)
        {
            try
            {
                RfidPatrol rfidPatrol = _context.RfidPatrol.FirstOrDefault(elt => elt.PatrolId == rfid.PatrolId);

                rfidPatrol.Location = rfid.Location;
                rfidPatrol.RfidNr = rfid.RfidNr;
                _context.SaveChanges();
                return GetRfidPatrols(rfidPatrol.IdSite);
            }
            catch(Exception)
            {
                return new List<RfidPatrol>();
            } 
        }

        /// <summary>
        /// Supprime une pastrille Définitivement sur base de l'id du site et de la pastille
        /// </summary>
        /// <param name="rfid"></param>
        /// <returns></returns>
        public List<RfidPatrol> DeleteRfid(RfidPatrol rfid)
        {
            try
            {
                RfidPatrol rfid1 = _context.RfidPatrol.FirstOrDefault(e => e.RfidNr == rfid.RfidNr && e.IdSite == rfid.IdSite);
                _context.Remove(rfid1);
                _context.SaveChanges();
                return GetRfidPatrols(rfid.IdSite);
            }
            catch(Exception)
            {
                return new List<RfidPatrol>();    
            }
            
        }

        /// <summary>
        /// On controle si le nom de la ronde existe déjà avant d'en créé une nouvelle
        /// si elle existe on renvoi la liste des pastille de la ronde
        /// </summary>
        /// <param name="round"></param>
        /// <returns>List<RfidRound></returns>
        public Boolean CheckRoundexist(Rounds round)
        {
            try
            {
                Rounds rounds = _context.Rounds.FirstOrDefault(e => e.Name == round.Name && e.SiteId == round.SiteId);
                if (rounds != null)
                {
                    return true;
                }
                else
                {
                    return CreateRound(round);
                    
                }      
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Onrécupere toutes les pastilles par ronde
        /// </summary>
        /// <param name="round"></param>
        /// <returns></returns>
        public List<RfidPatrol> GetRfidRounds(Rounds round)
        {
            try
            {
                List<RfidRound> rounds = _context.RfidRound.Where(e => e.RoundId == round.RoundsId).ToList();

                List<RfidPatrol> rfids = _context.RfidPatrol.Where(e=>rounds.Select(e=>e.RfidId).Contains(e.PatrolId))
                    .ToList();
                rfids = rfids.OrderBy(r=> rounds.Find(e=>e.RfidId == r.PatrolId).Position).ToList();

                return rfids;
            }
            catch(Exception)
            {
                return new List<RfidPatrol>();
            }
 
        }

        private Boolean CreateRound(Rounds round)
        {
            _context.Rounds.Add(round);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Retourne une liste de ronde sur base del'id du site
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of rounds</returns>
        public List<Rounds> GetRounds(int id)
        {
            try
            {
                List<Rounds> rounds = _context.Rounds.Where(e => e.SiteId == id).ToList();
                return rounds;
            }
            catch(Exception)
            {
                return new List<Rounds>();
            }   
        }
    }
}
