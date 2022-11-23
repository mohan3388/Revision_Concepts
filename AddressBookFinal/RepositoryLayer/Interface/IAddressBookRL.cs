using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IAddressBookRL
    {
        public AddressBookModel CreateAddressBook(AddressBookModel model);
        public List<GetAddressBookModel> GetAddressBook();
        public AddressBookModel UpdateaddressBook(long Id, AddressBookModel model);
        public bool DeleteAddressBook(long Id);
    }
}
