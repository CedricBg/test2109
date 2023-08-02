using DataAccess.DataAccess;
using DataAccess.Models.Rondes;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;


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
        /// On récupere toutes les pastilles pour une ronde précise
        /// </summary>
        /// <param name="round"></param>
        /// <returns></returns>
        public List<RfidPatrol> GetRfidRounds(Rounds round)
        {
            try
            {
                List<RfidRound> rounds = _context.RfidRound.Where(e => e.RoundId == round.RoundsId).ToList();

                List<RfidPatrol> rfids = _context.RfidPatrol
                    .Where(e=>rounds.Select(e=>e.RfidId).Contains(e.PatrolId))
                    .ToList();

                foreach (var rfid in rfids)
                {
                    var matchingRound = rounds.FirstOrDefault(roun => roun.RfidId == rfid.PatrolId);
                    if (matchingRound != null)
                    {
                        rfid.Position = matchingRound.Position;
                    }
                }
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

        /// <summary>
        /// Modification des pastilles pour une ronde des pastilles 
        /// </summary>
        /// <param name="putRfid"></param>
        /// <returns></returns>
        public List<RfidPatrol> PutRound(PutRfidRounds putRfid)
        {
            try
            {
                List<RfidRound> rfidRounds2 = putRfid.ListRfid.Select(e => new RfidRound
                {
                    RfidId = e.PatrolId,
                    Position = e.Position,
                    RoundId = putRfid.IdRound
                }).ToList();
                var list = _context.RfidRound.Where(e => e.RoundId == putRfid.IdRound);

                _context.RfidRound.RemoveRange(list);
                _context.RfidRound.AddRange(rfidRounds2);
                _context.SaveChanges();
                Rounds round = new Rounds {
                    Name = "",
                    RoundsId = putRfid.IdRound,
                    SiteId = putRfid.ListRfid[0].IdSite
                };
                
                return GetRfidRounds(round);
            }
            catch(Exception)
            {
                return new List<RfidPatrol>();
            }
        }

        /// <summary>
        /// On change le nom de la ronde
        /// On retorune la la liste des ronde pour le site
        /// </summary>
        public List<Rounds> UpdateRoundName(Rounds rounds)
        {
            try
            {
                Rounds roundTest = _context.Rounds.FirstOrDefault(e => e.Name == rounds.Name);
                if(roundTest != null)
                {
                    return _context.Rounds.Where(e => e.SiteId == rounds.SiteId).ToList();
                }
                Rounds round = _context.Rounds.FirstOrDefault(e => e.RoundsId == rounds.RoundsId);
                
                if (round != null)
                {
                    round.Name = round.Name;
                }
                _context.SaveChanges();
                return _context.Rounds.Where(e => e.SiteId == rounds.SiteId).ToList();
            }
            catch(Exception)
            {
                return _context.Rounds.Where(e => e.SiteId == rounds.SiteId).ToList();
            }
        }
    }
}
