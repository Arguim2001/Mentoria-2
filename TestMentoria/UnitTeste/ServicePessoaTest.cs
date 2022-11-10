using Mentoria.Repository.Interface;
using Mentoria.Service;
using Moq;
using Xunit;

namespace MentoriaTest.UnitTests
{
    public class ServicePessoaTest
    {
        private ServicePessoa _servicePessoa;
        private readonly Mock<IPessoaRepository> _pessoaRepository = new();

        [Fact]

        public void Test ()
        {
            string a = "argu";
            Assert.Contains(a, "argu");
        }
    }
}