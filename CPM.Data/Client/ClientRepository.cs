using CPM.Data.Entities;
using CpmLib.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Data.Client
{
    public interface IClientRepository : IRepositoryBase
    {
        ClientDM GetRecordById(int id);
        ClientDM GetUserByUsername(string Username);
        bool UsernameExists(string username);
        void InsertRecord(ClientEntity user);
        void UpdateRecord(ClientEntity user);
        void DeleteRecord(ClientEntity user);

    }

    public class ClientRepository : IClientRepository
    {
        private readonly IClientContext _context;

        public ClientRepository()
        {
            _context = new ClientContext();
        }

        public ClientRepository(IClientContext context)
        {
            _context = context; 
        }

        public void DeleteRecord(ClientEntity user)
        {
            throw new NotImplementedException();
        }

        public ClientDM GetRecordById(int id)
        {
            throw new NotImplementedException();
        }

        public ClientDM GetUserByUsername(string Username)
        {
            throw new NotImplementedException();
        }

        public void InsertRecord(ClientEntity user)
        {
            throw new NotImplementedException();
        }

        public void UpdateRecord(ClientEntity user)
        {
            throw new NotImplementedException();
        }

        public bool UsernameExists(string username)
        {
            throw new NotImplementedException();
        }
    }
}
