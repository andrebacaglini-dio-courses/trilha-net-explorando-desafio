namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception($"O número de hospedes ({hospedes.Count}) é superior a capacidade da suite ({Suite.Capacidade})");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            Console.WriteLine("Calculando valor da diária...");
            Console.WriteLine($"Qtdade de dias reservados: {DiasReservados}");
            Console.WriteLine($"Valor da diária: {Suite.ValorDiaria.ToString("C")}");
            decimal valor = DiasReservados * Suite.ValorDiaria;
            Console.WriteLine($"Valor total da estadia: {valor.ToString("C")}");

            if (DiasReservados >= 10)
            {
                Console.WriteLine("Aplicando desconto de 10%...");
                valor = valor - (valor * 0.10M);
                Console.WriteLine($"Valor total da estadia com 10% de desconto: {valor.ToString("C")}");
            }

            return valor;
        }
    }
}