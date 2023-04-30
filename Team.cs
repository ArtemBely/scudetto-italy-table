using System;
using System.Collections;
using System.Linq;

namespace scudetto_italy 
{
        public enum Team
        {
            Roma,
            Juventus,
            Milan,
            Napoli,
            Inter,
            Bologna,
            Verona,  
            Cremoneze,
            Empoli,
            Lecce,
            Parma,
            SPAL,
            Benevento,
            Como,
            Ascoli,
            Palermo,
            Brescia,
            Ternana,
            Perugia,
            Genoa
        }

        public static class FootballClubInfo
        {
            public const int Count = 6;

            public static IEnumerable Items
            {
                get
                {
                    return Enum.GetValues(typeof(Team)).Cast<Team>();
                }
            }

            public static string GetName(Team footballClub)
            {
                switch (footballClub)
                {
                    case Team.Roma:
                        return "Roma";
                    case Team.Juventus:
                        return "Juventus";
                    case Team.Milan:
                        return "Milan";
                    case Team.Napoli:
                        return "Napoli";
                    case Team.Genoa:
                        return "Genoa";
                    case Team.Perugia:
                        return "Perugia";
                    case Team.Inter:
                        return "Inter";
                    case Team.Como:
                        return "Como";
                    case Team.Brescia:
                        return "Brescia";
                    case Team.Bologna:
                        return "Bologna";
                    case Team.Palermo:
                        return "Palermo";
                    case Team.Verona:
                        return "Verona";
                    case Team.Ascoli:
                        return "Ascoli";
                    case Team.Benevento:
                        return "Benevento";
                    case Team.SPAL:
                        return "SPAL";
                    case Team.Cremoneze:
                        return "Cremoneze";
                    case Team.Empoli:
                        return "Empoli";
                    case Team.Lecce:
                        return "Lecce";
                    case Team.Parma:
                        return "Parma";
                    case Team.Ternana:
                        return "Ternana";
                    default:
                        return "";
                }
            }
        }
}
