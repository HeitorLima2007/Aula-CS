class Menu()
    private static void Menu()
{
char selecao = 'n';
int contaPagamento = 0;
Console.WriteLine("Iniciar Caixa");
var pagamentos = new double[5];
int pegaIndice = 0;
double peso = 0.00;

do
{

string[,] itens = new string[5, 2] { { "pão", "17,50" }, { "salgadinho", "5,00" }, { "batata", "7,00" }, { "laranja", "5,30" }, { "contra-filé", "49,99" } };


Console.WriteLine("Digite para Venda == v ,Consulta de Preço == c ,Fechamento de Caixa == f, Fechamento do aplicativo == s");
string? pegaSelecao = Console.ReadLine();

if (pegaSelecao.Length == 1)
{
selecao = pegaSelecao[0];
}


if (selecao == 'v')
{
Console.WriteLine("-----------------Produtos---------------");

for (int i = 0; i < 5; i++)
{
Console.WriteLine($"Índice : {i} , Produto : {itens[i, 0]}, valor : {itens[i, 1]}");
}

Console.WriteLine("Quantide de Produtos");
int qtaProdutos = int.Parse(Console.ReadLine());
int contaProdutos = 0;

while (contaProdutos < qtaProdutos)
{
Console.WriteLine("Digite o índice");
pegaIndice = int.Parse(Console.ReadLine());
Console.WriteLine("Digite o peso");
peso = double.Parse(Console.ReadLine());
pagamentos[contaProdutos] = double.Parse(itens[pegaIndice, 1]) * peso;
Console.WriteLine($"contaProdutos {contaProdutos}");
contaProdutos++;
}

double valorPagar = 0.00;

Console.WriteLine("------Opçoes de Pagamento-------");
Console.WriteLine("---Cartões de Crédito --Digite C");
Console.WriteLine("---Cartões de Débito -- Digite D");
Console.WriteLine("---QRCode ------------- Digite Q");
Console.WriteLine("---Dinheiro ----------- Digite I");

char tipoPagamento = 'I';

string? tipoPagamentoDigitado = Console.ReadLine();

if (tipoPagamentoDigitado.Length == 1)
{

tipoPagamento = tipoPagamentoDigitado[0];
}

switch (tipoPagamento)
{
case 'C':
Console.WriteLine("Pagamento com Cartão de Crédito");
break;
case 'D':
Console.WriteLine("Pagamento com Cartão de Débito");
break;
case 'Q':
Console.WriteLine("Pagamento com QRCode");
break;
default:
Console.WriteLine("Pagamento com Dinheiro");
break;

}


//Console.WriteLine("Produto :" + produto + " Código :" + codigo + " Valor à Pagar :" + valorPagar);

double valorTotal = 0.00;

foreach (var item in pagamentos)
{
Console.WriteLine($"Valor da Venda : {item}");
valorTotal = valorTotal + item;

}
contaPagamento = 0;
Console.WriteLine($"Valor Total:{valorTotal}");


}
else if (selecao == 'c')
{
Console.WriteLine("--Consulta de Produtos--");
Console.WriteLine("Produto :" + itens[0, 0]);
Console.WriteLine("Produto :" + itens[1, 0]);
Console.WriteLine("Produto :" + itens[2, 0]);
Console.WriteLine("Produto :" + itens[3, 0]);
Console.WriteLine("Produto :" + itens[4, 0]);

}
else if (selecao == 'f')
{
Console.WriteLine("--Fechamento de Caixa--");
}
else
{
Console.WriteLine("--Fechamento do Aplicativo--");
}

} while (selecao != 's');

