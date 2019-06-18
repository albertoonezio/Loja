using Loja.DAO;
using Loja.Entidades;
using Loja.Infra;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja
{
    class Program
    {
        static void Main(string[] args)
        {
            //NHibernateHelper.GeraSchema();

            PessoaFisica pessoaFisica = new PessoaFisica();
            pessoaFisica.Nome = "Luana";
            pessoaFisica.CPF = "123.456.789-00";

            PessoaFisica pessoaFisica1 = new PessoaFisica();
            pessoaFisica1.Nome = "Alberto";
            pessoaFisica1.CPF = "014.000.555-88";

            PessoaJuridica pessoaJuridica = new PessoaJuridica();
            pessoaJuridica.Nome = "Caelum";
            pessoaJuridica.CNPJ = "123.456/0001-99";

            ISession session = NHibernateHelper.AbreSession();
            UsuarioDAO usuarioDAO = new UsuarioDAO(session);

            usuarioDAO.Adiciona(pessoaFisica);
            usuarioDAO.Adiciona(pessoaFisica1);
            usuarioDAO.Adiciona(pessoaJuridica);

            Console.Read();
        }
    }

    public class ProdutosPorCategoria
    {
        public Categoria Categoria { get; set; }
        public long NumeroDePedidos { get; set; }
    }
}
