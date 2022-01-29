
using System;
using System.Collections.Generic;
using System.Linq;

namespace CATAGY_TXT2SRT
{
    class IdozitettFelirat
    {
        public string Idozites { get; set; }
        public string Felirat { get; set; }
        public IdozitettFelirat(KeyValuePair<string,string> adat)
        {
            Idozites = adat.Key;
            Felirat = adat.Value;
        }
        public int SzavakSzama => Felirat.Split(' ').Count();
        public string SrtIdozites => Kiszamol(Idozites);

        private string Kiszamol(string felirat)
        {
            var buff = felirat.Split('-');
            var Tol = buff[0].Trim();
            var ora = 0;
            var perc = int.Parse(Tol.Split(':')[0]);
            var mp = int.Parse(Tol.Split(':')[1]);
            if (perc > 60)
            {
                ora += 1;
                perc = perc - 60;
            }
            var kezdoIp = new TimeSpan(ora, perc, mp);

            var Ig = buff[1].Trim();

            var oraIg = 0;
            var percIg = int.Parse(Ig.Split(':')[0]);
            var mpIg = int.Parse(Ig.Split(':')[1]);
            if (percIg > 60)
            {
                oraIg += 1;
                percIg = percIg - 60;
            }
            var vegIp = new TimeSpan(oraIg, percIg, mpIg);

            return (kezdoIp + "-->" + vegIp);

        }
    }
}
