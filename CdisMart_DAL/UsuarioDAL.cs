using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CdisMart_DAL;

namespace CdisMart_DAL
{
    public class UsuarioDAL
    {
        CdisMartEntities1 modelo;

        public UsuarioDAL()
        {
            modelo = new CdisMartEntities1();
        }

        public User consultarUsuario(string user, string password)
        {
            var usuario = (from mUsuarios in modelo.User
                           where (mUsuarios.UserName == user) && (mUsuarios.Password == password)
                           select mUsuarios).FirstOrDefault();
            return usuario;
        }
        public User consultarUsuarioNombre(string user)
        {
            var usuario = (from mUsuarios in modelo.User
                           where (mUsuarios.UserName == user)
                           select mUsuarios).FirstOrDefault();
            return usuario;
        }
        public void agregarUsuario(User usuario)
        {
            modelo.User.Add(usuario);
            modelo.SaveChanges();
        }

        public User obtenerNombre(int id)
        {
            var usuario = (from musuario in modelo.User
                           where musuario.UserId == id
                           select musuario).FirstOrDefault();

            return usuario;
        }
    }
}
