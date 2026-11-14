using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SOLID.Model
{
    internal class Compra
    {
        public int Id {  get; private set; }
        public DateTime Data { get; private set; }
        private readonly List<Item> Itens;
        public decimal Total { get; private set; }

        public Compra(int id)
        {
            Itens = new List<Item>();
            Id = id;
            Data = DateTime.Now;
            Total = 0;
        }

        public void Adicionar(Item item)
        {
            Itens.Add(item);
        }

        public Item BuscarPorId(int id)
        {
            return Itens.FirstOrDefault(i => i.Id == id);
        }

        public List<Item> ListarTodos()
        {
            return Itens.ToList();
        }

        public void Remover(Item item)
        {
            Itens.Remove(item);
        }

        public void Remover(int id)
        {
            Item item = BuscarPorId(id);

            if (item == null)
            {
                throw new InvalidOperationException($"Nenhum item com o id {id} foi encontrado");
            }

            Remover(item);
        }

        public decimal CalcularTotal()
        {
            decimal total = 0;

            foreach(Item item in Itens)
            {
                total += item.Subtotal;
            }

            this.Total = total;

            return total;
        }

        public void AtualizarId(int id)
        {
            this.Id = id;
        }
    }
}
