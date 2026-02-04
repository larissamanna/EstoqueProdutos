namespace EstoqueProdutos
{
    class Produto
    {
        //public int Id { get; set; };   -> prop + tab tab
        //nesse caso vira uma propriedade e não mais uma variável. Além disso, fica publico, podendo mexer nela direto no Main sem precisar de funções
        //da pra fazer { get; private set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Qtd { get; set; }

        public Produto(int id, string nome, int qtd)
        {
            Id = id;
            Nome = nome;
            Qtd = qtd;
        }

        //se nao usar o get, set do c#
        //tem q fazer funçoes para fazer get e set na variavel private
        //public void setQtd(int qtd)
        //{
        //    Qtd = qtd;
        //}

        //public int getQtd()
        //{
        //    return Qtd;
        //}

        public Produto()
        {
            Console.WriteLine("Digite o id do produto");
            Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o nome do produto");
            Nome = Console.ReadLine();
            Console.WriteLine("Digite a quantidade do produto");
            Qtd = int.Parse(Console.ReadLine());
        }

        public void Imprimir()
        {
            Console.WriteLine($"{Id}; {Nome}; {Qtd}"); 
        }

        public bool EstoqueBaixo()
        {
            return Qtd <= 10;
        }

        public void Editar()
        {
            Console.WriteLine("Digite o nome do produto");
            Nome = Console.ReadLine();
            Console.WriteLine("Digite a quantidade do produto");
            Qtd = int.Parse(Console.ReadLine());
        }
    }

    class Celula
    {
        public Produto Dado { get; set; }
        public Celula Prox { get; set; }

        public Celula(Produto p)
        {
            Dado = p;
            Prox = null;
        }
    }

    class Lista
    {
        Celula Inicio, Fim;
        public int Qtd { get; set; }
        
        public Lista()
        {
            Inicio = Fim = new Celula(null);
            Qtd = 0;
        }

        public void Adicionar(Produto p)
        {
            Celula nova = new Celula(p);
            Fim.Prox = nova;
            Fim = nova;
            Qtd++;
        }

        public void Remover(int id)
        {
            if (Inicio == Fim)
            {
                Console.WriteLine("A lista está vazia.");
                return;
            }
            Celula anterior = Inicio;
            Celula atual = Inicio.Prox;

            while (atual != null)
            {
                if (atual.Dado.Id == id)
                {
                    anterior.Prox = atual.Prox; //remove a celula

                    if (atual == Fim)
                    {
                        Fim = anterior; //atualiza o fim se remover
                    }
                    Qtd--;
                    Console.WriteLine($"Produto {id} removido.");
                    return;
                }
                anterior = atual;
                atual = atual.Prox;
            }
            Console.WriteLine($"Produto {id} não encontrado.");
        }

        public void Imprimir()
        {
            Celula tmp = Inicio.Prox;
            while (tmp != null)
            {
                tmp.Dado.Imprimir();
                tmp = tmp.Prox;
            }
        }

        public Produto Pesquisar(int id)
        {
            Celula tmp = Inicio.Prox;
            while (tmp != null)
            {
                if(tmp.Dado.Id == id)
                {
                    return tmp.Dado;
                }
                tmp = tmp.Prox;
            }
            return null;
        }
    }
    internal class Program
    {

        static int Menu()
        {
            Console.WriteLine("### Estoque de Produtos ###");
            Console.WriteLine("1- Adicionar Produto");
            Console.WriteLine("2- Remover Produto");
            Console.WriteLine("3- Listar Produtos");
            Console.WriteLine("4- Pesquisar Produto");
            Console.WriteLine("0- Sair");
            Console.Write("Digite uma opção: ");
            int opcao = int.Parse(Console.ReadLine());

            return opcao;
        }

        //static void PreencherEstoque(Lista estoque, int n)
        //{
        //    for(int i = 0; i < n; i++)
        //    {
        //        estoque.Adicionar(new Produto(i + 1, $"Produto {i + 1}", 10));
        //    }
        //}
        static void Main(string[] args)
        {
            Lista Estoque = new Lista();
            //PreencherEstoque(Estoque, 10);
            int opcao = 0;

            do
            {
                opcao = Menu();

                switch (opcao)
                {
                    case 0:
                        break;

                    case 1:
                        Estoque.Adicionar(new Produto());
                        break;

                    case 2:
                        Console.WriteLine("Digite o id do produto: ");
                        int id = int.Parse(Console.ReadLine());
                        Estoque.Remover(id);
                        break;

                    case 3:
                        Estoque.Imprimir();
                        break;

                    case 4:
                        {
                            Console.WriteLine("Digite o id do produto: ");
                            int Id = int.Parse(Console.ReadLine());
                            Produto p = Estoque.Pesquisar(Id);
                            if (p == null) Console.WriteLine("Produto não encontrado");
                            else p.Imprimir();
                        }
                        break;

                    //case 4:
                    //    {
                    //        Console.WriteLine("Digite o id do produto: ");
                    //        int id = int.Parse(Console.ReadLine());
                    //        Produto p = Estoque.Pesquisar(id);
                    //        if (p == null) Console.WriteLine("Produto não encontrado");
                    //        else p.Editar();
                    //    }
                    //    break;
                }
            } while (opcao != 0);

        }
    }
}
