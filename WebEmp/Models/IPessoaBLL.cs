using System.Collections.Generic;

namespace WebEmp.Models
{
    public interface IPessoaBLL
    {
        List<Pessoa> GetPessoas();

        void IncluirPessoa(Pessoa pessoa);

        void AtualizarPessoa(Pessoa pessoa);
    }
}
