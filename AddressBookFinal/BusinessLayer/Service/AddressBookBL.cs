using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class AddressBookBL:IAddressBookBL
    {
        public IAddressBookRL addressRL;
        public AddressBookBL(IAddressBookRL addressRL)
        {
            this.addressRL = addressRL;
        }

        public AddressBookModel CreateAddressBook(AddressBookModel model)
        {
            try
            {
                return addressRL.CreateAddressBook(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<GetAddressBookModel> GetAddressBook()
        {
            try
            {
                return addressRL.GetAddressBook();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
