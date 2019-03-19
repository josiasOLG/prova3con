using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Neg
{
    public class ClienteNeg
    {
        private CustomersDao objClienteDao;

        public ClienteNeg()
        {
            objClienteDao = new CustomersDao();

        }

        public void create(Cliente objCliente)
        {
            bool verificacao = true;

            string nome = objCliente.Name;
            Cliente objCliente1 = new Cliente();
            verificacao = !objClienteDao.findCustomersPorNome(objCliente1);

            if (nome == null && !verificacao)
            {
                objCliente.Estado = 8;
                return;
            }
            else
            {
                nome = objCliente.Name.Trim();
                verificacao = nome.Length <= 30 && nome.Length > 0;
                if (nome == "3Con")
                {
                    objCliente.Estado = 2;
                    return;
                }

            }

            //se nao tem erro
            objCliente.Estado = 99;
            objClienteDao.create1(objCliente);
            return;
        }

        public void update(Cliente objCliente)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string codigo = objCliente.Id.ToString();
            long id = 0;
            if (codigo == null)
            {
                objCliente.Estado = 1;
                return;
            }
            else
            {
                try
                {
                    id = Convert.ToInt64(objCliente.Id);
                    verificacao = codigo.Length > 0 && codigo.Length < 999999; ;
                    if (!verificacao)
                    {
                        objCliente.Estado = 1;
                        return;
                    }
                }
                catch (Exception e)
                {
                    objCliente.Estado = 100;
                    return;
                }

            }
            //end validar codigo


            //begin validar nome retorna estado=2
            string nome = objCliente.Name;
            Cliente objCliente1 = new Cliente();
            verificacao = !objClienteDao.findCustomersPorNome(objCliente1);
            if (nome == null && !verificacao)
            {
                objCliente.Estado = 8;
                return;
            }
            else
            {
                nome = objCliente.Name.Trim();
                verificacao = nome.Length <= 30 && nome.Length > 0;
                if (!verificacao)
                {
                    objCliente.Estado = 100;
                    return;
                }

            }
            //end validar nome

            //se nao tem erro
            objCliente.Estado = 99;
            objClienteDao.update(objCliente);
            return;
        }


    }
}
