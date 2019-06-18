using Loja.Entidades;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.DAO
{
    public class ProdutoDAO
    {
        private ISession session;

        public ProdutoDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(Produto produto)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Save(produto);
            transacao.Commit();
        }

        public Produto BuscaPorId(int id)
        {
            return session.Get<Produto>(id);
        }

        public IList<Produto> BuscaPorNomePrecoMinimoECategoria(string nome, decimal precoMinimo, string nomeCategoria)
        {
            ICriteria criteria = session.CreateCriteria<Produto>();

            if (!String.IsNullOrEmpty(nome))
            {
                criteria.Add(Restrictions.Eq("Nome", nome));
            }

            if (precoMinimo > 0)
            {
                criteria.Add(Restrictions.Ge("Preco", precoMinimo));
            }

            if (!String.IsNullOrEmpty(nomeCategoria))
            {
                ICriteria criteriaCategoria = criteria.CreateCriteria("Categoria");
                criteriaCategoria.Add(Restrictions.Eq("Nome", nomeCategoria));
            }

            return criteria.List<Produto>();
        }
    }
}
