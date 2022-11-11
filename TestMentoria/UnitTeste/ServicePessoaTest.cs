using Mentoria.Model;
using Mentoria.Repository.Interface;
using Mentoria.Service;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace MentoriaTest.UnitTests
{
    public class ServicePessoaTest
    {
        private ServicePessoa _servicePessoa;
        private readonly Mock<IPessoaRepository> _pessoaRepository = new();

        public ServicePessoaTest() => _servicePessoa = new ServicePessoa(_pessoaRepository.Object);

        //>>>>>>>>>>>>>>>>>>>>>>>>>>TEST GET<<<<<<<<<<<<<<<<<<<<<<<<<\\


        [Theory]
        [InlineData("argus")]

        public async Task Get_Pessoa_By_Name_Return_Pessoa(string nome)
        {

            // Arrange
            Pessoa pessoa = new();
            pessoa.Nome = nome;
            pessoa.Id = 01;

            _pessoaRepository.Setup(x => x.GetPessoa(nome)).ReturnsAsync(pessoa);

            // Act
            var result = await _servicePessoa.GetPessoa(nome);

            // Assert
            Assert.Equal(pessoa, result);
            int a = 0;

        }
        [Theory]

        [InlineData("argus")]

        public async Task Get_Pessoa_Return_Null(string nome)
        {

            // Arrange
            Pessoa pessoa = new();
            pessoa.Nome = "Calleo";
            pessoa.Id = 01;

            _pessoaRepository.Setup(x => x.GetPessoa(nome)).ReturnsAsync(pessoa);

            // Act
            var result = await _servicePessoa.GetPessoa(nome);

            // Assert
            Assert.NotEqual(nome, result.Nome);


        }

        [Theory]
        [InlineData("Argu", 01, 12.000, "BackEnd")]


        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>TEST POST<<<<<<<<<<<<<<<<<<<<<<<<<<<\\

        public async Task Post_Pessoa_Return_Bool(string nome, int id, double salario, string departamento)
        {
            //Arrange
            Pessoa pessoa = new();
            pessoa.Nome = nome;
            pessoa.Id = id;
            pessoa.Salario = salario;
            pessoa.Departamento = departamento;

            _pessoaRepository.Setup(x => x.AddPessoa(pessoa)).ReturnsAsync(true);

            //Act

            var result = await _servicePessoa.AddPessoa(pessoa);

            //Assert

            Assert.True(result);


        }
        [Theory]
        [InlineData("Argu", 01, 12.000, "BackEnd")]

        public async Task Post_Pessoa_Return_ERROR(string nome, int id, double salario, string departamento)
        {
            //Arrange
            Pessoa pessoa = new();
            pessoa.Nome = nome;
            pessoa.Id = id;
            pessoa.Salario = salario;
            pessoa.Departamento = departamento;

            _pessoaRepository.Setup(x => x.AddPessoa(pessoa)).ReturnsAsync(false);

            //Act

            var result = await _servicePessoa.AddPessoa(pessoa);

            //Assert

            Assert.False(result);


        }
        [Theory]
        [InlineData("Argu", 01, 12.000, "BackEnd")]
        public async Task Post_Pessoa_Return_ERROR2(string nome, int id, double salario, string departamento)
        {
            //Arrange
            Pessoa pessoa = new();
            pessoa.Nome = nome;
            pessoa.Id = id;
            pessoa.Salario = salario;
            pessoa.Departamento = departamento;


            _pessoaRepository.Setup(X => X.GetPessoa(pessoa.Nome)).ReturnsAsync(pessoa);

            //Act

            var result = await _servicePessoa.AddPessoa(pessoa);

            //Assert

            Assert.False(result);


        }

        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> TEST PUT <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\\

        [Theory]
        [InlineData("Argu", 01, 12.000, "BackEnd")]

        public async Task Put_Pessoa_Return_True(string nome, int id, double salario, string departamento)
        {

            //Arrange
            Pessoa pessoa = new();
            pessoa.Nome = nome;
            pessoa.Id = id;
            pessoa.Salario = salario;
            pessoa.Departamento = departamento;

            _pessoaRepository.Setup(x => x.PutPessoa(pessoa)).ReturnsAsync(true);

            //Act
            var result = await _servicePessoa.PutPessoa(pessoa);

            //Assert

            Assert.True(result);
        }


        [Theory]
        [InlineData("Argu", 01, 12.000, "BackEnd")]

        public async Task Put_Pessoa_Return_False(string nome, int id, double salario, string departamento)
        {

            //Arrange
            Pessoa pessoa = new();
            pessoa.Nome = nome;
            pessoa.Id = id;
            pessoa.Salario = salario;
            pessoa.Departamento = departamento;

            _pessoaRepository.Setup(x => x.PutPessoa(pessoa)).ReturnsAsync(false);

            //Act
            var result = await _servicePessoa.PutPessoa(pessoa);

            //Assert

            Assert.False(result);
        }
        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> TEST DELETE <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\\

        [Theory]
        [InlineData(01)]

        public async Task Delete_Pessoa_Return_True(int id)
        {

            //Arrange
            Pessoa pessoa = new();

            pessoa.Id = id;



            _pessoaRepository.Setup(x => x.DeletePessoa(id)).ReturnsAsync(true);

            //Act
            var result = await _servicePessoa.DeletePessoa(id);

            //Assert

            Assert.True(result);
        }
        [Theory]
        [InlineData(01)]

        public async Task Delete_Pessoa_Return_False(int id)
        {

            //Arrange
            Pessoa pessoa = new();

            pessoa.Id = id;



            _pessoaRepository.Setup(x => x.DeletePessoa(id)).ReturnsAsync(false);

            //Act
            var result = await _servicePessoa.DeletePessoa(id);

            //Assert

            Assert.False(result);
        }





    }

}

