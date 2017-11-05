using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRY.TEST.BUSSINESS;
using SRY.TEST.BUSSINESS.UnitOfWork;
using SRY.TEST.DATA;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                //UserEntity user = new UserEntity();

                //User tt = new User();

                //tt.Id = "6000";
                //tt.Name = "Batuhan";
                //tt.TcNo = "46546546546";
                //tt.SurName = "Göktaş";
                //tt.UserName = "bgokt";
                //user.Insert(tt);

                //user.SaveChanges();

                var tt = new UserEntity();
                tt.GetById("1");

                var kk = tt.Name;

                var zz = tt.TcNo;



                //using (var unit = new UnitOfWork())
                //{
                //    User tt = new User();

                //    tt.Id = "1234";
                //    tt.Name = "Mirac";
                //    tt.TcNo = "324234";
                //    tt.SurName = "Sarıyıldız";
                //    tt.UserName = "mirax";
                //    unit.GetRepository<User>().Insert(tt);

                //    Job kk = new Job();
                //    kk.Id = "1234";
                //    kk.Name = "Polis";
                //    kk.Code = "pls";

                //    unit.GetRepository<Job>().Insert(kk);

                //    unit.SaveChanges();
                //}



            }
            catch (Exception ex)
            {
               
            }

        }
    }
}
