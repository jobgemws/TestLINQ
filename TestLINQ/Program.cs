using System;
using System.Collections.Generic;
using System.Linq;

namespace TestLINQ
{
    class Program
    {
        class Para
        {
            public int Key1, Key2;
            public string Data;
        }

        static void Main(string[] args)
        {
            using (UserContext db = new UserContext())
            {
                var dblog = new List<string>();
                db.Database.Log = dblog.Add;

                //var query = from e1 in db.Customer
                //            from e2 in db.Ref
                //            where (e1.Ref_ID == e2.ID)
                //                 || (e1.Ref_ID2 == e2.ID2)
                //            select new { Data1 = e1.Name, Data2 = e2.Name };

                //var query = (from e1 in db.Customer
                //            join e2 in db.Ref
                //            on e1.Ref_ID equals e2.ID
                //            select new { Data1 = e1.Name, Data2 = e2.Name }).Union(from e1 in db.Customer
                //                                                                    join e2 in db.Ref
                //                                                                    on e1.Ref_ID2 equals e2.ID2
                //                                                                    select new { Data1 = e1.Name, Data2 = e2.Name });

                //var query = from e1 in db.Customer
                //            join e2 in db.Ref
                //            on e1.Ref_ID equals e2.ID
                //            //on new { e1.Ref_ID, e1.Ref_ID2 } equals new { e2.ID, e2.ID2 }
                //            select new { Data1 = e1.Name, Data2 = e2.Name };

                Para[] seq1 = new[] { new Para { Key1 = 1, Key2 = 2, Data = "777" }, new Para { Key1 = 2, Key2 = 3, Data = "888" }, new Para { Key1 = 3, Key2 = 4, Data = "999" } };
                Para[] seq2 = new[] { new Para { Key1 = 1, Key2 = 2, Data = "777" }, new Para { Key1 = 2, Key2 = 3, Data = "888" }, new Para { Key1 = 3, Key2 = 5, Data = "999" } };

                var query = from e1 in seq1
                            from e2 in seq2
                            where (e1.Key1==e2.Key1)
                               && (e1.Key2==e2.Key2)
                            select new { Data1 = e1.Data, Data2 = e2.Data };

                //var query = from e1 in seq1.AsEnumerable()
                //            join e2 in db.Ref.AsEnumerable()
                //            on e1.Ref_ID equals e2.ID
                //            on new { e1.Key1, e1.Key2 } equals new { e2.ID, e2.ID2 }
                //            select new { Data1 = e1.Name, Data2 = e2.Name };

                var result = query.Take(1000).ToList();

                Console.WriteLine(dblog[1]);

                Console.ReadKey();
            }
        }
    }
}
