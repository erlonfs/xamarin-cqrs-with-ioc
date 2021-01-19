using FluentAssertions;
using Poc.MobileApp.Domain.Commands;
using System;
using Xunit;

namespace Poc.MobileApp.Domain.Test.Commands.Pessoa
{
	public class CriarPessoaCommandTest
	{
		private readonly Guid _entityId = Guid.NewGuid();
		private readonly string _nome = "Joao";
		private readonly string _cpf = "02536745698";

		public CriarPessoaCommandTest()
		{

		}


		[Fact]
		public void Quando_criar__com_todos_os_dados_corretamente__devera_constar_respectivamente()
		{
			var command = new CriarPessoaCommand(_entityId, _nome, _cpf);

			command.EntityId.Should().Be(_entityId);
			command.Nome.Should().Be(_nome);
			command.Cpf.Should().Be(_cpf);
		}

	}
}
