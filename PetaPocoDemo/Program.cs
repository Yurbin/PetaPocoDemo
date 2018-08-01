using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PetaPocoDemo.Entity;

namespace PetaPocoDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("测试vs提交");

            DbContext db = new DbContext();

            //新增
            //var model = new T_Test { UserName = "Tony2", Pwd = "123456", BirthDate = DateTime.Now, InUse = false };
            //db.Save(model);
            //Console.WriteLine("写入成功");

            //获取数据
            var info = db.SingleOrDefault<T_Test>(1);
            Console.WriteLine(info.UserName);

            //更新数据
            //方式1
            db.Update<T_Test>("SET UserName = 'KangKang' WHERE ID = @0", 1);
            //方式2
            var model2 = new T_Test
            {
                ID = 1,
                UserName = "Tony",
                Pwd = "123456",
                BirthDate = DateTime.Now,
                InUse = false
            };
            var updateColumns = new List<string>() {"UserName", "BirthDate", "InUse" };
            db.Update(model2, updateColumns);

            //删除
            db.Delete<T_Test>(4);

            Console.ReadKey();
        }
    }
}
