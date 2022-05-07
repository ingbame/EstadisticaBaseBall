using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIAWF1._1.Models
{
    public class Usuario
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Usuario> GetUsuarios()
        {
            var list = new List<Usuario>();
            list.Add(new Usuario { UserName = "Admin", Password = "pass123" });
            list.Add(new Usuario { UserName = "Profe", Password = "pass123" });
            return list;
        }
    }    
}
