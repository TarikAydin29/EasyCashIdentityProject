using EasyCashIdentityProject.BusinessLayer.Abstract;
using EasyCashIdentityProject.DataAccessLayer.Abstract;
using EasyCashIdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.BusinessLayer.Concrete
{
    public class CustomerAccountManager : ICustomerAccountService
    {
        private readonly ICustomerAccountDal customerAccountDal;

        public CustomerAccountManager(ICustomerAccountDal customerAccountDal)
        {
            this.customerAccountDal = customerAccountDal;
        }
        public void TDelete(CustomerAccount t)
        {
            customerAccountDal.Delete(t);
        }

        public CustomerAccount TGetByID(int id)
        {
            return customerAccountDal.GetByID(id);
        }

        public List<CustomerAccount> TGetList()
        {
            return customerAccountDal.GetList();
        }

        public void TInsert(CustomerAccount t)
        {
            customerAccountDal.Insert(t);
        }

        public void TUpdate(CustomerAccount t)
        {
            customerAccountDal.Update(t);
        }
    }
}
