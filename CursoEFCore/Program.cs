using System;
using CursoEFCore.Data;
using CursoEFCore.Model;
using CursoEFCore.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //InserindoDados();
            //InserirDadosEmMassa();
            TrabalhandoComChamado();
        }

        private static void InserirDadosEmMassa()
        {
            var produto = new Produto()
            {
                Descricao = "Produto teste dia 2",
                CodigoDeBarras = "12332145644",
                Valor = 50m,
                TipoProduto = TipoProduto.Embalagem,
                Ativo = true
            };

            var cliente = new Cliente()
            {
                Nome = "Rafael Almeida",
                CEP = "60336100",
                Cidade = "Fortaçeza",
                Estado = "CE",
                Telefone = "85987878787"
            };

            var listaClientes = new [] 
            {
                new Cliente()
                {
                    Nome = "Luiz Profilio",
                    CEP = "60336100",
                    Cidade = "Fortaçeza",
                    Estado = "CE",
                    Telefone = "85987878787"
                },
                new Cliente()
                {
                    Nome = "Rafael Cavalcante",
                    CEP = "60336100",
                    Cidade = "Fortaçeza",
                    Estado = "CE",
                    Telefone = "85987878787"
                }
            };

            using var db = new ApplicationContext();
            //db.AddRange(produto, cliente);
            db.Clientes.AddRange(listaClientes);
            var resultados = db.SaveChanges();
            Console.WriteLine($"Total de Registro(s) =  {resultados}");
        }

        private static void InserindoDados()
        {
            var produto = new Produto()
            {
                Descricao = "Produto Teste",
                CodigoDeBarras = "234567891231",
                Valor = 10m,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };

            using var db = new ApplicationContext();
            //1-opção
            //db.Produtos.Add(produto);
            //2-opção
            //db.Set<Produto>().Add(produto);
            //3 - opção : Forçando o rastreamento
            db.Entry(produto).State = EntityState.Added;
            //db.Add(produto);

            var registros = db.SaveChanges();
            Console.WriteLine($"Total Registros: {registros}");
        }

        private static void AtualizarDados()
        {
             using var db = new ApplicationContext();
            //1-opção
            //db.Produtos.Add(produto);
            //2-opção
            //db.Set<Produto>().Add(produto);
            //3 - opção : Forçando o rastreamento
            //db.Entry(produto).State = EntityState.Added;
            //db.Add(produto);

            var result = db.Chamados.Find(1);

            var registros = db.SaveChanges();
        }

        private static void TrabalhandoComChamado()
        {
            var chamado =  new Chamado()
            {
                Codigo = "123",
                Titulo = "NovoTitulo"              
            };

            using var db = new ApplicationContext();

            //db.Entry(chamado).State = EntityState.Added;
            //db.Entry(chamado).State = EntityState.Ed;
            var chamado2 = db.Chamados.Find("123");

            chamado2.Titulo = "Novo titulo 2";

            //db.Attach(chamado2);
            db.Update(chamado2);         
            db.SaveChanges();
        }
    }
}
