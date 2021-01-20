using FluentAssertions;
using Moq;
using Poc.MobileApp.Domain.Commands;
using Poc.MobileApp.Domain.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Poc.MobileApp.Domain.Test.Commands.Pessoa
{
	public class Quando_criar_pessoa
	{
		private readonly Guid _entityId = Guid.NewGuid();
		private readonly string _nome = "Joao";
		private readonly string _cpf = "02536745698";

		private CriarPessoaCommand _command { get; set; }
		private CriarPessoaCommandHandler _handler { get; set; }

		private Mock<IPessoaRepository> _mockPessoaRepository = new Mock<IPessoaRepository>();

		private Domain.Pessoa _pessoaCallBack = null;

		private async Task Create()
		{
			_mockPessoaRepository.Setup(x => x.AddAsync(It.IsAny<Domain.Pessoa>()))
								.Callback((Domain.Pessoa pessoa) =>
								{
									_pessoaCallBack = pessoa;
								});

			_command = new CriarPessoaCommand(_entityId, _nome, _cpf);
			_handler = new CriarPessoaCommandHandler(_mockPessoaRepository.Object);

			await _handler.HandleAsync(_command);
		}

		[Fact]
		public async Task Deve_salvar()
		{
			await Create();

			_mockPessoaRepository.Verify(x => x.AddAsync(It.IsAny<Domain.Pessoa>()), Times.Once);

			_pessoaCallBack.Nome.Should().Be(_nome);
			_pessoaCallBack.Cpf.Should().Be(_cpf);
			_pessoaCallBack.EntityId.Should().Be(_entityId);

		}
	}
}
