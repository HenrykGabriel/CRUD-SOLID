using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SOLID.Model
{
    public class Produto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }

        public Produto(int id, string nome, string descricao, decimal preco)
        {
            Atualizar(nome, descricao, preco);
        }

        public void Atualizar(string nome, string descricao, decimal preco)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentNullException("O nome deve ser preenchido.");
            }

            if (preco <= 0)
            {
                throw new ArgumentException("O preço deve ser maior que zero, safado!");
            }
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
        }

        public void Atualizar_id(int id)
        {
            if(this.Id == 0)
            {
                this.Id = id;
            }
        }
    }
}
