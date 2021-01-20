using System;

namespace Poc.MobileApp.Domain
{
	public class Sincronizacao
	{
		public int Id { get; set; }
		public DateTime DataExecucao { get; set; }
		public bool Sucesso { get; set; }
	}
}
