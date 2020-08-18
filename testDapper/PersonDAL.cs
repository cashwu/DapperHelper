using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace testDapper
{
    class PersonDAL : BaseDAL
    {
        public PersonDAL()
        {
            ConnectionString = "Data Source=Test.db;";
        }
        
        public Task<List<Person>> Get()
        {
            return Execute((conn, trans) => conn.Query<Person>("select * from Persons").ToList());
        }
        
        public Task<bool> Insert()
        {
            return Execute((conn, trans) =>
            {
                var p = new Person { Id = 2, Name = "2Name" };
                var execnum = conn.Execute($"insert into Persons values (@Id, @Name)", p, trans);

                if (execnum == 0)
                {
                    return false;
                }

                var p2 = new Person { Id = 3, Name = "3Name" };
                var execnum2 = conn.Execute($"insert into Persons values (@Id, @Name)", p2, trans);

                if (execnum2 > 0)
                {
                    trans.Commit();
                }

                return execnum > 0;
            });
        }
    }
}