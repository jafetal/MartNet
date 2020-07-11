using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CdisMart_DAL;
using System.Transactions;


namespace CdisMart_BLL
{
    public class UsuarioBLL
    {
        public User consultarUsuario(string user, string password)
        {
            UsuarioDAL usuario = new UsuarioDAL();
            return usuario.consultarUsuario(user, password);
        }

        public void agregarUsuario(User usuario)
        {
            UsuarioDAL usuarioDal = new UsuarioDAL();
            User user = new User();

            user = usuarioDal.consultarUsuarioNombre(usuario.UserName);

            if (user != null)
            {
                throw new Exception("El nombre de usuario ya está ocupado, intente con otro.");
            }
            else
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    usuarioDal.agregarUsuario(usuario);
                    ts.Complete();
                }
            }
        }

        public User obtenerNombre(int id)
        {
            UsuarioDAL usuarioDal = new UsuarioDAL();
            return usuarioDal.obtenerNombre(id);

        }
    }
}
