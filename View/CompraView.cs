using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_SOLID.Model;

namespace Projeto_SOLID.View
{
    internal class CompraView : ICompraView
    {
        public void MostrarCompra(Compra compra)
        {
            Console.WriteLine($"\nId: {compra.Id} | Total: {compra.Total} | Data: {compra.Data}");
        }
    }
}
