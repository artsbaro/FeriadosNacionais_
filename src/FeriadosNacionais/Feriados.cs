using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeriadosNacionais
{
    public static class Feriados
    { 
        public static List<DateTime> ObterListaFeriados(int year)
        {
            var feriados = new List<DateTime>
            {
                new DateTime(year, 1, 1), //Ano novo
                new DateTime(year, 4, 21),  //Tiradentes
                new DateTime(year, 5, 1), //Dia do trabalho
                new DateTime(year, 9, 7), //Dia da Independência do Brasil
                new DateTime(year, 10, 12),  //Nossa Senhora Aparecida
                new DateTime(year, 11, 2), //Finados
                new DateTime(year, 11, 15), //Proclamação da República
                new DateTime(year, 12, 25) //Natal
            };
            return feriados;
        }

        public static void CalcularFeriadosEclesiasticos(ref DateTime[] dataConsiderada)
        {
            var ano = dataConsiderada.Last().Year;

            var resultado = new List<DateTime>();
            var dourado = (ano - ((ano / 19) * 19)) + 1;
            var dataBase = NumeroDourado(ano)
                .Where(x => x.Key == dourado)
                .Select(x => x.Value)
                .FirstOrDefault();

            if (dataBase.DayOfWeek == DayOfWeek.Sunday)
                dataBase = dataBase.AddDays(7);

            while (dataBase.DayOfWeek != DayOfWeek.Sunday)
                dataBase = dataBase.AddDays(1);

            dataConsiderada = dataConsiderada
                .Where(x => x != dataBase)
                .Where(x => x != dataBase.AddDays(-2))
                .Where(x => x != dataBase.AddDays(-47))
                .ToArray();
        }

        private static Dictionary<int, DateTime> NumeroDourado(int ano)
        {
            Dictionary<int, DateTime> DNumero = new Dictionary<int, DateTime>();
            DNumero.Add(1, new DateTime(ano, 4, 14));
            DNumero.Add(2, new DateTime(ano, 4, 3));
            DNumero.Add(3, new DateTime(ano, 3, 23));
            DNumero.Add(4, new DateTime(ano, 4, 11));
            DNumero.Add(5, new DateTime(ano, 3, 31));
            DNumero.Add(6, new DateTime(ano, 4, 18));
            DNumero.Add(7, new DateTime(ano, 4, 8));
            DNumero.Add(8, new DateTime(ano, 3, 28));
            DNumero.Add(9, new DateTime(ano, 4, 16));
            DNumero.Add(10, new DateTime(ano, 4, 5));
            DNumero.Add(11, new DateTime(ano, 3, 25));
            DNumero.Add(12, new DateTime(ano, 4, 13));
            DNumero.Add(13, new DateTime(ano, 4, 2));
            DNumero.Add(14, new DateTime(ano, 3, 22));
            DNumero.Add(15, new DateTime(ano, 4, 10));
            DNumero.Add(16, new DateTime(ano, 3, 30));
            DNumero.Add(17, new DateTime(ano, 4, 17));
            DNumero.Add(18, new DateTime(ano, 4, 7));
            DNumero.Add(19, new DateTime(ano, 3, 27));

            return DNumero;
        }
    }
}
