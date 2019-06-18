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

            ISession session = NHibernateHelper.AbreSession();

            String hql = "select p.Categoria as Categoria, count(p) as NumeroDePedidos from Produto p group by p.Categoria";
            IQuery query = session.CreateQuery(hql);
            query.SetResultTransformer(Transformers.AliasToBean<ProdutosPorCategoria>());

            IList<ProdutosPorCategoria> relatorio = query.List<ProdutosPorCategoria>();
            session.Close();

            Console.Read();
        }
    }

    public class ProdutosPorCategoria
    {
        public Categoria Categoria { get; set; }
        public long NumeroDePedidos { get; set; }
    }
}
