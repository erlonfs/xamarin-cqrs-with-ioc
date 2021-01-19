using FluentAssertions;
using Moq;
using Poc.MobileApp.Domain.Commands;
using Poc.MobileApp.Domain.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Poc.MobileApp.Domain.Test.Commands.Pessoa
{
	public class Quando_criar_pessoa_para_cpf_ja_existente
	{
		private readonly Guid _entityId = Guid.NewGuid();
		private readonly string _nome = "Joao";
		private readonly string _cpf = "02536745698";

		private CriarPessoaCommand _command { get; set; }
		private CriarPessoaCommandHandler _handler { get; set; }

		private Mock<IPessoaRepository> _mockPessoaRepository = new Mock<IPessoaRepository>();


		private async Task Create()
		{
			_mockPessoaRepository.Setup(x => x.ObterPorCpfAsync(It.IsAny<string>()))
								.Returns(Task.FromResult(new Domain.Pessoa { }));

			_command = new CriarPessoaCommand(_entityId, _nome, _cpf);
			_handler = new CriarPessoaCommandHandler(_mockPessoaRepository.Object);

			await _handler.HandleAsync(_command);
		}

		[Fact]
		public async Task Deve_salvar()
		{
			try
			{
				await Create();
			}
			catch (Exception e)
			{
				e.Should().BeOfType<PessoaJaExistenteParaCpfException>();
			}
		}
	}
}
