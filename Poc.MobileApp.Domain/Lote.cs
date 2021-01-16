using System.Collections.Generic;

namespace Poc.MobileApp.Domain
{
	public class Lote
	{
		public IEnumerable<Produto> Produtos { get; }
		public Pessoa Responsavel { get; }

		public Lote(IEnumerable<Produto> produtos, Pessoa responsavel)
		{
			Produtos = produtos;
			Responsavel = responsavel;
		}
	}
}
