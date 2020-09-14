using System;
using System.Collections.Generic;
using System.Linq;

namespace FeriadosNacionais
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = ObterDataValida(DateTime.Today.AddDays(2));

            Console.WriteLine($"{data}");
            Console.ReadKey();
        }

        public static DateTime ObterDataValida(DateTime dataConsiderada)
        {
            return ObterDatasValidas(DateTime.Today, DateTime.Today.AddDays(20))
                .Where(d => d.Date > dataConsiderada.Date)
                .First();
        }

        public static DateTime[] ObterDatasValidas(
            DateTime min,
            DateTime max)
        {
            var feriados = Feriados.ObterListaFeriados(max.Year);
            var result = new List<DateTime>();
            var count = max - min;
            result.Add(min);

            for (int i = 0; i < count.Days; i++)
                result.Add(result.Last().AddDays(1));

            var diasUteis = result.Select(datas => datas)
                            .Where(x => x.DayOfWeek != DayOfWeek.Saturday
                            && x.DayOfWeek != DayOfWeek.Sunday
                            && (feriados.Where(y => y.Month == x.Month && y.Day == x.Day)
                            .Count() == 0)).ToArray();

            Feriados.CalcularFeriadosEclesiasticos(ref diasUteis);
            return diasUteis;
        }
    }
}
