using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Department
    {
        //atributos da classe
        public int Id { get; set; }
        public string Name { get; set; }
        //referencia de chave estrangeira muitos pra um
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        //construtor vazio
        public Department()
        {

        }
        //construtor com argumentos
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }
        //metodo que adiciona os vendedores a lista de vendedores do departamento
        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        //metodo que soma o total de vendas do departamento
        public double TotalSales(DateTime initial, DateTime final)
        {
            //metodo soma o total de vendas do vendedor que se enquadra entre as datas solicitadas 
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }



    }
}
