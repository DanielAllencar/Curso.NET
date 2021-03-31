using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SalesWebMvc.Models
{
    public class Seller
    {
        //atributos da classe com os get e set prontos 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        //referencia de chaves de ligação da tabela exemplo um pra um
        public Department Department { get; set; }
        //referencia de chaves de ligação da tabela exemplo de muitos pra um
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        //construtor vazio
        public Seller()
        {

        }
        //construtor com argumentos
        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        //metodo pra adicionar uma venda 
        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        } 

        //metodo para remover uma venda
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        //metodo de pesquisa que trara o total de vendas atraves de um determinado tempo 
        public double TotalSales(DateTime initial, DateTime final)
        {
            //esta linha usando expressão lambida pesquisa na lista pela data e soma os valores de todos os itens qe entrao na pesquisa e traz o total final
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }

    }
}
