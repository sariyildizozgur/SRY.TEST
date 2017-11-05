using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRY.TEST.BUSSINESS.GenericRepository;
using SRY.TEST.BUSSINESS.Company;
using SRY.TEST.DATA;

namespace SRY.TEST.BUSSINESS
{
    public class UserEntity: NBase<User>
    {
        private User _nesne
        {
            get { return base.Entity; }
            set { base.Entity = value; }
        }

        public UserEntity()
        {
            base.Entity = new User();
        }


        public string Id
        {
            get { return _nesne.Id; }
            set { _nesne.Id = value; }
        }

        public string Name
        {
            get { return _nesne.Name; }
            set { _nesne.Name = value; }
        }

        public string TcNo
        {
            get { return _nesne.TcNo; }
            set { _nesne.TcNo = value; }
        }

        public string TcUserNameNo
        {
            get { return _nesne.UserName; }
            set { _nesne.UserName = value; }
        }

        

    }
}
