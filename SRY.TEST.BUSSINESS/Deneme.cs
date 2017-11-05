using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRY.TEST.DATA;

namespace SRY.TEST.BUSSINESS
{
    public class Deneme
    {

        public string FirstTest()
        {
            try
            {
                using (TestContext context = new TestContext())
                {
                    context.Users.Add(new User
                    {
                        Id = "1",
                        Name = "Özgür",
                        SurName = "SARIYILDIZ",
                        TcNo = "18635046126",
                        UserName = "grendel"
                    });

                    context.SaveChanges();
                }

                return "Başarılı";
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
