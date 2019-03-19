using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Cliente
    {
        private long id;
        private string name;
        private string registerDate;
        private int estado;
        


        public long Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string RegisterDate { get => registerDate; set => registerDate = value; }
        public int Estado { get => estado; set => estado = value; }

        public Cliente() { }

        public Cliente(long idcliente)
        {
            this.id = idcliente;
        }

        public Cliente(long id, string name, string registerDate)
        {
            this.id = id;
            this.name = name;
            this.registerDate = registerDate;
        }

    }
}
